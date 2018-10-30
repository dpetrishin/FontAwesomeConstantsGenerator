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
            Console.ReadKey();
            
            var content = DirectoryHelper.ReadFromFile(fileFullPath);
            var cssParser = new CssParser(content);
            cssParser.Parse();
            
            var enumGen = new TsEnumGenerator(cssParser.Result);
            var result = enumGen.Generate();
            
            File.AppendAllText(Path.Combine(currentPath, "index.ts"), result.ToString());
        }
    }
}