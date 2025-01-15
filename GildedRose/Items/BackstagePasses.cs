namespace GildedRoseKata.Items;

public class BackstagePasses
{
    public BackstagePasses(Item item)
    {
        if (item.Quality < 50) item.Quality += 1;

        if (item.SellIn < 11 && item.Quality < 50) item.Quality += 1;

        if (item.SellIn < 6 && item.Quality < 50) item.Quality += 1;

        item.SellIn -= 1;

        if (item.SellIn < 0) item.Quality = 0;
    }
}