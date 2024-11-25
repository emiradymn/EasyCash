using System;
using EasyCash.Entity.Concrete;

namespace EasyCash.Business.Abstract;

public interface ICustomerAccountService : IGenericService<CustomerAccount>
{
    List<CustomerAccount> TGetCustomerAccountsList(int id);

}
