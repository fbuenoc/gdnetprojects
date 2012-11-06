using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.Extensions;
using KnowledgeSharing.Domain.Entities;

namespace GreatApp.Infrastructure.Models
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

        [DisplayNameML("GUI.ContentItem.Language")]
        public string Language
        {
            get;
            set;
        }

        public ReadOnlyCollection<ContentPartModel> Parts
        {
            get { return new ReadOnlyCollection<ContentPartModel>(this.parts); }
        }

        public override void Initialize(ContentItem entity, bool filterActiveOnly)
        {
            base.Id = entity.Id.ToString();
            this.Name = entity.Name;
            this.Description = entity.Description;
            this.Keywords = entity.Keywords;
            this.Language = entity.Language.Code;

            this.parts.Clear();
            this.parts.AddRange(FrameworkExtensions.ConvertAll<ContentPartModel, ContentPart>(entity.Parts, filterActiveOnly));

            base.InitializeCommon(entity);
        }
    }
}
