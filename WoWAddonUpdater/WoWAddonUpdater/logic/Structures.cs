using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWAddonUpdater
{
   internal struct ParseDetail
    {
        public List<int> inputs;
        public string basePage, pattern;
        public bool entryPoint;

        internal ParseDetail(List<int> inputs, string basePage, string pattern, bool entryPoint = false)
        {
            this.inputs = inputs;
            this.basePage = basePage;
            this.pattern = pattern;
            this.entryPoint = entryPoint;
        }
    }
}
