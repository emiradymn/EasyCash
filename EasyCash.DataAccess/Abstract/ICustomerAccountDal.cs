using System;
using EasyCash.Entity.Concrete;

namespace EasyCash.DataAccess.Abstract;

public interface ICustomerAccountDal : IGenericDal<CustomerAccount>
{
    List<CustomerAccount> GetCustomerAccountsList(int id);
}
