using System.Collections.Generic;
using System.Text;

namespace FontAwesomeParser.Terminal
{
    public class TsEnumGenerator
    {
        private readonly string enumName = "FontAwesomeIcons";
        private readonly IEnumerable<CssClass> cssClassList;
        public TsEnumGenerator(IEnumerable<CssClass> cssClassList)
        {
            this.cssClassList = cssClassList;
        }

        public StringBuilder Generate()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"enum {this.enumName} {{");

            foreach (CssClass cssClass in this.cssClassList)
            { 
                result.AppendLine($"  {cssClass.PascalCaseName}=\"{cssClass.Name}\",");    
            }

            result.AppendLine("}");
            result.AppendLine();
            result.AppendLine($"export default {this.enumName}");

            return result;
        }
    }
}