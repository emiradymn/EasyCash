using System;

namespace EasyCash.Entity.Concrete;

public class CustomerAccountProcess
{
    public int CustomerAccountProcessID { get; set; }
    public string ProcessType { get; set; }
    public decimal Amount { get; set; }
    public DateTime ProcessDate { get; set; }
}
