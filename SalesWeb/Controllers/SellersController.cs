using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using SalesWeb.Models.ViewModels;
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
        private readonly DepartmentService _departmentService;
        public SellersController (SellerService Sellerservice, DepartmentService departmentService)
        {
            _SellerService = Sellerservice;
            _departmentService = departmentService;

        }
        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);

        }
      public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
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


 

