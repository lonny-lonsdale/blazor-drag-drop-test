using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlazorTwo.Model
{
    public class Item : BaseEntity
    {
        public string item_id { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string parent_id { get; set; }
        public string[] children { get; set; }
        public ICollection<Item> items { get; set; }
        public int order_id { get; set; }
    }
}
