using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FontAwesomeParser.Terminal
{
    public class CssClass
    {
        private string fullName;
        public CssClass(string fullName)
        {
            this.fullName = fullName;
            this.Name = this.fullName.Substring(1, this.fullName.Length - 1);
            this.PascalCaseName = this.ToPascalCaseName();
        }

        public string Name { get; }
        
        public string PascalCaseName { get; }

        public string ToPascalCaseName()
        {
            List<char> result = new List<char>();
            
            result.Add(char.ToUpper(this.Name[0]));

            for (int i = 1; i < this.Name.Length; i++)
            {
                char previousC = this.Name[i - 1];
                char c = this.Name[i];
                
                if (this.IsHyphen(c))
                {
                    continue;
                }
                else if (this.IsHyphen(previousC))
                {
                    result.Add(char.ToUpper(c));   
                }
                else
                {
                    result.Add(c);
                }
            }
            
            return new string(result.ToArray());
        }

        private bool IsHyphen(char c)
        {
            return c == '-';
        }
    }
}