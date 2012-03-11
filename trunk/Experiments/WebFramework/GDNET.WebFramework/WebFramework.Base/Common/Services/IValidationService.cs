using System.Collections.Generic;
using System.Web.Mvc;
using WebFramework.Domain.Common;

namespace WebFramework.Base.Common.Services
{
    public interface IValidationService
    {
        bool ValidateInput(Dictionary<string, ListValue> attributesInfo, FormCollection collection, out string errorMessages);
    }
}