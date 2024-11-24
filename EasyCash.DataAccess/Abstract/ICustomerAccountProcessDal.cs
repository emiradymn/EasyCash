using System;
using EasyCash.Entity.Concrete;

namespace EasyCash.DataAccess.Abstract;

public interface ICustomerAccountProcessDal : IGenericDal<CustomerAccountProcess>
{
    List<CustomerAccountProcess> MyLastProcess(int id);
}
