using System;
using System.Collections.Generic;

namespace GroceryShopMiniProjNew.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public string CustName { get; set; } = null!;
        public string? Adress { get; set; }
        public int? ProductId { get; set; }
        public int? Rate { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }

        public virtual List<GroceryProduct> ProductNavigation { get; set; }
      
    }
}
