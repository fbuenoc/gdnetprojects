﻿using GDNET.Domain;
using GDNET.Domain.Base.Exceptions;
using GDNET.Domain.Common;
using GDNET.Domain.System;
using GDNET.Utils;

namespace GDNET.Data.System.Repositories
{
    public class UserRepositoryGlass : AbstractRepositoryGlass<User, long>
    {
        public override void ValidateOnCreation(User entity)
        {
            string propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var listUsersByEmail = DomainRepositories.User.FindByProperty(propertyEmail, entity.Email);
            if (listUsersByEmail.Count > 0)
            {
                ExceptionsManager.BusinessException.Throw("");
            }
        }

        public override void ValidateOnModification(User entity)
        {
            string propertyEmail = ExpressionAssistant.GetPropertyName(() => entity.Email);
            var listUsersByEmail = DomainRepositories.User.FindByProperty(propertyEmail, entity.Email);

            foreach (var user in listUsersByEmail)
            {
                if (user.Id != entity.Id)
                {
                    ExceptionsManager.BusinessException.Throw("");
                }
            }
        }
    }
}