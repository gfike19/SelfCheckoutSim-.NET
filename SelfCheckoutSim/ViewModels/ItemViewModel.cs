using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.ViewModels
{
    public class ItemViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Food Stamps Eligibile")]
        public bool Fs { get; set; }

        [Display(Name = "Weight")]
        public int Wt { get; set; }

        [Required]
        [Display(Name = "Unit of Measure")]
        public string LbOrUnit { get; set; }

        public string PLU { get; set; }

        public string SaveChangesError { get; set; }

        public ItemViewModel() { }
    }
}
