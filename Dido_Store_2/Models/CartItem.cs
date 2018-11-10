using Model.EF;
using System;

namespace Dido_Store_2.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }

    }
}