using System;

using GDNET.Common.Data;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using GDNET.Extensions;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Constants;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationTemporary : NHSpecificationBase<Temporary, string>
    {
        public override bool OnSaving(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be encrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                switch (entity.EncryptionType.Name)
                {
                    // Do NOTHING in case of encryption = None
                    case ListValueConstants.EncryptionTypes_None:
                        return true;

                    case ListValueConstants.EncryptionTypes_Base64:
                        entity.Text = Base64String.Encrypt(entity.Text);
                        break;

                    default:
                        Throw.NotSupportedException(string.Format("The encryption type: '{0}' is not supported.", entity.EncryptionType.Name));
                        return false;
                }
            }

            return base.OnSaving(entity);
        }

        public override bool OnGotten(Temporary entity)
        {
            // In case of creating new Temporary, its Value must be decrypt based on selected encoding.
            if (entity.EncryptionType != null)
            {
                switch (entity.EncryptionType.Name)
                {
                    // Do NOTHING in case of encryption = None
                    case ListValueConstants.EncryptionTypes_None:
                        return true;

                    case ListValueConstants.EncryptionTypes_Base64:
                        entity.Text = Base64String.Decrypt(entity.Text);
                        break;

                    default:
                        Throw.NotSupportedException(string.Format("The encryption type: '{0}' is not supported.", entity.EncryptionType.Name));
                        return false;
                }
            }

            return base.OnGotten(entity);
        }
    }
}
