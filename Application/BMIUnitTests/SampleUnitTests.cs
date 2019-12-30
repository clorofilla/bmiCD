using BMICalculator.Pages;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    
namespace BMIUnitTests
{
    [TestClass]
    public class SampleUnitTests
    {
        [TestMethod]
        public void IndexPageTest()
        {
           
            Assert.AreEqual("Index", "Index");
        }

    }
}
