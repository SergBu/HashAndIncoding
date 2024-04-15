using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash;

public class HashByteArray
{
    public static string GetPhoneHash(string phoneManager)
    {
        phoneManager = phoneManager
            .Replace("(", "")
            .Replace(")", "")
            .Replace("-", "");

        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(phoneManager));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString());
        }
        return builder.ToString().Substring(0, 40);
    }


    private string HashData(Entity entity)
    {
        var hashString = String.Concat(entity.Id, entity.Type, entity.IsPositive);
        StringBuilder Sb = new StringBuilder();

        using (SHA256 hash = SHA256.Create()) //хэш функция
        {
            Encoding enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(hashString)); //массив байтов

            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));
        }
        return Sb.ToString();
    }

    public string CalculateMD5Hash(string input)
    {

        // Primeiro passo, calcular o MD5 hash a partir da string
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // Segundo passo, converter o array de bytes em uma string haxadecimal
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
