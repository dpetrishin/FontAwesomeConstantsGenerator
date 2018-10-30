using System.IO;

namespace FontAwesomeParser.Terminal
{
    public static class DirectoryHelper
    {
        public static string ReadFromFile(string fullPath)
        {
            string content;
            using (FileStream fs = File.OpenRead(fullPath))
            using (TextReader tr = new StreamReader(fs))
            {
                content = tr.ReadToEnd();
            }

            return content;
        } 
    }
}