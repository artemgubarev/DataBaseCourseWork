using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.UserControls
{
    internal class RepositoryCmbboxContent
    {
        public RepositoryCmbboxContent(IEnumerable<string> data, int colIndex)
        {
            Data = data;
            ColIndex = colIndex;
        }
        public IEnumerable<string> Data { get; set; }
        public int ColIndex { get; set; }
    }
}
