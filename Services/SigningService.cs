using System.Security.Cryptography;
using System.Text;

namespace OrdersApi.Services;

public class SigningService
{
    private const string SigningKey = "demo-signing-key-7c1e0f93b2a84d5e";

    public string Sign(string payload)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SigningKey));
        return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(payload)));
    }
}
