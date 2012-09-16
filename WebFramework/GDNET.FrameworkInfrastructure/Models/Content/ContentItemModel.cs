using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Content;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.Extensions;

namespace GDNET.FrameworkInfrastructure.Models.Content
{
    public class ContentItemModel : AbstractViewModel<ContentItem>
    {
        private List<ContentPartModel> parts = new List<ContentPartModel>();

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

        public ReadOnlyCollection<ContentPartModel> Parts
        {
            get { return new ReadOnlyCollection<ContentPartModel>(this.parts); }
        }

        public override void Initialize(ContentItem entity)
        {
            base.Id = entity.Id.ToString();
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Keywords = entity.Keywords;
            this.IsActive = entity.IsActive;

            this.parts.Clear();
            this.parts.AddRange(FrameworkExtensions.ConvertAll<ContentPartModel, ContentPart>(entity.Parts));

            base.InitializeCommon(entity);
        }
    }
}
