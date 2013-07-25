using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using ProductListDBModel;

/// <summary>
/// Summary description for AgaMail
/// </summary>
/// 
public class AgaMail
{
    private String _sendTo;
    private MailKind _mailKind;
    private String _emailForPassword;
    private ProdListDBEntities myDBhandler = DBHandler.GetInstance();
    private String _mailContent;   

	public AgaMail(String sendTo, MailKind currMailKind)
	{
        _sendTo = sendTo;
        _mailKind = currMailKind;        
	}

    public void setMailContent(String mailCont)
    {
        _mailContent = mailCont;
    }

  
    public String prepareMail()
    {
        switch (_mailKind)
        {
            case MailKind.Tip:
                _mailContent = "Hello! \n\nNew tip has been received: \n\n" + _mailContent + ". \n\n To edit the tip, press http://www.agalist.com/newTip.aspx . \n\n";
                return _mailContent;
               
            case MailKind.PasswordReminder:
                String myPassword;
                myPassword = (from b in myDBhandler.Clients where b.email == _sendTo select b.password).First<String>();
                _mailContent = "Hello! \nYour password is: " + myPassword;                
                return _mailContent;
             
            case MailKind.Plain:
                _mailContent = "";
                return _mailContent;
              
            default:
                _mailContent = "";
                return _mailContent;
               
        }
        
    }

    public void ExecuteSending()
    {
        MailMessage mailMsg = new MailMessage();   
        SmtpClient smtp = new SmtpClient();
        smtp.TargetName = "mail.agalist.com";
        smtp.Host = "mail.agalist.com";
        smtp.EnableSsl = false;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("support@agalist.com", "donald");      
        smtp.Send("support@agalist.com", _sendTo, "Mail from AgaList", prepareMail());
    }    
}

public enum MailKind
{
    Tip,
    PasswordReminder,
    Plain
}