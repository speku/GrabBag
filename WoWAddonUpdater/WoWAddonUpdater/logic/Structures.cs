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

        internal ParseDetail(List<int> inputs, string basePage, string pattern)
        {
            this.inputs = inputs;
            this.basePage = basePage;
            this.pattern = pattern;
        }
    }
}
