using GildedRoseKata;
using GildedRoseKata.Items;
using Xunit;

namespace GildedRoseTests.ItemTests;

public class DefaultTests
{
    [Fact]
    public void Quality_Decreases_If_Greater_Than_Zero()
    {
        //Arrange
        var item = new Item { Name = "Standard Item", SellIn = 5, Quality = 5 };

        const int expectedSellIn = 4;
        const int expectedQuality = 4;

        //Act
        _ = new Default(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void SellIn_Always_Decreases_By_One()
    {
        //Arrange
        var item = new Item { Name = "Standard Item", SellIn = 5, Quality = -1 };

        const int expectedSellIn = 4;
        const int expectedQuality = -1;

        //Act
        _ = new Default(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Decreases_Twice_As_Fast_If_Past_SellIn()
    {
        //Arrange
        var item = new Item { Name = "Standard Item", SellIn = -10, Quality = 10 };

        const int expectedSellIn = -11;
        const int expectedQuality = 8;

        //Act
        _ = new Default(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}