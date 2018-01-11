﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Wt { get; set; }
        public bool Fs { get; set; }
        public string LbOrUnit { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        public string PLU { get; set; }

        public Item()
        {
        }
    }
}