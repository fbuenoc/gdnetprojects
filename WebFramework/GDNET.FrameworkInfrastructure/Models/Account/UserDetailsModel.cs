using GDNET.Domain.Entities.System;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public enum UserDetailsMode
    {
        Basic,
        Medium,
    }

    public class UserDetailsModel : AbstractViewModel<User>
    {
        [DisplayNameML("GUI.User.Email")]
        public string Email { get; set; }

        [DisplayNameML("GUI.User.DisplayName")]
        public string DisplayName { get; set; }

        [DisplayNameML("GUI.User.Introduction")]
        public string Introduction { get; set; }

        public UserDetailsMode DisplayMode
        {
            get;
            set;
        }

        public UserDetailsModel()
            : base()
        {
            this.DisplayMode = UserDetailsMode.Basic;
        }

        public override void Initialize(User entity, bool filterActiveOnly)
        {
            base.Id = entity.Id.ToString();
            this.DisplayName = entity.DisplayName;
            this.Introduction = entity.Introduction;

            base.InitializeCommon(entity);
        }
    }
}
