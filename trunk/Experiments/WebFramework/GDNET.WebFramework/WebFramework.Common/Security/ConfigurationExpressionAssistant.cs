using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using FluentSecurity;
using GDNET.Extensions;

namespace WebFramework.Common.Security
{
    public static class ConfigurationExpressionAssistant
    {
        private static readonly string ModulesControllersAssemblies = HostingEnvironment.MapPath("~/App_Data/ModulesControllersAssemblies.txt");

        public static IConventionPolicyContainer ForAllControllersInAssemblyImplementedType<IType>(this ConfigurationExpression config)
        {
            var controllerTypes = new List<Type>();
            var policyContainers = new List<IPolicyContainer>();
            Type interfaceType = typeof(IType);

            if ((config != null) && (interfaceType != null))
            {
                var allTypes = interfaceType.Assembly.GetExportedTypes().Where(type => typeof(IController).IsAssignableFrom(type) && type.GetInterface(interfaceType.Name) != null);
                controllerTypes.AddRange(allTypes);

                if (File.Exists(ModulesControllersAssemblies))
                {
                    foreach (string line in File.ReadAllLines(ModulesControllersAssemblies).Where(x => ValidatedLine(x)))
                    {
                        var asm = Assembly.Load(line);
                        var listImplemetedTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(interfaceType, asm);
                        controllerTypes.AddRange(listImplemetedTypes);
                    }
                }
            }

            foreach (var controllerType in controllerTypes)
            {
                var controllerName = controllerType.GetControllerName();
                var actionMethods = controllerType.GetActionMethods();

                policyContainers.AddRange(actionMethods.Select(actionMethod => config.AddPolicyContainerFor(controllerName, actionMethod.Name)));
            }

            return new ConventionPolicyContainer(policyContainers);
        }

        private static bool ValidatedLine(string line)
        {
            return !(string.IsNullOrEmpty(line) || line.StartsWith("#"));
        }
    }
}