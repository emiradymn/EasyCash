using System;
using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.DataAccess.Repositories;
using EasyCash.Entity.Concrete;

namespace EasyCash.DataAccess.EntityFramework;

public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
{
    public EfCustomerAccountProcessDal(Context context) : base(context)
    {
    }
}
