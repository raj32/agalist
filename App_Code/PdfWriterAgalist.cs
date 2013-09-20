using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductListDBModel;
using PdfFileWriter;
using System.Drawing;
using System.Diagnostics;

/// <summary>
/// Summary description for PdfWriterAgalist
/// </summary>
public class PdfWriterAgalist
{
    PdfFont ArialNormal;
    PdfFont ArialBold;
    PdfFont ArialItalic;
    PdfFont ArialBoldItalic;
    PdfFont TimesNormal;
    PdfFont Comic;

	public PdfWriterAgalist()
	{
		//
		// TODO: Add constructor logic here
		//        
	}

    // Create “article example” test PDF document
    public void Test()
    {
        String FileName = "D:\\Projects\\text.pdf";
        // Step 1: Create empty document
        // Arguments: page width: 8.5”, page height: 11”, Unit of measure: inches
        // Return value: PdfDocument main class
        PdfDocument Document = new PdfDocument(8.5, 11.0, UnitOfMeasure.Inch);

        // Debug property
        // By default it is set to false. Use it for debugging only.
        // If this flag is set to true, PDF objects will not be compressed,
        // font and images will be replaced by text place holder.
        // You can view the file with a text editor but you cannot open it with a PDF reader.
        Document.Debug = false;

        // Step 2: create resources
        // define font resources
        DefineFontResources(Document);

        // define tiling pattern resource
        DefineTilingPatternResource(Document);

        // Step 3: Add new empty page
        PdfPage Page = new PdfPage(Document);

        // Step 4: Add contents object to the page object
        PdfContents Contents = new PdfContents(Page);

        
        // Step 5: add graphics and text contents to the contents object
        DrawFlower(Document, Contents);
        DrawTextBox(Contents);

        // Step 6: create pdf file
        // argument: PDF file name
        Document.CreateFile(FileName);

        // Optional step (very useful during development)
        // start default PDF reader and display the file
        // Note: To use Process class you need "using System.Diagnostics" statement
        Process Proc = new Process();
        Proc.StartInfo = new ProcessStartInfo(FileName);
        
        Proc.Start();

        // exit
        return;
    }

    // Define Font Resources
    private void DefineFontResources(PdfDocument Document)
    {
        // Define font resources
        // Arguments: PdfDocument class, font family name, font style, embed flag
        // Font style (must be: Regular, Bold, Italic or Bold | Italic) All other styles are invalid.
        // Embed font. If true, the font file will be embedded in the PDF file.
        // If false, the font will not be embedded.
        ArialNormal = new PdfFont(Document, "Arial", FontStyle.Regular, true);
        ArialBold = new PdfFont(Document, "Arial", FontStyle.Bold, true);
        ArialItalic = new PdfFont(Document, "Arial", FontStyle.Italic, true);
        ArialBoldItalic = new PdfFont(Document, "Arial", FontStyle.Bold | FontStyle.Italic, true);
        TimesNormal = new PdfFont(Document, "Times New Roman", FontStyle.Regular, true);
        Comic = new PdfFont(Document, "Comic Sans MS", FontStyle.Bold, true);

        // substitute one character for another
        // this program supports characters 32 to 126 and 160 to 255
        // if a font has a character outside these ranges that is required by the application,
        // you can replace an unused character with this character.
        ArialNormal.CharSubstitution(9679, 9679, 164);
        return;
    }

    // Define Tiling Pattern Resource
    private void DefineTilingPatternResource(PdfDocument Document)
    {
        // create empty tiling pattern
        PdfTilingPattern WaterMark = new PdfTilingPattern(Document);

        // the pattern will be PdfFileWriter laid out in brick pattern
        String Mark = "PdfFileWriter";

        // text width and height for Arial bold size 18 points
        Double FontSize = 18.0;
        Double TextWidth = ArialBold.TextWidth(FontSize, Mark);
        Double TextHeight = ArialBold.LineSpacing(FontSize);

        // text base line
        Double BaseLine = ArialBold.DescentPlusLeading(FontSize);

        // the overall pattern box (we add text height value as left and right text margin)
        Double BoxWidth = TextWidth + 2 * TextHeight;
        Double BoxHeight = 4 * TextHeight;
        WaterMark.SetTileBox(BoxWidth, BoxHeight);

        // save graphics state
        WaterMark.SaveGraphicsState();

        // fill the pattern box with background light blue color
        WaterMark.SetColorNonStroking(Color.FromArgb(230, 244, 255));
        WaterMark.DrawRectangle(0, 0, BoxWidth, BoxHeight, PaintOp.Fill);

        // set fill color for water mark text to white
        WaterMark.SetColorNonStroking(Color.White);

        // draw PdfFileWriter at the bottom center of the box
        WaterMark.DrawText(ArialBold, FontSize, BoxWidth / 2, BaseLine, TextJustify.Center, Mark);

        // adjust base line upward by half height
        BaseLine += BoxHeight / 2;

        // draw the right half of PdfFileWriter shifted left by half width
        WaterMark.DrawText(ArialBold, FontSize, 0.0, BaseLine, TextJustify.Center, Mark);

        // draw the left half of PdfFileWriter shifted right by half width
        WaterMark.DrawText(ArialBold, FontSize, BoxWidth, BaseLine, TextJustify.Center, Mark);

        // restore graphics state
        WaterMark.RestoreGraphicsState();
        return;
    }

