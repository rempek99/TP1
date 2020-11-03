using System;
using TP1;
using Xunit;

namespace TP1_test
{
    public class UnitTest1
    {
        [Fact]
        public void TestKostruktora()
        {
            IDiscountCounter normalClient = new DiscountCounter(0.0f);
            IDiscountCounter youngClient = new DiscountCounter(0.5f);
            IClient k1 = new Reader("Jan", "Kowalski", 990214291, normalClient);
            Assert.Equal("Jan Kowalski, 990214291", k1.ToString());
            Assert.Equal(0.0f, k1.GetDiscount());

            IClient ky1 = new Reader("Jasiu", "Kowalski", 040214291, youngClient);
            Assert.Equal(0.5f, ky1.GetDiscount());

            CopyInfo cp = new CopyInfo(1, new BookItem("Dziady", "Mickiewicz"), new Prize(24.10f, 0.23f,"pln"));

            Assert.Equal("1) Dziady, Mickiewicz, 24,10pln (vat23%)", cp.ToString());

        }
    }
}
