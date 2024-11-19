using System;
using EasyCash.Dto.Dtos.AppUserDtos;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Security;


namespace EasyCash.Presentation.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
    {
        if (ModelState.IsValid)
        {
            Random random = new Random();
            int code;
            code = random.Next(1000000, 10000000);
            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.Username,
                Email = appUserRegisterDto.Email,
                Name = appUserRegisterDto.Name,
                Surname = appUserRegisterDto.Surname,
                District = "aaa",
                City = "bbb",
                ImageUrl = "ccc",
                ConfirmCode = code
            };
            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                // MimeMessage oluştur
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("EasyCash Admin", "emiradymn4444@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code
                };
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "EasyCash Onay Kodu";


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("emiradymn4444@gmail.com", "ngniggzwoasruvep");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                TempData["Mail"] = appUserRegisterDto.Email;

                return RedirectToAction("Index", "ConfirmMail");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return View();

    }
}
