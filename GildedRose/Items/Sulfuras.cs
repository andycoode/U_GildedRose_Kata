namespace GildedRoseKata.Items;

public class Sulfuras
{
    public Sulfuras(Item item)
    {
        //Never changes
        item.Quality = item.Quality;
        item.SellIn = item.SellIn;
    }
}