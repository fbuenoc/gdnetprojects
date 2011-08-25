using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGenerate;

namespace GDNET.Extensions.QuickGenerate
{
    public class EnumAsStringGenerator : Generator<string>
    {
        public Type enumType = null;

        /// <summary>
        /// Create new Enum generator
        /// </summary>
        /// <param name="enumType">Enum type</param>
        public EnumAsStringGenerator(Type enumType)
        {
            this.enumType = enumType;
        }

        public override string GetRandomValue()
        {
            var names = Enum.GetNames(this.enumType);
            int index = new Random().Next(0, names.Count());
            return names[index];
        }
    }
}
