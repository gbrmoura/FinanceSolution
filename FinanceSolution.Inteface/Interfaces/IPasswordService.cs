namespace FinanceSolution.Inteface.Interfaces
{
    public interface IPasswordService
    {
        public string EncryptPassword(string password);

        public bool VerifyPassword(string password, string hashPassword);

        public bool ComparePassword(string password, string confirmPassword);

    }
}
