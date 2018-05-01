namespace SSO.Service.Interface
{
    public interface ICryptographyService
    {
        string Encrypt(string data);
        string Decrypt(string cipherText);
    }
}
