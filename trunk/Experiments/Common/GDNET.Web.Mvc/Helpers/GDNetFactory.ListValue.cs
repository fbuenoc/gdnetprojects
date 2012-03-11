using System.Collections.Generic;
using System.Text;

namespace GDNET.Web.Mvc.Helpers
{
    public sealed class ListValueDTO
    {
        public string Url
        {
            get;
            private set;
        }

        public string Text
        {
            get;
            private set;
        }

        public ListValueDTO(string url, string text)
        {
            this.Url = url;
            this.Text = text;
        }
    }

    public partial class GDNetFactory
    {
        public string ListValue(IEnumerable<ListValueDTO> listValues)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var dto in listValues)
            {
                sb.AppendFormat("{0}, ", this.HtmlLink(dto.Url, dto.Text));
            }

            return (sb.Length > 0) ? sb.ToString(0, sb.Length - 2) : string.Empty;
        }
    }
}
