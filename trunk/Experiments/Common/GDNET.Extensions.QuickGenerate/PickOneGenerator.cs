using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGenerate;

namespace GDNET.Extensions.QuickGenerate
{
    public class PickOneGenerator : Generator<string>
    {
        private IEnumerable<object> sources = null;

        public PickOneGenerator(IEnumerable<object> sources)
        {
            this.sources = sources;
        }

        public override string GetRandomValue()
        {
            int index = new Random().Next(0, this.sources.Count());
            return this.sources.ElementAt(index).ToString();
        }
    }
}
