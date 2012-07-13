using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Base.Validators
{
    public class ExceptionsValidator
    {
        #region Singleton

        private ExceptionsValidator() { }

        private class Nested
        {
            public static readonly ExceptionsValidator instance = new ExceptionsValidator();
        }

        public static ExceptionsValidator Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        public void NullException(object objet)
        {
            if (objet == null)
            {
                string message = string.Empty;
                throw new DomainException(message);
            }
        }

        public void NullOrEmptyException(string objet)
        {
            if (string.IsNullOrEmpty(objet))
            {
                string message = string.Empty;
                throw new DomainException(message);
            }
        }
    }
}
