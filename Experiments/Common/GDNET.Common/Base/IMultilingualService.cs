using System.Globalization;

namespace GDNET.Common.Base
{
    public interface IMultilingualService
    {
        /// <summary>
        /// Get a text from translation code
        /// </summary>
        /// <param name="translationCode"></param>
        /// <returns></returns>
        string GetTranslation(string translationCode);

        /// <summary>
        /// Get a text from translation code
        /// </summary>
        /// <param name="translationCode"></param>
        /// <returns></returns>
        string GetTranslation(string translationCode, CultureInfo culture);
    }
}
