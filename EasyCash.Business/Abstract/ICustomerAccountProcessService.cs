using System;
using EasyCash.Entity.Concrete;

namespace EasyCash.Business.Abstract;

public interface ICustomerAccountProcessService : IGenericService<CustomerAccountProcess>
{
    List<CustomerAccountProcess> TMyLastProcess(int id);
}
