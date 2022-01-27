namespace ciclosjobs.Core.Security
{
    public interface IPasswordGenerator
    {
        public string Hash(string password);
    }
}