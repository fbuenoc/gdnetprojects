using System;

namespace GDNET.Common.Base
{
    /// <summary>
    /// Event argument with only one parameter
    /// </summary>
    public sealed class SimpleEventArgs : EventArgs
    {
        public SimpleEventArgs(object args)
            : base()
        {
            this.Args = args;
        }

        public object Args
        {
            get;
            private set;
        }
    }
}
