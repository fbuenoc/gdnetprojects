namespace GDNET.Common.Domain
{
    public interface ISerializable
    {
        /// <summary>
        /// Serialize object to string
        /// </summary>
        /// <returns></returns>
        string Serialize();
    }
}
