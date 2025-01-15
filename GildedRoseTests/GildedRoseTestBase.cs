using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTestBase
{
    public List<Item> CreateItems(string name, int sellin, int quality)
    {
        return new List<Item> { new Item { Name = name, SellIn = sellin, Quality = quality } };
    }

    public void AssertResults(List<Item> items, string itemName, int expectedSellinValue, int expectedQualityValue)
    {
        Assert.Equal(itemName, items[0].Name);
        Assert.Equal(expectedSellinValue, items[0].SellIn);
        Assert.Equal(expectedQualityValue, items[0].Quality);
    }
}