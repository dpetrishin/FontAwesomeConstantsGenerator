using System.Collections.Generic;
using System.Text;

namespace FontAwesomeParser.Terminal
{
    public class TsEnumGenerator
    {
        private readonly string enumName = "FontAwesomeIcons";
        private readonly List<CssClass> cssClassList;
        public TsEnumGenerator(List<CssClass> cssClassList)
        {
            this.cssClassList = cssClassList;
        }

        public StringBuilder Generate()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"enum {this.enumName} {{");

            foreach (CssClass cssClass in this.cssClassList)
            {
//                result.AppendFormat("  {0}=\"{1}\"", cssClass.PascalCaseName, cssClass.Name); 
                result.Append($"  {cssClass.PascalCaseName}=\"{cssClass.Name}\"");    
            }

            result.AppendLine("}");

            return result;
        }
    }
}