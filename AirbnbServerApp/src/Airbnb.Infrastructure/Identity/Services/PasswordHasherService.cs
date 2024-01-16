using Airbnb.Application.Common.Identity.Services.Interfaces;
using BC=BCrypt.Net.BCrypt;

namespace Airbnb.Infrastructure.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}