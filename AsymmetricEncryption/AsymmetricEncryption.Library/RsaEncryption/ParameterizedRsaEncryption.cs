using System.Security.Cryptography;

namespace AsymmetricEncryption.Library
{
    public class ParameterizedRsaEncryption
    {
        #region Private Fields

        RSAParameters _publicKey;
        RSAParameters _privateKey;

        #endregion

        #region Constructors

        public ParameterizedRsaEncryption()
        {

        }

        #endregion

        #region Public Methods

        public void AsignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] chiperBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);

                chiperBytes = rsa.Encrypt(data, true);
            }

            return chiperBytes;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] chiperBytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_privateKey);

                chiperBytes = rsa.Decrypt(data, true);
            }

            return chiperBytes;
        }

        #endregion
    }
}
