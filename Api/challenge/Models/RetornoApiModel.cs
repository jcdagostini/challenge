using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Take.Challenge.Models
{
    public class RetornoApiModel
    {
        public RetornoApiModel()
        {
            items = new List<Item>();
        }
        public string itemType { get; set; }
        public List<Item> items { get; set; }
    }

    public class Value
    {
        public string title { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Header
    {
        public string type { get; set; }
        public Value value { get; set; }
    }

    public class Item
    {
        public Header header { get; set; }   
    }
}
