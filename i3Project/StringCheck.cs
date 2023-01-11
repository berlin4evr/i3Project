using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i3Project
{
    public class StringCheck
    {
        static void Main(string[] args)
        {
            string str = "abcdefgh";
            string value = "mno";
            Boolean result = str.Contains(value);
            Console.WriteLine($"Does string contain specified substring? {result}");
        }
    }
}
