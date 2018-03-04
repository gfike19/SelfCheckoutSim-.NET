using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.Models
{
    public class Trans
    {
        public int ID { get; set; }
        public List<Item> Items { get; set; }
        public int SubTotal { get; set; }
        public int Total { get; set; }
        public int FsTotal { get; set; }
        public int NfsTotal { get; set; }

        public Trans()
        {
        }
    }
}
