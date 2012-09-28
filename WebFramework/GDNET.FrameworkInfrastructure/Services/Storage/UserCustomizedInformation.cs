using System;

namespace GDNET.FrameworkInfrastructure.Services.Storage
{
    public class UserCustomizedInformation
    {
        public bool ApplyForUI
        {
            get;
            private set;
        }

        public string Language
        {
            get;
            private set;
        }

        public UserCustomizedInformation(string serialized)
        {
            if (!string.IsNullOrEmpty(serialized))
            {
                var infos = serialized.Split('|');
                this.Language = infos[0];
                this.ApplyForUI = Convert.ToBoolean(infos[1]);
            }
        }

        public UserCustomizedInformation(string language, bool applyForUI)
        {
            this.Language = language;
            this.ApplyForUI = applyForUI;
        }

        public string Serialize()
        {
            return string.Format("{0}|{1}", this.Language, this.ApplyForUI);
        }
    }
}
