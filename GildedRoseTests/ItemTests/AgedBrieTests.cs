using GildedRoseKata.Items;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests;
public class AgedBrieTests
{
    [Fact]
    public void Quality_Stays_Same_Selling_Decreases()
    {
        //Arrange
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };

        const int expectedSellIn = -1;
        const int expectedQuality = 50;

        //Act
        _ = new AgedBrie(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Increases_When_SellIn_Positive()
    {
        //Arrange
        var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };

        const int expectedSellIn = 9;
        const int expectedQuality = 21;

        //Act
        _ = new AgedBrie(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Increases_Double_After_SellIn_Expired()
    {
        //Arrange
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };

        const int expectedSellIn = -1;
        const int expectedQuality = 2;

        //Act
        _ = new AgedBrie(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Increases_Double_Max_50_After_SellIn_Expired()
    {
        //Arrange
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 };

        const int expectedSellIn = -1;
        const int expectedQuality = 50;

        //Act
        _ = new AgedBrie(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
