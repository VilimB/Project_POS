using Backend_POS.Models.DbSet;

namespace Backend_POS.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
