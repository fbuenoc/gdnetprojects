using System;
using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public class NumericEditorAdapter<T> : EditorAdapterBase<T>
    {
        public NumericEditorAdapter(string componentName, FormCollection collection)
            : base(componentName, collection)
        {
        }

        public override T Value
        {
            get
            {
                if (string.IsNullOrEmpty(base.TextContent))
                {
                    return default(T);
                }
                else
                {
                    return (T)Convert.ChangeType(base.TextContent, typeof(T));
                }
            }
        }
    }
}
