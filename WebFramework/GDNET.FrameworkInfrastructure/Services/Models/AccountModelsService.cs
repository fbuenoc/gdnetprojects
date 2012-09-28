using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.Models;

namespace GDNET.FrameworkInfrastructure.Services.Models
{
    public class AccountModelsService
    {
        public T GetUserModelByEmail<T>(string email) where T : AbstractViewModel<User>
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? null : this.GetUserModel<T>(user);
        }

        public UpdateDetailsModel GetUpdateDetailsModelByEmail(string email)
        {
            User user = DomainRepositories.User.FindByEmail(email);
            return (user == null) ? null : this.GetUserModel<UpdateDetailsModel>(user);
        }

        public UpdateDetailsModel GetUpdateDetailsModel(User user)
        {
            return this.GetUserModel<UpdateDetailsModel>(user);
        }

        public T GetUserModel<T>(User user) where T : AbstractViewModel<User>
        {
            T model = Activator.CreateInstance<T>();
            model.Initialize(user, false);

            return (T)model;
        }

        public bool UpdateUserFromModel(string email, UpdateDetailsModel model)
        {
            bool result = false;
            var catalog = DomainRepositories.Catalog.FindByCode("c.languages");
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                user.DisplayName = model.DisplayName;
                user.Introduction = model.Introduction;
                user.IsActive = model.IsActive;
                user.Language = catalog.GetLineByCode(model.Language);
                result = true;
            }

            return result;
        }
    }
}
