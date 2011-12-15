using System;

using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.Common.DesignByContract;
using GDNET.Common.Encryption;
using GDNET.Common.Security.Services;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationTemporary : NHSpecificationBase<Temporary, string>
    {
        private readonly IEncryptionService encryptor = new EncryptionService();

        public override bool OnSaving(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be encrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                EncryptionOption option = this.GetEncryptionOption(entity.EncryptionType);
                entity.Text = this.encryptor.Encrypt(entity.Text, option);
            }

            return base.OnSaving(entity);
        }

        public override bool OnGotten(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be decrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                EncryptionOption option = this.GetEncryptionOption(entity.EncryptionType);
                entity.Text = this.encryptor.Decrypt(entity.Text, option);
            }

            return base.OnGotten(entity);
        }

        private EncryptionOption GetEncryptionOption(ListValue encryptionType)
        {
            ThrowException.ArgumentNullException(encryptionType, "encryptionType", "Encryption type is invalid.");
            EncryptionOption option = EncryptionOption.None;

            if (encryptionType != null)
            {
                // Do NOTHING in case of encryption = None
                switch (encryptionType.Name)
                {
                    case ListValueConstants.EncryptionTypes_None:
                        option = EncryptionOption.None;
                        break;

                    case ListValueConstants.EncryptionTypes_Base64:
                        option = EncryptionOption.Base64;
                        break;

                    case ListValueConstants.EncryptionTypes_AES:
                        option = EncryptionOption.AES;
                        break;

                    default:
                        ThrowException.NotSupportedException(string.Format("The encryption type: '{0}' is not supported.", encryptionType.Name));
                        break;
                }
            }

            return option;
        }
    }
}
