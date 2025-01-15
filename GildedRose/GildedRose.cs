using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> _items;

    public GildedRose(IList<Item> Items)
    {
        _items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {

            switch (item.Name)
            {
                case "Aged Brie":
                    _ = new AgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    _ = new BackstagePasses(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    _ = new Sulfuras(item);
                    break;
                case "Conjured Mana Cake":
                    _ = new Conjured(item);
                    break;
                default:
                    _ = new Default(item);
                    break;
            }

        }
    }
}