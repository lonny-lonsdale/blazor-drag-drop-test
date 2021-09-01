using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlazorTwo.Model
{
    public class Template : BaseEntity
    {
        public string name { get; set; }
        public string type { get; set; }
        public ICollection<Item> items { get; set; } = new List<Item>();
        public string template_id { get; set; }
    }
}
