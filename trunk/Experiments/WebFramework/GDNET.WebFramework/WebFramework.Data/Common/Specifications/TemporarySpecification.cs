using System;
using GDNET.Common.DesignByContract;
using GDNET.Common.Security.Services;
using WebFramework.Domain;
using WebFramework.Domain.Base;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.Data.Common.Specifications
{
    public class TemporarySpecification : GenericSpecification<Temporary, Guid>
    {
        public override bool OnSaving(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be encrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                EncryptionOption option = this.GetEncryptionOption(entity.EncryptionType);
                entity.Text = DomainServices.Encryption.Encrypt(entity.Text, option);
            }

            return base.OnSaving(entity);
        }

        public override bool OnGotten(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be decrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                EncryptionOption option = this.GetEncryptionOption(entity.EncryptionType);
                entity.Text = DomainServices.Encryption.Decrypt(entity.Text, option);
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
                    case ListValueConstants.EncryptionTypes.None:
                        option = EncryptionOption.None;
                        break;

                    case ListValueConstants.EncryptionTypes.Base64:
                        option = EncryptionOption.Base64;
                        break;

                    case ListValueConstants.EncryptionTypes.AES:
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
