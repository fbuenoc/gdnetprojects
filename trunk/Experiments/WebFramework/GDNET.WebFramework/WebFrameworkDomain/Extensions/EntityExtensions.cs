﻿using GDNET.Common.Base;
using GDNET.Common.DesignByContract;
using GDNET.Common.Helpers;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Extensions
{
    public static class EntityExtensions
    {
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
                attributeValue.RefreshTranslation(attributeValue.Value, ExpressionAssistant.GetPropertyName(() => attributeValue.Value));
            }
        }

        public static void RefreshTranslation(this ContentItemAttributeValue entity)
        {
            entity.RefreshTranslation(entity.Value, ExpressionAssistant.GetPropertyName(() => entity.Value));
        }

        public static void RefreshTranslation(this ContentType entity)
        {
            entity.RefreshTranslation(entity.Name, ExpressionAssistant.GetPropertyName(() => entity.Name));
        }

        public static void RefreshTranslation(this ListValue entity)
        {
            entity.RefreshTranslation(entity.Description, ExpressionAssistant.GetPropertyName(() => entity.Description));
        }

        public static void RefreshTranslation(this ISignature entity, Translation translation, string propertyName)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Entity name can not be null.");
            ThrowException.ArgumentNullException(translation, "translation", "Translation can not be null.");
            ThrowException.ArgumentExceptionIfNullOrEmpty(propertyName, "propertyName", "The property name can not be null.");

            translation.Code = string.Format("{0}_{1}", entity.Signature, propertyName);
        }
    }
}