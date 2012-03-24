using System.Globalization;

namespace GDNET.Common.Services
{
    public interface ITranslationService
    {
        string Translate(string code);
        string Translate(string code, CultureInfo culture);
    }
}
