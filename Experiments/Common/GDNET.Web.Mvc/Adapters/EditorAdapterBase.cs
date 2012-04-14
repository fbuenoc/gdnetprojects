using System.Linq;
using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public abstract class EditorAdapterBase<T>
    {
        private readonly FormCollection collection;
        private readonly string editorName;

        #region Ctors

        private EditorAdapterBase() { }

        public EditorAdapterBase(string editorName, FormCollection collection)
        {
            this.editorName = editorName;
            this.collection = collection;
        }

        #endregion

        public abstract T Value
        {
            get;
        }

        protected string TextContent
        {
            get
            {
                if (!string.IsNullOrEmpty(this.editorName) && collection.AllKeys.Contains(this.editorName))
                {
                    return collection[this.editorName];
                }

                return null;
            }
        }
    }
}
