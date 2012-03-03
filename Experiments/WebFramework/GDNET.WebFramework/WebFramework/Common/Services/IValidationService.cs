using System.Collections.Generic;
using System.Web.Mvc;
using WebFrameworkDomain.Common;

namespace WebFramework.Common.Services
{
    public interface IValidationService
    {
        bool ValidateInput(Dictionary<string, ListValue> attributesInfo, FormCollection collection, out string errorMessages);
    }
}