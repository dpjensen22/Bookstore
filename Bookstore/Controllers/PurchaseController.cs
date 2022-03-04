using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchasation());
        }

        [HttpPost]
        public IActionResult Checkout(Purchasation purchasation)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry you rbasket is empty!");
            }

            if (ModelState.IsValid)
            {
                purchasation.Lines = basket.Items.ToArray();
                repo.SavePurchasation(purchasation);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
