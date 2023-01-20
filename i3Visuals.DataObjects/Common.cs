using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i3Visuals.DataObjects
{
    public class Common
    {
        string responseBody;
        string searchText;
        string queryString;
        string filePath;
        string fileName;
        string fileExtension;

        public string ResponseBody { get => responseBody; set => responseBody = value; }
        public string SearchText { get => searchText; set => searchText = value; }
        public string QueryString { get => queryString; set => queryString = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string FileExtension { get => fileExtension; set => fileExtension = value; }
    }
}
