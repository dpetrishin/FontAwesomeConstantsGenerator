using System.Collections.Generic;
using System.IO;
using System.Linq;
using FontAwesomeParser.Terminal;
using NUnit.Framework;

namespace FontAwesomeParser.Tests
{
    public class CssParserTests
    {
        private readonly string testFileName = "shortTest.css";
        private string content;
        
        private List<CheckModel> checkList = new List<CheckModel>
        {
            new CheckModel { Name = "fa-arrow-right", PascalCaseName = "FaArrowRight" },
            new CheckModel { Name = "fa-arrow-up", PascalCaseName = "FaArrowUp" },
            new CheckModel { Name = "fa-arrows-alt", PascalCaseName = "FaArrowsAlt" },
            new CheckModel { Name = "fa-arrows-alt-h", PascalCaseName = "FaArrowsAltH" },
            new CheckModel { Name = "fa-arrows-alt-v", PascalCaseName = "FaArrowsAltV" },
        };
        [SetUp]
        public void Setup()
        {
            var path = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(path, this.testFileName);
            this.content = DirectoryHelper.ReadFromFile(fullPath);
        }
        
        [Test]
        
        public void SimpleTest()
        {
            var parser = new CssParser(this.content);
            parser.Parse();

            IEnumerable<CssClass> result = parser.Result;

            var cssClasses = result.ToList();    
            for (int i = 0; i< cssClasses.Count; i++)
            {
                var resultElement = cssClasses[i];
                var expectedElement = this.checkList[i];
                
                Assert.That(resultElement.Name, Is.EqualTo(expectedElement.Name));
                Assert.That(resultElement.PascalCaseName, Is.EqualTo(expectedElement.PascalCaseName));
            }
        }
    }
}