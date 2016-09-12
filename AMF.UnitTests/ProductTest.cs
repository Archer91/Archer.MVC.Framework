using AMF.Domain.Abstract;
using AMF.Domain.Entities;
using AMF.WebUI.Controllers;
using AMF.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AMF.WebUI.HtmlHelpers;

namespace AMF.UnitTests
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //布置，创建模仿存储库
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ ProductID=1,Name="P1"},
                new Product{ ProductID=2,Name="P2"},
                new Product{ ProductID=3,Name="P3"},
                new Product{ ProductID=4,Name="P4"},
                new Product{ ProductID=5,Name="P5"}
            }.AsQueryable());
            //创建一个控制器，并时页面大小为3条数据项
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //动作
            ProductsListViewModel result = (ProductsListViewModel)controller.Index(2).Model;

            //断言
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //布置
            //定义一个HTML辅助器方法，为了运用这个扩展方法
            HtmlHelper myHelper = null;
            //创建PagingInfo数据
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            //用一个lambda表达式来创建委托
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //动作
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //断言
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");

        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //布置，创建模仿存储库
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ ProductID=1,Name="P1"},
                new Product{ ProductID=2,Name="P2"},
                new Product{ ProductID=3,Name="P3"},
                new Product{ ProductID=4,Name="P4"},
                new Product{ ProductID=5,Name="P5"}
            }.AsQueryable());
            //创建一个控制器，并时页面大小为3条数据项
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //动作
            ProductsListViewModel result = (ProductsListViewModel)controller.Index(2).Model;

            //断言
            PagingInfo pageInfo = result.pagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
