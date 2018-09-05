using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovWordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // The path three directories above the executable directory in VS
            // From https://stackoverflow.com/a/14549805
            string wanted_path =
                Path.GetDirectoryName(Path.GetDirectoryName(
                    Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));

            string filepath = $"{wanted_path}\\words_alpha.txt";

            string[] lines = File.ReadAllLines(filepath);

            for (var i = 0; i < 10; ++i)
            {
                // use a tab to indent each line of the file.
                Console.WriteLine("\t" + lines[i]);
            }
        }
    }
}
