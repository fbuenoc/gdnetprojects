namespace WebFrameworkMapping.Constants
{
    public sealed class MappingConstants
    {
        public const string ApplicationId = "ApplicationId";
        public const string ContentItemId = "ContentItemId";
        public const string ContentTypeId = "ContentTypeId";
        public const string DescriptionTranslationId = "DescriptionTranslationId";
        public const string DetailTranslationId = "DetailTranslationId";
        public const string NameTranslationId = "NameTranslationId";
        public const string StatutLifeCycleId = "StatutLifeCycleId";

        public sealed class Application
        {
            public const string CategoryId = "CategoryId";
            public const string CultureDefaultId = "CultureDefaultId";
        }

        public sealed class ContentAttribute
        {
            public const string DataTypeId = "DataTypeId";
        }

        public sealed class ContentItemAttributeValue
        {
            public const string ContentAttributeId = "ContentAttributeId";
            public const string ValueTranslationId = "ValueTranslationId";
            public const string ContentItemAttributeValueTable = "ContentItemAttributeValue";
        }

        public sealed class ContentItem
        {
            public const string RelationContentItemId = "RelationContentItemId";
            public const string ContentItemRelationTable = "ContentItemRelation";
        }

        public sealed class ListValue
        {
            public const string ParentId = "ParentId";
        }

        public sealed class Temporary
        {
            public const string EncryptionTypeId = "EncryptionTypeId";
        }

        public sealed class Translation
        {
            public const string CultureId = "CultureId";
            public const string CategoryId = "CategoryId";
        }

        public sealed class StatutLog
        {
            public const string StatutId = "StatutId";
        }

        public sealed class StatutLifeCycle
        {
            public const string ActualStatutId = "ActualStatutId";
        }
    }
}
