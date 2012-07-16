using GDNET.Domain.System;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;

namespace GDNET.Data.System
{
    public class UserMapping : JoinedSubclassMapping<User>, IEntityMapping
    {
        public UserMapping()
        {
            base.Property(e => e.Email, m =>
            {
                m.Unique(true);
            });
            base.Property(e => e.Password, m =>
            {
                m.NotNullable(true);
            });
            base.Property(e => e.DisplayName);
            base.Property(e => e.IsActive, m =>
            {
                m.NotNullable(true);
            });
            base.Table("User");
            base.Key(km => km.Column("UserId"));
        }
    }

    //public class UserMapping : AbstractEntityWithModificationHistoryTMapping<User, long>, IEntityMapping
    //{
    //    public UserMapping()
    //        : base(Generators.Native)
    //    {
    //        base.Property(e => e.Email, m =>
    //        {
    //            m.Unique(true);
    //        });
    //        base.Property(e => e.Password, m =>
    //        {
    //            m.NotNullable(true);
    //        });
    //        base.Property(e => e.DisplayName);
    //        base.Property(e => e.IsActive, m =>
    //        {
    //            m.NotNullable(true);
    //        });
    //    }
    //}
}
