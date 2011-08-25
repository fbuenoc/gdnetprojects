using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGenerate;
using NHibernate;
using GoogleCode.Core.Domain;
using QuickGenerate.Primitives;
using GDNET.Common.Domain;
using GDNET.Extensions.QuickGenerate;

namespace GoogleCode.GenerateRandomData
{
    public static class RandomData
    {
        public enum Activity
        {
            None = 0,
            Medium,
            High
        }

        private static DomainGenerator WithLabel(DomainGenerator generator)
        {
            return generator.With<Label>(options => options.For(label => label.Name, new StringGenerator(3, 20, "Label XYZEFH".ToCharArray())))
                .With<DomainBase<int>>(options => options.Ignore(o => o.Id));
        }

        private static DomainGenerator WithProject(DomainGenerator generator)
        {
            DateTime min = new DateTime(2010, 1, 1);
            DateTime max = new DateTime(2011, 12, 31);
            return generator.With<Project>(options => options.For(project => project.Name, new WordGenerator(3, 20, "Project One Two Three")))
                .With<Project>(options => options.For(project => project.Activity, new EnumAsStringGenerator(typeof(Activity))))
                .With<Project>(options => options.For(project => project.Description, new WordGenerator(3, 20, "This is my project and I love it xxx yyy xyz")))
                .With<Project>(options => options.For(project => project.Homepage, new StringGenerator(3, 20, "Project 1234567890".ToCharArray())))
                .With<Project>(options => options.For(project => project.LastUpdate, new DateTimeGenerator(min, max)))
                .With<Project>(options => options.For(project => project.LogoUrl, new StringGenerator(3, 20, "Project 1234567890".ToCharArray())))
                .With<DomainBase<long>>(options => options.Ignore(o => o.Id));
        }

        private static DomainGenerator WithProjectLabelLink(DomainGenerator generator)
        {
            DateTime min = new DateTime(2010, 1, 1);
            DateTime max = new DateTime(2011, 12, 31);
            return generator.With<DomainBase<long>>(options => options.Ignore(o => o.Id))
                .With<ProjectLabelLink>(options => options.For(link => link.CreatedDate, new DateTimeGenerator(min, max)));
        }

        public static void Create(ISession session)
        {
            var labels = WithLabel(new DomainGenerator())
                .ForEach<Label>(label => session.SaveOrUpdate(label))
                .Many<Label>(30)
                .ToList();

            var projects = WithProject(new DomainGenerator())
                .ForEach<Project>(project => session.SaveOrUpdate(project))
                .Many<Project>(50)
                .ToList();

            var links = WithProjectLabelLink(new DomainGenerator())
                .ForEach<ProjectLabelLink>(link =>
                {
                    link.Label = labels.PickOne();
                    link.Project = projects.PickOne();
                    session.SaveOrUpdate(link);
                })
                .Many<ProjectLabelLink>(200)
                .ToList();
        }
    }
}
