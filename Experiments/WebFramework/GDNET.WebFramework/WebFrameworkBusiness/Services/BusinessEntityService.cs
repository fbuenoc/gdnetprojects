using System.Collections.Generic;

namespace WebFrameworkBusiness.Base
{
    public static class BusinessEntityService
    {
        public static IList<T> GetAll<T>() where T : BusinessEntityBase
        {
            return BusinessEntityService.GetAll<T>(int.MinValue, int.MinValue);
        }

        public static IList<T> GetAllPaging<T>(int pageIndex, int itemsPerPage) where T : BusinessEntityBase
        {
            return BusinessEntityService.GetAll<T>(pageIndex * itemsPerPage, itemsPerPage);
        }

        public static IList<T> GetAll<T>(int fromIndex, int limitItems) where T : BusinessEntityBase
        {
            List<T> results = new List<T>();
            return results;
        }
    }
}
