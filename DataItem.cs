using System.Collections.Generic;

namespace Ingenio
{
    public class DataItem
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string KeyWords { get; set; }
        public List<DataItem> Children { get; set;} = new List<DataItem>();
        public DataItem Parent { get; set;}
    }
}