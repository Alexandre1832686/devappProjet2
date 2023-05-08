namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test()
        {
            calcul c = new calcul();
            Assert.Pass();
        }
    }
}