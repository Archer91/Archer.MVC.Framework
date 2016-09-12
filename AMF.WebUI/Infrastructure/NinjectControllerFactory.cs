using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using AMF.Domain.Abstract;
using AMF.Domain.Concrete;

namespace AMF.WebUI.Infrastructure
{
    //Ninject控制器工厂
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //Ninject绑定
            //IProductRepository接口的模仿实现
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product{ Name="Football", Price=25},
            //    new Product{ Name="Surf board", Price=179},
            //    new Product{ Name="Running shoes", Price=95}
            //}.AsQueryable());
            //ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}