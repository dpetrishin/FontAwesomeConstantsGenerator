using System;
using System.Diagnostics;
using System.IO;

namespace FontAwesomeParser.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "all.css";

            var currentPath = Directory.GetCurrentDirectory();
            var fileFullPath = Path.Combine(currentPath, fileName);
            
            Console.WriteLine($"Put the all.css file in {currentPath}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            var content = DirectoryHelper.ReadFromFile(fileFullPath);
            var cssParser = new CssParser(content);
            cssParser.Parse();
            
            var enumGen = new TsEnumGenerator(cssParser.Result);
            var result = enumGen.Generate();

            string targetFullPath = Path.Combine(currentPath, "index.ts");
            
            File.Delete(targetFullPath);
            File.AppendAllText(targetFullPath
                , result.ToString());
        }
    }
}