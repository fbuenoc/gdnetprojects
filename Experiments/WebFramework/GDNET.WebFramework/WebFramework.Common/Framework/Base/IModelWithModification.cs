using System;

namespace WebFramework.Common.Framework.Base
{
    public interface IModelWithModification
    {
        string ActualStatut { get; }

        DateTime CreatedAt { get; }
        string CreatedBy { get; }

        DateTime LastModifiedAt { get; }
        string LastModifiedBy { get; }
    }
}
