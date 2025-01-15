namespace GildedRoseKata.Items;

public class Default
{
    public Default(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }
}