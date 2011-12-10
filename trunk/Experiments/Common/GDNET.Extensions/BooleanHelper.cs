namespace GDNET.Extensions
{
    /// <summary>
    /// Provides extension methods for boolean
    /// </summary>
    public static class BooleanHelper
    {
        public static string ToStringYesNo(this bool value)
        {
            return value ? BooleanConstants.Yes : BooleanConstants.No;
        }
    }
}
