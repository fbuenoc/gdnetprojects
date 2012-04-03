using System;

namespace WebFramework.Common.Framework.Base
{
    public interface IModelWithLifeCycle
    {
        string ActualStatut { get; }

        DateTime CreatedAt { get; }
        string CreatedBy { get; }

        DateTime LastModifiedAt { get; }
        string LastModifiedBy { get; }
    }
}
