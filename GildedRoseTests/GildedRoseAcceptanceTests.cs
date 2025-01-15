using System.Linq;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseAcceptanceTests : GildedRoseTestBase
{
    [Fact]
    public void Ensure_Item_Has_Sellin_Property()
    {
        //Arrange
        var res = typeof(Item);
        var propertyNameLower = "sellin";

        //Act
        var property = res
            .GetProperties()
            .FirstOrDefault(p => p.Name.ToLower() == propertyNameLower);

        //Assert
        Assert.NotNull(property);
    }

    [Fact]
    public void Ensure_Item_Has_Quality_Property()
    {
        //Arrange
        var res = typeof(Item);
        var propertyNameLower = "quality";

        //Act
        var property = res
            .GetProperties()
            .FirstOrDefault(p => p.Name.ToLower() == propertyNameLower);

        //Assert
        Assert.NotNull(property);
    }

    [Fact]
    public void Ensure_Quality_And_SellIn_Are_Lowered_By_One()
    {
        //Arrange
        var items = CreateItems("foo", 5, 3);
        GildedRose app = new GildedRose(items);

        const string expectedName = "foo";
        const int expectedSellIn = 4;
        const int expectedQuality = 2;

        //Act
        app.UpdateQuality();

        //Assert
        AssertResults(items, expectedName, expectedSellIn, expectedQuality);
    }
}