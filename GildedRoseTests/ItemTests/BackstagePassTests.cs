using GildedRoseKata.Items;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests.ItemTests;

public class BackstagePassTests
{
    [Fact]
    public void Quality_Less_Than_50_Allow_Increase()
    {
        //Arrange
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 49 };

        const int expectedSellIn = 49;
        const int expectedQuality = 50;

        //Act
        _ = new BackstagePasses(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Can_Not_Exceed_50()
    {
        //Arrange
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 50 };

        const int expectedSellIn = 49;
        const int expectedQuality = 50;

        //Act
        _ = new BackstagePasses(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Increases_By_2_When_Within_10_Days()
    {
        //Arrange
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 };

        const int expectedSellIn = 8;
        const int expectedQuality = 12;

        //Act
        _ = new BackstagePasses(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Quality_Increases_By_3_When_Within_5_Days()
    {
        //Arrange
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 };

        const int expectedSellIn = 3;
        const int expectedQuality = 13;

        //Act
        _ = new BackstagePasses(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void SellIn_Always_Decreses_By_One()
    {
        //Arrange
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 };

        const int expectedSellIn = -2;
        const int expectedQuality = 0;

        //Act
        _ = new BackstagePasses(item);

        //Assert
        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}