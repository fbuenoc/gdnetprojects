namespace GDNET.Extensions
{
    public static class StructAssistant
    {
        public static bool IsDefault<T>(this T value) where T : struct
        {
            return value.Equals(default(T));
        }
    }
}
