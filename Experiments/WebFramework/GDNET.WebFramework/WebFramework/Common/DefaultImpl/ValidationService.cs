using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using WebFramework.Common.Services;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;

namespace WebFramework.Common.DefaultImpl
{
    public class ValidationService : IValidationService
    {
        public bool ValidateInput(Dictionary<string, ListValue> attributesInfo, FormCollection collection, out string errorMessages)
        {
            StringBuilder errors = new StringBuilder();

            foreach (var kvp in attributesInfo)
            {
                string userInput = collection[kvp.Key];
                switch (kvp.Value.Name)
                {
                    case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                    case ListValueConstants.ContentDataTypes.TextPasswordTextBox:
                    case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                    case ListValueConstants.ContentDataTypes.TextTextArea:
                        break;
                }
            }

            errorMessages = errors.ToString();
            return string.IsNullOrEmpty(errorMessages.ToString());
        }
    }
}