using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfCheckoutSim.Data;
using SelfCheckoutSim.Models;
using SelfCheckoutSim.ViewModels;

namespace SelfCheckoutSim.Controllers
{
    public class SelfCheckoutSimController : Controller
    {
        private readonly SelfChecoutSimContext context;

        public SelfCheckoutSimController(SelfChecoutSimContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            //takes last 10 things entered into the database
            IList<Item> items = context.Items.Take(5).ToList();

            return View(items);
        }

        
        public IActionResult AddItem(ItemViewModel itemViewModel)
        {
            //TODO combine add item and remove item page into one?
            if (ModelState.IsValid)
            {

                Item newItem = new Item
                {
                    Name = itemViewModel.Name,
                    Price = itemViewModel.Price,
                    Wt = itemViewModel.Wt,
                    Fs = itemViewModel.Fs,
                    LbOrUnit = itemViewModel.LbOrUnit,
                    PLU = Helper.getPlu(itemViewModel.PLU, itemViewModel.Name)
                };
                context.Items.Add(newItem);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View(itemViewModel);
        }

        public IActionResult RemoveItem()
        {
            ViewBag.Items = context.Items.ToList();
            return View();
        }

        [HttpPost]
        //to remove an item, name select and that is what sent in the post
        public IActionResult RemoveItem(int items)
        {
            Item item = context.Items.Single(i => i.ID == items);
            context.Items.Remove(item);
            //TODO add message saying item has been removed

            context.SaveChanges();

            return Redirect("/");
        }

        //public IActionResult NewOrder()
        //{

        //}
    }
}