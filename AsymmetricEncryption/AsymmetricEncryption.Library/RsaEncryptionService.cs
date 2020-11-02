using System;
using System.Text;

namespace AsymmetricEncryption.Library
{
    public class RsaEncryptionService
    {
        #region Private Fields

        private IRsaEncryption _rsaEncryption = new CspRsaEncryption();

        #endregion

        #region Public Properties

        public IRsaEncryption RsaEncryption { get { return _rsaEncryption; } }

        #endregion

        #region Public Methods

        public void AsignKeys()
        {
            _rsaEncryption.AsignNewKey();
        }

        public string Encrypt(string data)
        {
            return BitConverter.ToString(_rsaEncryption.Encrypt(Encoding.UTF8.GetBytes(data)));
        }

        public string Encrypt(string data, string exponent, string modulus)
        {
            return Convert.ToBase64String(_rsaEncryption.Encrypt(Encoding.UTF8.GetBytes(data),Convert.FromBase64String(exponent), Convert.FromBase64String(modulus)));
        }

        public string Decrypt(string data)
        {
            string[] arr = data.Split('-');
            byte[] dataBytes = new byte[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                dataBytes[i] = Convert.ToByte(arr[i], 16);
            }

            return Encoding.UTF8.GetString(_rsaEncryption.Decrypt(dataBytes));
        }

        #endregion
    }
}
