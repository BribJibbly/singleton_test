using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_test
{
    class ItemPop
    {
        public string Items { get; set; }
        public string Price { get; set; }
        public ItemPop()
        {
        }

        public ItemPop(string items, string price)
        {
            Items = items;
            Price = price;
        }


    }
}
