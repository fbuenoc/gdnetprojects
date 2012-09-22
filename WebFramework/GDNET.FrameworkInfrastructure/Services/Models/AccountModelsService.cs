using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Models;

namespace GDNET.FrameworkInfrastructure.Services.Models
{
    public class AccountModelsService
    {
        public UpdateDetailsModel GetUpdateDetailsModelByEmail(string email)
        {
            UpdateDetailsModel model = null;
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                model = this.GetUpdateDetailsModel(user);
            }

            return model;
        }

        public UpdateDetailsModel GetUpdateDetailsModel(User user)
        {
            var model = new UpdateDetailsModel();
            model.Initialize(user, false);

            return model;
        }

        public bool UpdateUserFromModel(string email, UpdateDetailsModel model)
        {
            bool result = false;
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                user.DisplayName = model.DisplayName;
                user.Introduction = model.Introduction;
                user.IsActive = model.IsActive;
                result = true;
            }

            return result;
        }
    }
}
