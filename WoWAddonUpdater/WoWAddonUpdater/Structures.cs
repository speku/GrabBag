using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWAddonUpdater
{
   internal struct ParseDetail
    {
        public int input;
        public string basePage, pattern;

        internal ParseDetail(int input, string basePage, string pattern)
        {
            this.input = input;
            this.basePage = basePage;
            this.pattern = pattern;
        }
    }
}
