using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common.Models;

namespace GDNET.FrameworkInfrastructure.Services.Models
{
    public class AccountModelsService
    {
        public UpdateDetailsModel CreateUpdateDetailsModel(string email)
        {
            UpdateDetailsModel model = null;
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                model = new UpdateDetailsModel
                {
                    DisplayName = user.DisplayName,
                    IsActive = user.IsActive
                };
            }

            return model;
        }

        public bool UpdateUserFromModel(string email, UpdateDetailsModel model)
        {
            bool result = false;
            User user = DomainRepositories.User.FindByEmail(email);

            if (user != null)
            {
                user.DisplayName = model.DisplayName;
                user.IsActive = model.IsActive;
                result = true;
            }

            return result;
        }
    }
}
