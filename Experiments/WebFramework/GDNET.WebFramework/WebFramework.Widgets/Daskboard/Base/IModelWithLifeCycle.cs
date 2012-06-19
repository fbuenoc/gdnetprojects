using System;

namespace WebFramework.Widgets.Daskboard.Base
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
