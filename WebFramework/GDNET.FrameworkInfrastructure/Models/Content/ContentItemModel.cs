using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Content;
using GDNET.FrameworkInfrastructure.Common.Base;

namespace GDNET.FrameworkInfrastructure.Models.Content
{
    public class ContentItemModel : AbstractModel<ContentItem>
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name
        {
            get;
            set;
        }

        [Display(Name = "Description")]
        public string Description
        {
            get;
            set;
        }

        [Display(Name = "Keywords")]
        public string Keywords
        {
            get;
            set;
        }

        public override void Initialize(ContentItem entity)
        {
            if (entity != null)
            {
                base.Id = entity.Id.ToString();
                this.Name = entity.Name;
                this.Description = entity.Description;
                this.Keywords = entity.Keywords;
            }
        }
    }
}
