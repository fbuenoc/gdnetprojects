namespace WebFramework.Common.Widgets
{
    public class WidgetAction
    {
        public string ActionCode
        {
            get;
            set;
        }

        public WidgetAction(string actionCode)
        {
            this.ActionCode = actionCode;
        }

        #region Operators

        public static bool operator ==(WidgetAction action, string actionCode)
        {
            if (action != null && !string.IsNullOrEmpty(action.ActionCode) && action.ActionCode.Equals(actionCode))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(WidgetAction action, string actionCode)
        {
            return !(action == actionCode);
        }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return (this == (string)obj);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.ActionCode;
        }

        #endregion
    }
}
