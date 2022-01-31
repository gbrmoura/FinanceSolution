using FinanceSolution.Inteface.Interfaces;

namespace FinanceSolution.Inteface.Services
{
    public class PasswordService : IPasswordService
    {
        public string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        public bool ComparePassword(string password, string confirmPassword)
        {
            return password.Trim().Equals(confirmPassword.Trim());
        }
   
    }
}
