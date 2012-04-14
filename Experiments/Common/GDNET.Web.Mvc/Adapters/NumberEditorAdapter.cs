using System;
using System.Web.Mvc;

namespace GDNET.Web.Mvc.Adapters
{
    public class NumberEditorAdapter : EditorAdapterBase<double?>
    {
        public NumberEditorAdapter(string editorName, FormCollection collection)
            : base(editorName, collection)
        {
        }

        public override double? Value
        {
            get
            {
                if (base.TextContent != null)
                {
                    return Convert.ToDouble(base.TextContent);
                }
                return default(double?);
            }
        }
    }
}
