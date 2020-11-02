using System.Security.Cryptography;

namespace AsymmetricEncryption.Library
{
    public class CspRsaEncryption : IRsaEncryption
    {
        #region Private Fields

        private string containerName = "RsaKeyContainer";

        private RSACryptoServiceProvider _cryptoServiceProvider;

        #endregion

        #region Public Properties

        public RSAParameters PublicRsaParameters { get { return _cryptoServiceProvider.ExportParameters(false); } }

        public RSAParameters PrivateRsaParameters { get { return _cryptoServiceProvider.ExportParameters(true); } }

        #endregion

        #region Constructors

        public CspRsaEncryption()
        {
            CspParameters cspParmeters = new CspParameters { KeyContainerName = containerName };
            _cryptoServiceProvider = new RSACryptoServiceProvider(2048, cspParmeters);
        }

        #endregion

        #region Public Methods

        public void AsignNewKey()
        {
            CspParameters cspParameters = new CspParameters(1);
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParameters.ProviderName = "Microsoft Strong Cryptographic Provider";
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] chiperBytes;

            using (_cryptoServiceProvider)
            {
                chiperBytes = _cryptoServiceProvider.Encrypt(data, false);
            }

            return chiperBytes;
        }

        public byte[] Encrypt(byte[] data, byte[] exponent, byte[] modulus)
        {
            byte[] chiperBytes;

            using (var rsa = new RSACryptoServiceProvider())
            {
                RSAParameters rSAParameters = new RSAParameters();
                rSAParameters.Exponent = exponent;
                rSAParameters.Modulus = modulus;
                rsa.ImportParameters(rSAParameters);

                chiperBytes = rsa.Encrypt(data, false);
            }

            return chiperBytes;
        }

        public byte[] Decrypt(byte[] data)
        {
            byte[] chiperBytes;

            using (_cryptoServiceProvider)
            {
                chiperBytes = _cryptoServiceProvider.Decrypt(data, true);
            }

            return chiperBytes;
        }

        #endregion
    }
}
