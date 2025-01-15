namespace GildedRoseKata.Items;
public class Conjured
{
    public Conjured(Item item)
    {
        item.Quality -= 2;
        item.SellIn -= 1;
    }
}