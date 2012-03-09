namespace WebFrameworkDomain.Constants
{
    public sealed class ListValueConstants
    {
        public sealed class EncryptionTypes
        {
            public const string Root = "LV.EncryptionTypes";
            public const string None = "LV.EncryptionTypes.None";
            public const string Base64 = "LV.EncryptionTypes.Base64";
            public const string AES = "LV.EncryptionTypes.AES";
        }

        public sealed class ContentDataTypes
        {
            public const string Root = "LVH.ContentDataTypes";
            public const string TextSimpleTextBox = "LVH.ContentDataTypes.Text.SimpleTextBox";
            public const string TextPasswordTextBox = "LVH.ContentDataTypes.Text.PasswordTextBox";
            public const string TextTextArea = "LVH.ContentDataTypes.Text.TextArea";
            public const string TextHtmlEditor = "LVH.ContentDataTypes.Text.HtmlEditor";
            public const string TextUrl = "LVH.ContentDataTypes.Text.Url";
            public const string NumberPercentage = "LVH.ContentDataTypes.Number.Percentage";
            public const string NumberNormalNumber = "LVH.ContentDataTypes.Number.NormalNumber";
            public const string DateTimeFullDateTime = "LVH.ContentDataTypes.DateTime.FullDateTime";
        }

        public sealed class ApplicationCategories
        {
            public const string Root = "LV.ApplicationCategories";
            public const string Default = "LV.ApplicationCategories.Default";
        }

        public sealed class StatutLogs
        {
            public const string Root = "LV.StatutLogs";
            public const string Created = "LV.StatutLogs.Created";
            public const string Updated = "LV.StatutLogs.Updated";
            public const string Deleted = "LV.StatutLogs.Deleted";
        }
    }
}
