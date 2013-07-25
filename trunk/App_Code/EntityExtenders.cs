using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductListDBModel
{
    /// <summary>
    /// Summary description for EntityExtenders
    /// </summary>
    public partial class Shopping_List
    {
        public string ProductName
        {
            get { return Product.product_name ; }
        }

        public string MeasureUnitName
        {
            get { return Product.Measure.measure_unit_name ; }
        }

    }
}
