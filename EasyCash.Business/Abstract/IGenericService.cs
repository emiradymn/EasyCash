using System;

namespace EasyCash.Business.Abstract;

public interface IGenericService<T> where T : class
{
    void TInsert(T t);
    void TDelete(T t);
    void TUpdate(T t);
    T TGetByID(int id);
    List<T> TGetList();
}
