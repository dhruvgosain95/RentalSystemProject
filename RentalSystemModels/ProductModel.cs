using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public bool ProductAvailability { get; set; }
        public System.DateTime RentStartDate { get; set; }
        public System.DateTime RentEndDate { get; set; }
        public int CategoryId { get; set; }
        public double ProductUnitPrice { get; set; }

        //public virtual CategoryModel Category { get; set; }
        //public virtual UserLoginModel User { get; set; }
    }
}
