using AsymmetricEncryption.Library;
using System;

namespace AsymmetricEncryption.Reciver
{
    class Program
    {
        static void Main(string[] args)
        {
            RsaEncryptionService encryptionService = new RsaEncryptionService();
            string message;

            Console.WriteLine("RSA Public Key");
            Console.WriteLine($"\nExponent: {Convert.ToBase64String(encryptionService.RsaEncryption.PublicRsaParameters.Exponent)}");
            Console.WriteLine($"\nModulus: {Convert.ToBase64String(encryptionService.RsaEncryption.PublicRsaParameters.Modulus)}");

            Console.Write($"\nInput Encrypted Message: ");
            message = Console.ReadLine();

            Console.WriteLine($"\nDecrypted Message: {encryptionService.Decrypt(message)}");
            Console.ReadLine();
        }
    }
}