    // Draw image of a flower and clip it
    private void DrawFlower(PdfDocument Document, PdfContents Contents)
    {
        // define local image resources
        PdfImage Image1 = new PdfImage(Document, "D:\\Projects\\AgalistDev\\Images\\Logo.jpg");

        // image size will be limited to 1.4" by 1.4"
        SizeD ImageSize = Image1.ImageSize(4, 4);

        // save graphics state
        Contents.SaveGraphicsState();

        // translate coordinate origin to the center of the picture
        Contents.Translate(3.36, 5.7);

        // clipping path
//        Contents.DrawOval(-ImageSize.Width / 2, -ImageSize.Height / 2,
//            ImageSize.Width, ImageSize.Height, PaintOp.ClipPathEor);

        // draw image
        Contents.DrawImage(Image1, 5.25, 3
        ,            ImageSize.Width, ImageSize.Height);

        // restore graphics state
        Contents.RestoreGraphicsState();
        return;
    }

        // Draw example of a text box
private void DrawTextBox(PdfContents Contents)
{
// save graphics state
Contents.SaveGraphicsState();

// translate origin to PosX=1.1" and PosY=1.1"
// this is the bottom left corner of the text box example
Contents.Translate(1.1, 1.1);

// Define constants
// Box width 3.25"
// Box height is 3.65"
// Normal font size is 9.0 points.
const Double Width = 3.15;
const Double Height = 3.65;
const Double FontSize = 9.0;

// Create text box object width 3.25"
// First line indent of 0.25"
TextBox Box = new TextBox(Width, 0.25);

// add text to the text box
Box.AddText(ArialNormal, FontSize,
    "This area is an example of displaying text that is too long to fit within a " +
    "fixed width area. The text is displayed justified to right edge. You define a " +
    "text box with the required width and first line indent. You add text to this " +
    "box. The box will divide the text into lines. Each line is made of segments " +
    "of text. For each segment, you define font, font size, drawing style and color. " +
    "After loading all the text, the program will draw the formatted text.\n");
Box.AddText(TimesNormal, FontSize + 1.0, "Example of multiple fonts: Times New Roman, ");
Box.AddText(Comic, FontSize, "Comic Sans MS, ");
Box.AddText(ArialNormal, FontSize, "Example of regular, ");
Box.AddText(ArialBold, FontSize, "bold, ");
Box.AddText(ArialItalic, FontSize, "italic, ");
Box.AddText(ArialBoldItalic, FontSize, "bold plus italic. ");
Box.AddText(ArialNormal, FontSize - 2.0, "Arial size 7, ");
Box.AddText(ArialNormal, FontSize - 1.0, "size 8, ");
Box.AddText(ArialNormal, FontSize, "size 9, ");
Box.AddText(ArialNormal, FontSize + 1.0, "size 10. ");
Box.AddText(ArialNormal, FontSize, DrawStyle.Underline, "Underline, ");
Box.AddText(ArialNormal, FontSize, DrawStyle.Strikeout, "Strikeout. ");
Box.AddText(ArialNormal, FontSize, "Subscript H");
Box.AddText(ArialNormal, FontSize, DrawStyle.Subscript, "2");
Box.AddText(ArialNormal, FontSize, "O. Superscript A");
Box.AddText(ArialNormal, FontSize, DrawStyle.Superscript, "2");
Box.AddText(ArialNormal, FontSize, "+B");
Box.AddText(ArialNormal, FontSize, DrawStyle.Superscript, "2");
Box.AddText(ArialNormal, FontSize, "=C");
Box.AddText(ArialNormal, FontSize, DrawStyle.Superscript, "2");
Box.AddText(ArialNormal, FontSize, "\n");
Box.AddText(Comic, FontSize, Color.Red, "Lets add some color, ");
Box.AddText(Comic, FontSize, Color.Green, "green, ");
Box.AddText(Comic, FontSize, Color.Blue, "blue, ");
Box.AddText(Comic, FontSize, Color.Orange, "orange, ");
Box.AddText(Comic, FontSize, DrawStyle.Underline, Color.Purple, "and purple.\n");

// Draw the text box
// Text left edge is at zero (note: origin was translated to 1.1") 
// The top text base line is at Height less first line ascent.
// Text drawing is limited to vertical coordinate of zero.
// First line to be drawn is line zero.
// After each line add extra 0.015".
// After each paragraph add extra 0.05"
// Stretch all lines to make smooth right edge at box width of 3.15"
// After all lines are drawn, PosY will be set to the next text line
// after the box's last paragraph
Double PosY = Height;
Contents.DrawText(0.0, ref PosY, 0.0, 0, 0.015, 0.05, true, Box);

// Create text box object width 3.25"
// No first line indent
Box = new TextBox(Width);

// Add text as before.
// No extra line spacing.
// No right edge adjustment
Box.AddText(ArialNormal, FontSize,
	"In the examples above this area the text box was set for first line indent of " +
	"0.25 inches. This paragraph has zero first line indent and no right justify.");
Contents.DrawText(0.0, ref PosY, 0.0, 0, 0.1, 0.05, false, Box);

// Create text box object width 2.75
// First line hanging indent of 0.5"
Box = new TextBox(Width - 0.5, -0.5);

// Add text
Box.AddText(ArialNormal, FontSize,
	"This paragraph is set to first line hanging indent of 0.5 inches. " +
	"The left margin of this paragraph is 0.5 inches.");

// Draw the text
// left edge at 0.5"
Contents.DrawText(0.5, ref PosY, 0.0, 0, 0.1, 0.05, false, Box);

// restore graphics state
Contents.RestoreGraphicsState();
return;
}


}