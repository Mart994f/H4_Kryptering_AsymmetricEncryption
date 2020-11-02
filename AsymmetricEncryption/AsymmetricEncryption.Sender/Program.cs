using AsymmetricEncryption.Library;
using System;

namespace AsymmetricEncryption.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
           RsaEncryptionService encryptionService = new RsaEncryptionService();
            string exponent;
            string modulus;
            string message;

            Console.Write($"Input Exponent: ");
            exponent = Console.ReadLine();

            Console.Write($"\nInput Modulus: ");
            modulus = Console.ReadLine();

            Console.Write($"\nInput Message: ");
            message = Console.ReadLine();

            Console.WriteLine($"\nEncrypted Message: {encryptionService.Encrypt(message, exponent, modulus)}");
            Console.ReadLine();
        }
    }
}
