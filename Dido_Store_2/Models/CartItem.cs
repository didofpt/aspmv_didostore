using Model.EF;
using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb

namespace Dido_Store_2.Models
{
    [Serializable]
    public class CartItem
    {
<<<<<<< HEAD
        public Product Product { get; set; }
        public int Quantity { get; set; }
=======
        public Product Product { set; get; }
        public int Quantity { set; get; }
>>>>>>> 0bc525544065982ded84d265aa669143e56569eb
    }
}