using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;

namespace FontAwesomeParser.Terminal
{
    public class CssParser
    {
        private string content;
        private List<CssClass> result;
        public CssParser(string content)
        {
            this.content = content;
            this.result = new List<CssClass>();
        }

        public void Parse()
        {
            List<char> buffer = new List<char>();
            bool fillStarted = false;
            for (int i = 0; i < this.content.Length; i++)
            {
                char c = content[i];
                

                if (!fillStarted)
                {
                    if (!this.IsDot(c))
                    {
                        continue;
                    }
                    
                    fillStarted = true;
                    buffer.Add(c);
                }
                else
                {
                    if (this.IsEndOfClassName(c))
                    {
                        result.Add(new CssClass(new string(buffer.ToArray())));
                        buffer.Clear();
                        fillStarted = false;
                    }
                    else if (
                        (char.IsLetterOrDigit(c) || char.IsPunctuation(c)) 
                        && !this.IsCurlyBrackets(c))
                    {
                        buffer.Add(c);
                    }
                }
            }
        }
        
        public List<CssClass> Result =>  this.result;

        private bool IsCurlyBrackets(char c)
        {
            return c == '{' || c == '}';
        }
        
        
        private bool IsDot(char c)
        {
            return c == '.';
        }

        private bool IsComma(char c)
        {
            return c == ',';
        }

        private bool IsColon(char c)
        {
            return c == ':';
        }

        private bool IsEndOfClassName(char c)
        {
            return this.IsComma(c) || char.IsWhiteSpace(c) || this.IsColon(c);
        } 
    }
}