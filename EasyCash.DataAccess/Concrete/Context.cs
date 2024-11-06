using System;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.DataAccess.Concrete;

public class Context : IdentityDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=LAPTOP-0PGAT8H5\\SQLEXPRESS; initial catalog=EasyCashDb; integrated security=true; TrustServerCertificate=True");
    }


    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
}
