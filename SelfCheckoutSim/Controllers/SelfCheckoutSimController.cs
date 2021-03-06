﻿using System;
using System.Collections;
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
            //takes last 5 things entered into the database
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
        public IActionResult RemoveItem(int itemId)
        {
            Item item = context.Items.Single(i => i.ID == itemId);
            context.Items.Remove(item);
            //TODO add message saying item has been removed

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult NewOrder()
        {
            ViewBag.Shelf = context.Items.ToList();

            try
            {
                ViewBag.Cart = TempData[key: "cart"];
            }
            catch (Exception)
            {
                ViewBag.Cart = "";
            }

            return View();
        }

        //TODO change additem as it interfers with adding an item to the database
        [HttpPost]
        public IActionResult AddItem(int shelf)
        {

            Item item = context.Items.Single(i => i.ID == shelf);

            try
            {
                List<Item> cart = TempData[key: "cart"] as List<Item>;
                cart.Add(item);
                TempData[key: "cart"] = cart;
                ViewBag.Cart = cart;
            }
            catch (Exception)

            {
                List<Item> cart = new List<Item>
                {
                    item
                };
                TempData[key: "cart"] = cart;
                ViewBag.Cart = cart;
            }
            return View("NewOrder");

        }
    }
}