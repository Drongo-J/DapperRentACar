using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperRentACar.Domain.Helpers
{
    public class FileHelpers
    {
        public string ReadFile(string filename)
        {
            return File.ReadAllText(filename, Encoding.UTF8);
        }
    }
}
