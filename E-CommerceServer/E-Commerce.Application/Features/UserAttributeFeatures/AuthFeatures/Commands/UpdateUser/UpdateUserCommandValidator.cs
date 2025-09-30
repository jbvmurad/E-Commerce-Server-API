using FluentValidation;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;

public sealed class UpdateUserCommandValidator :AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0).WithMessage("Invalid category ID.");

        RuleFor(x => x.FirstName)
            .Length(2, 100).WithMessage("First name must be between 2 and 100 characters.");

        RuleFor(x => x.LastName)
            .Length(2, 100).WithMessage("Last name must be between 2 and 50 characters.");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("Email format must be: user@domain.com")
            .EmailAddress().WithMessage("Email is not valid.")
            .Length(5, 254).WithMessage("Email must be between 5 and 254 characters.")
            .Must(BeFromTrustedProvider).WithMessage("Please use a trusted email provider.")
            .Must(NotBeDisposableEmail).WithMessage("Temporary email addresses are not allowed.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
    }
    private bool BeFromTrustedProvider(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        var trustedProviders = new[]
        {
            "gmail.com", "googlemail.com",
            "outlook.com", "hotmail.com", "live.com", "msn.com",
            "yahoo.com", "yahoo.co.uk", "yahoo.fr", "yahoo.ca", "yahoo.de", "ymail.com",
            "aol.com", "icloud.com", "me.com", "mac.com",

            "yandex.com", "yandex.ru", "mail.ru", "rambler.ru",
            "web.de", "gmx.de", "gmx.net", "t-online.de",
            "orange.fr", "free.fr", "laposte.net", "sfr.fr",
            "libero.it", "virgilio.it", "tiscali.it", "alice.it",
            "terra.com.br", "uol.com.br", "bol.com.br",
            "163.com", "126.com", "qq.com", "sina.com",
            "naver.com", "daum.net", "hanmail.net",
            "rediffmail.com", "sify.com",

            "protonmail.com", "proton.me", "pm.me",
            "tutanota.com", "tuta.io",
            "fastmail.com", "hushmail.com",
            "zoho.com", "mail.com"
        };

        var domain = email.Split('@').LastOrDefault()?.ToLower();
        return trustedProviders.Contains(domain);
    }

    private bool NotBeDisposableEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        var disposableDomains = new[]
        {
            "10minutemail.com", "10minutemail.net", "10minutemail.co.za",
            "tempmail.org", "temp-mail.org", "tempmail.net", "temp-mail.io",
            "mailinator.com", "mailinator2.com", "mailinator.net",
            "guerrillamail.com", "guerrillamail.de", "guerrillamail.net",
            "trashmail.com", "trashmail.de", "trashmail.net",
            "throwaway.email", "throwaway.life",
            "getnada.com", "maildrop.cc",
            "sharklasers.com", "grr.la", "guerrillamailblock.com",
            "mailcatch.com", "yopmail.com", "yopmail.fr",
            "fakeinbox.com", "spamgourmet.com",
            "mailnesia.com", "e4ward.com",
            "emailondeck.com", "deadaddress.com",
            "mytrashmail.com", "mohmal.com",
            "emailias.com", "mailexpire.com",
            "dispostable.com", "spambog.com",
            "tempinbox.com", "mailtemp.info",
            "getairmail.com", "anonymbox.com",
            "burnermail.io", "guerrillamail.org",
            "incognitomail.org", "tempail.com",
            "throwawaymail.com", "tempmailo.com",
            "mailtemp.co", "temp-mail.de",
            "disposablemail.com", "spambox.us",
            "mailcatch.com", "mailpick.biz",
            "mailzilla.com", "spamfree24.org",
            "tempinbox.net", "temporaryemail.us"
        };

        var domain = email.Split('@').LastOrDefault()?.ToLower();
        return !disposableDomains.Contains(domain);
    }
}
