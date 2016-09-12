using AMF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMF.Domain.Concrete
{
    //EF上下文
    public class EFDbContext:DbContext
    {
        //对应的数据表
        public DbSet<Product> Products { get; set; }
    }
}
