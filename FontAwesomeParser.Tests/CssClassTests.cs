using FontAwesomeParser.Terminal;
using NUnit.Framework;

namespace FontAwesomeParser.Tests
{
    public class CssClassTests
    {
        [Test]
        [TestCase(".fa-500px", "fa-500px", "Fa500px")]
        [TestCase(".fa-arrow-alt-circle-up","fa-arrow-alt-circle-up", "FaArrowAltCircleUp")]
        public void SimpleTest(string fullClassName,string expectedName, string expectedPascalCaseName)
        {
            CssClass cssClass = new CssClass(fullClassName);
            
            Assert.That(cssClass.Name, Is.EqualTo(expectedName));
            Assert.That(cssClass.PascalCaseName, Is.EqualTo(expectedPascalCaseName));
        }
    }
}