using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsForms
{
    internal class fileReader
    {
        private StreamReader reader;
        public String testPath;
        private string filePath;

        public fileReader(string path)
        {
            this.filePath = path;

            if (File.Exists(filePath)) 
            {
                testPath = "File Path Exists";
            } else
            {
                testPath = "File Path does not exist";
            }
        }
    }
       
}
