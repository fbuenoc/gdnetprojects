using GDNET.Business.Services.Impl.Security;
using GDNET.Business.Services.System;
using GDNET.Domain.Services;
using GDNET.Domain.Services.Security;
using GDNET.Domain.Services.System;

namespace GDNET.Business.Services
{
    public class ServicesManager : DomainServices
    {
        public ServicesManager()
            : base()
        {
            base.Initialize(this);
        }

        protected override IEncryptionService GetEncryptionService()
        {
            return new EncryptionService(EncryptionOption.AES);
        }

        protected override IContentBonusService GetContentBonusService()
        {
            return new ContentBonusService();
        }
    }
}
