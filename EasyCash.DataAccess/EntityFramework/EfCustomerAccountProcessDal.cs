using System;
using EasyCash.DataAccess.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.DataAccess.Repositories;
using EasyCash.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.DataAccess.EntityFramework;

public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
{
    public EfCustomerAccountProcessDal(Context context) : base(context)
    {
    }

    public List<CustomerAccountProcess> MyLastProcess(int id)
    {
        using var context = new Context();
        var values = context.CustomerAccountProcesses
            .Include(y => y.SenderCustomer).ThenInclude(z => z.AppUser)
            .Include(w => w.ReceiverCustomer).ThenInclude(z => z.AppUser)
            .Where(x => x.ReceiverID == id || x.SenderID == id)
            .ToList();
        return values;
    }
}
