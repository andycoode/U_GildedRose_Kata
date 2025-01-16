using GildedRoseKata;
using GildedRoseKata.Items;
using Xunit;

namespace GildedRoseTests.ItemTests;

public class SulfurasTests
{
    [Fact]
    public void Quality_Stays_Same_SellIn_Stays_The_Same()
    {
        //Arrange
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 30, Quality = 80 };

        const int expectedSellIn = 30;
        const int expectedQuality = 80;

        //Act
        _ = new Sulfuras(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}