namespace GDNET.Common.Domain
{
    public interface IObjectValidation
    {
        /// <summary>
        /// Self validate object
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
