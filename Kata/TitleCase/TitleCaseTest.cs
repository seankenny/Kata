using NUnit.Framework;

namespace Kata.TitleCase
{
    [TestFixture]
    public class TitleCaseTest
    {
        [Test]
        public void Capitalise_SingleWord_ReturnsCapitalised()
        {
            var titleCase = new TitleCase();

            var response = titleCase.Format("capThisPLEASE");

            Assert.AreEqual("Capthisplease", response);
        }

        [Test]
        public void Capitalise_MultipleWord_ReturnsCapitalised()
        {
            var titleCase = new TitleCase();

            var response = titleCase.Format("capThisPLEASE THISToO");

            Assert.AreEqual("Capthisplease Thistoo", response);
        }

        [Test]
        public void Capitalise_MultipleWordWithReserved_ReturnsCapitalised()
        {
            var titleCase = new TitleCase();

            var response = titleCase.Format("capThisPLEASE a THE tO THISToO");

            Assert.AreEqual("Capthisplease a the to Thistoo", response);
        }

        [Test]
        public void Capitalise_MultipleWordWithReservedFirstAndLast_ReturnsCapitalised()
        {
            var titleCase = new TitleCase();

            var response = titleCase.Format("A capThisPLEASE a THE tO THISToO ThE");

            Assert.AreEqual("A Capthisplease a the to Thistoo The", response);
        }

        [Test]
        public void Capitalise_EmptyString_ReturnsEmptyString()
        {
            var titleCase = new TitleCase();

            var response = titleCase.Format("");

            Assert.AreEqual("", response);
        }
    }
}
