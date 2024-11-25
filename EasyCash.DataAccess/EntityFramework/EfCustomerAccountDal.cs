using System;
using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.DataAccess.Repositories;
using EasyCash.Entity.Concrete;

namespace EasyCash.DataAccess.EntityFramework;

public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
{
    public EfCustomerAccountDal(Context context) : base(context)
    {
    }

    public List<CustomerAccount> GetCustomerAccountsList(int id)
    {
        using var context = new Context();
        var values = context.CustomerAccounts.Where(x => x.AppUserID == id).ToList();
        return values;
    }
}
