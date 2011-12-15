using Elixis;
using Elixis.EncryptionOptions;

using GDNET.Common.Security.Services;
using GDNET.Common.DesignByContract;
using GDNET.Extensions;

namespace GDNET.Common.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private readonly AESEncryptor elixisAESEncryptor = null;
        private static readonly string defaultPassword = "GDNET";

        #region Ctors

        public EncryptionService()
            : this(defaultPassword)
        {
        }

        public EncryptionService(string password)
        {
            ThrowException.ArgumentNullException(password, "password", "Password can not be enpty.");
            this.elixisAESEncryptor = new AESEncryptor(password, AESBits.BITS128);
        }

        #endregion

        /// <summary>
        /// Encrypts a string
        /// </summary>
        public string Encrypt(string sourceData, EncryptionOption option)
        {
            switch (option)
            {
                case EncryptionOption.Base64:
                    return Base64String.Encrypt(sourceData);

                case EncryptionOption.AES:
                    return this.elixisAESEncryptor.Encrypt(sourceData);

                case EncryptionOption.None:
                    return sourceData;

                default:
                    ThrowException.NotImplementedException(string.Format("Not implemented for option: {0}", option.ToString()));
                    return string.Empty;
            }
        }

        /// <summary>
        /// Descripts a encripted string
        /// </summary>
        public string Decrypt(string encryptedData, EncryptionOption option)
        {
            switch (option)
            {
                case EncryptionOption.Base64:
                    return Base64String.Decrypt(encryptedData);

                case EncryptionOption.AES:
                    return this.elixisAESEncryptor.Decrypt(encryptedData);

                case EncryptionOption.None:
                    return encryptedData;

                default:
                    ThrowException.NotImplementedException(string.Format("Not implemented for option: {0}", option.ToString()));
                    return string.Empty;
            }
        }
    }
}
