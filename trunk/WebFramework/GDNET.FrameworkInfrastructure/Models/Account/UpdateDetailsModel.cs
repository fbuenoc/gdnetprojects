using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Entities.System;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class UpdateDetailsModel : AbstractViewModel<User>
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DisplayNameML("GUI.UpdateDetailsModel.DisplayName")]
        public string DisplayName { get; set; }

        public override void Initialize(User entity)
        {
            if (entity != null)
            {
                this.DisplayName = entity.DisplayName;
            }
        }
    }
}
