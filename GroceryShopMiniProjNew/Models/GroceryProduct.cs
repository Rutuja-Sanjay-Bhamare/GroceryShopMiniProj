using System;
using System.Collections.Generic;

namespace GroceryShopMiniProjNew.Models
{
    public partial class GroceryProduct
    {
        public GroceryProduct()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantityKg { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
