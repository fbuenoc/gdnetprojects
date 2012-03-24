namespace GDNET.Common.Services
{
    public interface IFormatterService
    {
        /// <summary>
        /// Format a number by default culture.
        /// </summary>
        string FormatNumber(object number);
    }
}
