using NUnit.Framework;

namespace PageFactoryTests
{
    public class BmiCalcTests
    {
        [TestCase]
        public void TestBmiCalculator()
        {
            BmiCalcPage bmiCalcPage = new BmiCalcPage();
            bmiCalcPage.Load();
            Assert.IsTrue(bmiCalcPage.IsLoaded);
            bmiCalcPage.CalculateBmi("181", "80");
            Assert.AreEqual("24.4", bmiCalcPage.Bmi);
            Assert.AreEqual("Normal", bmiCalcPage.BmiCategory);
            bmiCalcPage.Close();
        }
    }
}
