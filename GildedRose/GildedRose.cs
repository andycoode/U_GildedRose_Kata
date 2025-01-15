﻿using System.Collections.Generic;

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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality -= 1;
                }
                
                if (item.Name == "Aged Brie" && item.Quality < 50)
                {
                    item.Quality += 1;
                }
                
              
                //BACKSTAGE LOGIC ALL HERE!
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    BackstagePasses(item);
                }
                

                if (item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality -= 1;
                    }

                    if (item.Name == "Aged Brie" && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
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
    }
}
