namespace GDNET.Common.Domain
{
    public interface IValidation
    {
        /// <summary>
        /// Self validate object
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
