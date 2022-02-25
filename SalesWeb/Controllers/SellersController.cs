﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _SellerService;
        public SellersController (SellerService sellerservice)
        {
            _SellerService = sellerservice;
        }
        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);

        }
      public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Seller Seller)
        {
            _SellerService.Insert(Seller);
            return RedirectToAction(nameof (Index));
        }
    }
}


 

