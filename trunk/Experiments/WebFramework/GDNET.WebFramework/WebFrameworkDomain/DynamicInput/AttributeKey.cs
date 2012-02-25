using System.Collections.Generic;

namespace WebFrameworkDomain.DynamicInput
{
    public sealed class AttributeKey
    {
        private static readonly Dictionary<int, string> _dictOfKeys = new Dictionary<int, string>();
        private static bool _isInitialized = false;

        private static void Initialize()
        {
            if (_isInitialized == false)
            {
                _dictOfKeys.Add(1, "TagName");
                _dictOfKeys.Add(10, "type");
                _dictOfKeys.Add(11, "maxlength");
                _dictOfKeys.Add(12, "size");
                _dictOfKeys.Add(13, "accesskey");
                _dictOfKeys.Add(14, "disabled");
                _dictOfKeys.Add(15, "readonly");
                _dictOfKeys.Add(16, "tabindex");
                _dictOfKeys.Add(17, "rows");
                _dictOfKeys.Add(18, "cols");

                _isInitialized = true;
            }
        }

        public static AttributeInfo TagName
        {
            get
            {
                Initialize();
                return new AttributeInfo("1", _dictOfKeys[1]);
            }
        }

        public static string Find(string key)
        {
            int keyInt = int.Parse(key);
            return _dictOfKeys.ContainsKey(keyInt) ? _dictOfKeys[keyInt] : string.Empty;
        }
    }
}
