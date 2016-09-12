using AMF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMF.Domain.Abstract
{
    //存储库接口
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
