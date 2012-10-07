using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Entities.System;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public class AccountUpdateDetailsModel : AbstractViewModel<User>
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DisplayNameML("GUI.User.DisplayName")]
        public string DisplayName { get; set; }

        [DisplayNameML("GUI.User.Introduction")]
        public string Introduction { get; set; }

        [Required]
        [DisplayNameML("GUI.User.Language")]
        public string Language { get; set; }

        public override void Initialize(User entity, bool filterActiveOnly)
        {
            base.Id = entity.Id.ToString();
            this.DisplayName = entity.DisplayName;
            this.Introduction = entity.Introduction;
            this.Language = (entity.Language == null) ? string.Empty : entity.Language.Code;

            base.InitializeCommon(entity);
        }
    }
}
