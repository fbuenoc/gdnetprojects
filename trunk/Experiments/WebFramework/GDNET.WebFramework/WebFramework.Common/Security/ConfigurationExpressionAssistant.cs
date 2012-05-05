using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentSecurity;

namespace WebFramework.Common.Security
{
    public static class ConfigurationExpressionAssistant
    {
        public static IConventionPolicyContainer ForAllControllersInAssemblyImplementedType<IType>(this ConfigurationExpression confex)
        {
            var controllerTypes = new List<Type>();
            var policyContainers = new List<IPolicyContainer>();
            Type interfaceType = typeof(IType);

            if ((confex != null) && (interfaceType != null))
            {
                var allTypes = interfaceType.Assembly.GetExportedTypes().Where(type => typeof(IController).IsAssignableFrom(type) && type.GetInterface(interfaceType.Name) != null);
                controllerTypes.AddRange(allTypes);
            }

            foreach (var controllerType in controllerTypes)
            {
                var controllerName = controllerType.GetControllerName();
                var actionMethods = controllerType.GetActionMethods();

                policyContainers.AddRange(actionMethods.Select(actionMethod => confex.AddPolicyContainerFor(controllerName, actionMethod.Name)));
            }

            return new ConventionPolicyContainer(policyContainers);
        }
    }
}