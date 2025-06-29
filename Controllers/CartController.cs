﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMobileSite.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public CartController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task <IActionResult> AddItem(int mobileId,int qnt=1,int redirect=0)
        {
            var cartCount = await _cartRepo.AddItem(mobileId, qnt);
            if(redirect == 0)
            return Ok(cartCount);
            return RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult>  RemoveItem(int mobileId)
        {
            var cartCount = await _cartRepo.RemoveItem(mobileId);

            return RedirectToAction("GetUserCart");

        }
        public async Task<IActionResult> GetUserCart()
        {
            var cart=await _cartRepo.GetUserCart();
            return View(cart);
        }
        public async Task<IActionResult> GetTotalItemInCart()
        {
            var cartItem=await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            bool isCheckedOut = await _cartRepo.DoCheckout(model);
            if (!isCheckedOut)
                return RedirectToAction(nameof(OrderFailure));
            return RedirectToAction(nameof(OrderSuccess));
        }
        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult OrderFailure()
        {
            return View();
        }
    }
}
