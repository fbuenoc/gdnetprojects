namespace GDNET.Common.Security.Services
{
    public enum EncryptionOption
    {
        None = 0,
        Base64 = 1,
        AES = 2,
    }

    public interface IEncryptionService
    {
        string Encrypt(string data, EncryptionOption option);
        string Decrypt(string data, EncryptionOption option);
    }
}
