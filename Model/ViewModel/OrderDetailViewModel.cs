using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    class OrderDetailViewModel
    {
        public long id { get; set; }
        public string productName { get; set; }
        public int? quantity { get; set; }
        public decimal? price { get; set; }
        public decimal? total { get; set; }
    }
}
