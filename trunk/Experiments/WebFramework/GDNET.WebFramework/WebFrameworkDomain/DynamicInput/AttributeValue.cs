using System.Collections.Generic;

namespace WebFrameworkDomain.DynamicInput
{
    /// <summary>
    /// We use 01, 02... to distinguish with value of attribute
    /// </summary>
    public class AttributeValue
    {
        private static readonly Dictionary<string, string> _dictOfValues = new Dictionary<string, string>();
        private static bool _isInitialized = false;

        public static readonly string DistinguistCharacter = "0";

        #region Tags

        public static AttributeInfo TagInput
        {
            get
            {
                Initialize();
                string tagKey = DistinguistCharacter + "1";
                return new AttributeInfo(tagKey, _dictOfValues[tagKey]);
            }
        }

        public static AttributeInfo TagTextArea
        {
            get
            {
                Initialize();
                string tagKey = DistinguistCharacter + "2";
                return new AttributeInfo(tagKey, _dictOfValues[tagKey]);
            }
        }

        #endregion

        private static void Initialize()
        {
            if (_isInitialized == false)
            {
                _dictOfValues.Add(DistinguistCharacter + "1", "input");
                _dictOfValues.Add(DistinguistCharacter + "2", "textarea");
                _dictOfValues.Add(DistinguistCharacter + "10", "checkbox");
                _dictOfValues.Add(DistinguistCharacter + "11", "file");
                _dictOfValues.Add(DistinguistCharacter + "12", "hidden");
                _dictOfValues.Add(DistinguistCharacter + "13", "password");
                _dictOfValues.Add(DistinguistCharacter + "14", "radio");
                _dictOfValues.Add(DistinguistCharacter + "15", "text");
                _dictOfValues.Add(DistinguistCharacter + "16", "disable");
                _dictOfValues.Add(DistinguistCharacter + "17", "readonly");

                _isInitialized = true;
            }
        }

        public static string Find(string key)
        {
            Initialize();
            return _dictOfValues.ContainsKey(key) ? _dictOfValues[key] : string.Empty;
        }
    }
}
