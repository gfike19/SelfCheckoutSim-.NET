using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Wt { get; set; }
        public bool Fs { get; set; }
        public string LbOrUnit { get; set; }
        public DateTime DateCreated { get; set; }
        public string PLU { get; set; }

        public Item()
        {
        }
    }
}
