using GDNET.Common.Base;
using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.NHibernateImpl.Listeners;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkData.Common.Listeners
{
    public sealed class WebFrameworkSaveEventListener : NhSaveEventListenerBase
    {
        protected override void PerformSaving(object entity)
        {
            if (entity is IEntityCreMod)
            {
                DataService.SetCreationInfo((IEntityCreMod)entity);
            }
        }

        protected override void PerformSaved(object entity)
        {
            if (entity is Application)
            {
                this.PerformSavedApplication((Application)entity);
            }
            else if (entity is ContentAttribute)
            {
                this.PerformSavedContentAttribute((ContentAttribute)entity);
            }
            else if (entity is ContentItem)
            {
                this.PerformSavedContentItem((ContentItem)entity);
            }
            else if (entity is ContentItemAttributeValue)
            {
                this.PerformSavedContentItemAttributeValue((ContentItemAttributeValue)entity);
            }
            else if (entity is ContentType)
            {
                this.PerformSavedContentType((ContentType)entity);
            }
            else if (entity is Culture)
            {
                this.PerformSavedCulture((Culture)entity);
            }
            else if (entity is ListValue)
            {
                this.PerformSavedListValue((ListValue)entity);
            }
            else if (entity is Temporary)
            {
                this.PerformSavedTemporary((Temporary)entity);
            }
            else if (entity is Translation)
            {
                this.PerformSavedTranslation((Translation)entity);
            }
        }

        private void PerformSavedContentItemAttributeValue(ContentItemAttributeValue entity)
        {
            entity.RefreshTranslation(entity.Value, ExpressionUtil.GetPropertyName(() => entity.Value));
        }

        private void PerformSavedTranslation(Translation entity)
        {
        }

        private void PerformSavedTemporary(Temporary entity)
        {
        }

        private void PerformSavedListValue(ListValue entity)
        {
            entity.RefreshTranslation(entity.Description, ExpressionUtil.GetPropertyName(() => entity.Description));
        }

        private void PerformSavedCulture(Culture entity)
        {
        }

        private void PerformSavedContentType(ContentType entity)
        {
            entity.RefreshTranslation(entity.Name, ExpressionUtil.GetPropertyName(() => entity.Name));
        }

        private void PerformSavedContentItem(ContentItem entity)
        {
            entity.RefreshTranslation(entity.Name, ExpressionUtil.GetPropertyName(() => entity.Name));
            entity.RefreshTranslation(entity.Description, ExpressionUtil.GetPropertyName(() => entity.Description));

            foreach (var attributeValue in entity.AttributeValues)
            {
                attributeValue.RefreshTranslation(attributeValue.Value, ExpressionUtil.GetPropertyName(() => attributeValue.Value));
            }
        }

        private void PerformSavedContentAttribute(ContentAttribute entity)
        {
        }

        private void PerformSavedApplication(Application entity)
        {
            //entity.RefreshTranslation(entity.Name, ExpressionUtil.GetPropertyName(() => entity.Name));
            //entity.RefreshTranslation(entity.Description, ExpressionUtil.GetPropertyName(() => entity.Description));
        }
    }
}

