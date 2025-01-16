using GildedRoseKata;
using GildedRoseKata.Items;
using Xunit;

namespace GildedRoseTests.ItemTests;

public class ConjuredTests
{
    [Fact]
    public void Quality_Should_Degrade_Twice_As_Fast()
    {
        //Arrange
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 17, Quality = 13 };

        const int expectedSellIn = 16;
        const int expectedQuality = 11;

        //Act
        _ = new Conjured(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}