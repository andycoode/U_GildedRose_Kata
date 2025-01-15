using System.Collections.Generic;
using GildedRoseKata.Items;

namespace GildedRoseKata
{
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
                        AgedBrie(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        BackstagePasses(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        Sulfuras(item);
                        break;
                    case "Conjured Mana Cake":
                        _ = new Conjured(item);
                        break;
                    default:
                        OtherItems(item);
                        break;
                }

            }
        }


        private void BackstagePasses(Item item)
        {
            if (item.Quality < 50) item.Quality += 1;

            if (item.SellIn < 11 && item.Quality < 50) item.Quality += 1;

            if (item.SellIn < 6 && item.Quality < 50) item.Quality += 1;

            item.SellIn -= 1;

            if (item.SellIn < 0) item.Quality = 0;
        }

        private void AgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        private void Sulfuras(Item item)
        {
            //Never changes
            item.Quality = item.Quality;
            item.SellIn = item.SellIn;
        }

        private void OtherItems(Item item)
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
}
