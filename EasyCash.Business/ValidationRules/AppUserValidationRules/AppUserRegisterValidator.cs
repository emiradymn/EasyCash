using System;
using System.Data;
using EasyCash.Dto.Dtos.AppUserDtos;
using EasyCash.Entity.Concrete;
using FluentValidation;

namespace EasyCash.Business.ValidationRules.AppUserValidationRules;

public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş bırakılamaz");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz");
        RuleFor(x => x.EMail).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş bırakılamaz");

        RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
        RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreleriniz eşleşmiyor.");
        RuleFor(x => x.EMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
    }
}
