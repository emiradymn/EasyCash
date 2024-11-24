using System;
using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Abstract;
using EasyCash.Entity.Concrete;

namespace EasyCash.Business.Concrete;

public class CustomerAccountProcessManager : ICustomerAccountProcessService
{
    private readonly ICustomerAccountProcessDal _customerAccountProcessDal;
    public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
    {
        _customerAccountProcessDal = customerAccountProcessDal;

    }
    public void TDelete(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Delete(t);
    }

    public CustomerAccountProcess TGetByID(int id)
    {
        return _customerAccountProcessDal.GetByID(id);
    }

    public List<CustomerAccountProcess> TGetList()
    {
        return _customerAccountProcessDal.GetList();
    }

    public void TInsert(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Insert(t);
    }

    public List<CustomerAccountProcess> TMyLastProcess(int id)
    {
        return _customerAccountProcessDal.MyLastProcess(id);
    }

    public void TUpdate(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Update(t);
    }
}
