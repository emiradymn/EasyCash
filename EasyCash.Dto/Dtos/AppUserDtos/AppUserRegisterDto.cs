using System;

namespace EasyCash.Dto.Dtos.AppUserDtos;

public class AppUserRegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string EMail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
