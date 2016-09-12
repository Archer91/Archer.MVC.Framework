using AMF.Domain.Abstract;
using AMF.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMF.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;
        private IProductRepository repository;

        public HomeController(IProductRepository prodcutRepository)
        {
            repository = prodcutRepository;
        }

        public ViewResult Index(int page=1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(viewModel);
        }

    }
}
