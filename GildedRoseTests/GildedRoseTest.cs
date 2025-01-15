using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    public class GildedRoseTest : GildedRoseTestBase
    {
        [Fact]
        public void Quality_Degrades_Double_If_Sellin_Has_Passed()
        {
            //Arrange
            var items = CreateItems("Standard Item", 0, 5);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Standard Item";
            const int expectedSellIn = -1;
            const int expectedQuality = 3;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        [Fact]
        public void Quality_Is_Never_Negative()
        {
            //Arrange
            var items = CreateItems("Standard Item", 0, 1);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Standard Item";
            const int expectedSellIn = -1;
            const int expectedQuality = 0;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        [Fact]
        public void Quality_Increases_As_Brie_SellIn_Lowers()
        {
            //Arrange
            var items = CreateItems("Aged Brie", 10, 20);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Aged Brie";
            const int expectedSellIn = 9;
            const int expectedQuality = 21;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        [Fact]
        public void Quality_Increases_But_Never_More_Than_50()
        {
            //Arrange
            var items = CreateItems("Aged Brie", 10, 50);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Aged Brie";
            const int expectedSellIn = 9;
            const int expectedQuality = 50;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        [Fact]
        public void Quality_And_SellIn_Never_Change_When_Sulfuras()
        {
            //Arrange
            var items = CreateItems("Sulfuras, Hand of Ragnaros", 50, 33);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Sulfuras, Hand of Ragnaros";
            const int expectedSellIn = 50;
            const int expectedQuality = 33;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        [Theory]
        [InlineData(10, 10, 9,12)] //Quality increases by 2 when less than 10 days
        [InlineData(5,10, 4, 13)] //Quality increases by 3 when less than 5 days
        [InlineData(0,10,-1,0)] //Quality is zero when after the concert
        public void Backstage_Quality_Degrades_According_To_The_SellIn_Remaining(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            //Arrange
            var items = CreateItems("Backstage passes to a TAFKAL80ETC concert", sellIn, quality);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";
 
            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }

        /*
         * Test can't be run yet. When it is ready, remove the Skip.
         * Also need to ensure update the ThirtyDays.verified.txt, as it only degrades by 1 on there, should be 2.
         */
        [Fact(Skip = "The UpdateQuality method does not currently handle Conjured items.")]
        public void Conjured_Degrades_Twice_As_Fast_As_Normal_Item()
        {
            //Arrange
            var items = CreateItems("Conjured Mana Cake", 20, 14);
            GildedRose app = new GildedRose(items);

            const string expectedName = "Conjured Mana Cake";
            const int expectedSellIn = 19;
            const int expectedQuality = 12;

            //Act
            app.UpdateQuality();

            //Assert
            AssertResults(items, expectedName, expectedSellIn, expectedQuality);
        }
    }
}

