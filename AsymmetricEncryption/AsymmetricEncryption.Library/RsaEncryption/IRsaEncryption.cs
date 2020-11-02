using System.Security.Cryptography;

namespace AsymmetricEncryption.Library
{
    public interface IRsaEncryption
    {
        RSAParameters PrivateRsaParameters { get; }
        RSAParameters PublicRsaParameters { get; }

        void AsignNewKey();
        byte[] Decrypt(byte[] data);
        byte[] Encrypt(byte[] data);

        byte[] Encrypt(byte[] data, byte[] exponent, byte[] modulus);
    }
}