using AMF.Domain.Abstract;
using AMF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMF.Domain.Concrete
{
    //存储库实现
    public class ProductRepository:IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
