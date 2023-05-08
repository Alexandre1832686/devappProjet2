namespace TestProject1
{
    public class Tests
    {
        calcul c;
        [SetUp]
        public void Setup()
        {
            c = new calcul(300000, 6, 200, "Mensuel", "bob", "boby");
        }

        [Test]
        public void testCalculMensualite()
        {
            if(Math.Round(c.Mensualite,2) == 2376.42)
            Assert.Pass();

            Assert.Fail();
        }

        [Test]
        public void testListePaiementFinalCapital()
        {
            if (Math.Round(c.Paiements[c.Paiements.Count-1].Balance, 2) == 0)
                Assert.Pass();

            Assert.Fail();
        }

        [Test]
        public void testListePaiementnbPaiements()
        {
            if (c.Paiements.Count == 200)
                Assert.Pass();


            Assert.Fail();
        }

        [Test]
        public void testTotalInteret()
        {
            if (c.InteretTotal == 18000)
                Assert.Pass();


            Assert.Fail();
        }


    }
}