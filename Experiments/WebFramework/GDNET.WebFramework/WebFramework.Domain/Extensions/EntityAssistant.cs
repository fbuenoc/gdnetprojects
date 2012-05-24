﻿using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using GDNET.Common.Helpers;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Extensions
{
    public static class EntityAssistant
    {
        #region IEntityWithModification

        /// <summary>
        /// If the entity is in-active, it's also can not be viewable.
        /// </summary>
        public static void ChangeActive(this IEntityWithModification entity, bool isActive)
        {
            entity.IsActive = isActive;
        }

        /// <summary>
        /// If the entity is not editable, it's also can not be deleable.
        /// </summary>
        public static void ChangeEditable(this IEntityWithModification entity, bool isEditable)
        {
            entity.IsEditable = isEditable;
            if (!isEditable)
            {
                entity.IsDeletable = false;
            }
        }

        public static void ChangeDeletable(this IEntityWithModification entity, bool isDeletable)
        {
            entity.IsDeletable = isDeletable;
        }

        #endregion

        public static void RefreshTranslation(this Application entity)
        {
            entity.RefreshTranslation(entity.Description, ExpressionAssistant.GetPropertyName(() => entity.Description));
            entity.RefreshTranslation(entity.Name, ExpressionAssistant.GetPropertyName(() => entity.Name));
        }

        public static void RefreshTranslation(this ContentItem entity)
        {
            entity.RefreshTranslation(entity.Description, ExpressionAssistant.GetPropertyName(() => entity.Description));
            entity.RefreshTranslation(entity.Name, ExpressionAssistant.GetPropertyName(() => entity.Name));

            foreach (var attributeValue in entity.AttributeValues)
            {
                attributeValue.RefreshTranslation(attributeValue.ValueTranslation, ExpressionAssistant.GetPropertyName(() => attributeValue.ValueTranslation));
            }
        }

        public static void RefreshTranslation(this ContentItemAttributeValue entity)
        {
            entity.RefreshTranslation(entity.ValueTranslation, ExpressionAssistant.GetPropertyName(() => entity.ValueTranslation));
        }

        public static void RefreshTranslation(this ContentType entity)
        {
            entity.RefreshTranslation(entity.Name, ExpressionAssistant.GetPropertyName(() => entity.Name));
        }

        public static void RefreshTranslation(this ListValue entity)
        {
            entity.RefreshTranslation(entity.Description, ExpressionAssistant.GetPropertyName(() => entity.Description));
        }

        public static void RefreshTranslation(this IEntityBase entity, Translation translation, string propertyName)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Entity name can not be null.");
            ThrowException.ArgumentNullException(translation, "translation", "Translation can not be null.");
            ThrowException.ArgumentExceptionIfNullOrEmpty(propertyName, "propertyName", "The property name can not be null.");

            translation.Code = string.Format("{0}_{1}", entity.Signature, propertyName);
        }
    }
}