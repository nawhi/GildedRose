﻿using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var currentItem in Items)
            {
                UpdateItem(currentItem);
            }
        }

        private static void UpdateItem(Item currentItem)
        {
            if (IsAgedBrie(currentItem))
            {
                if (currentItem.Quality < 50)
                {
                    IncrementQualityWithBoundsCheck(currentItem);

                    if (IsConcertTicket(currentItem))
                    {
                        IncrementConcertTicketQuality(currentItem);
                    }
                }
            }
            else if (IsConcertTicket(currentItem))
            {
                if (currentItem.Quality < 50)
                {
                    currentItem.Quality = currentItem.Quality + 1;

                    if (IsConcertTicket(currentItem))
                    {
                        IncrementConcertTicketQuality(currentItem);
                    }
                }
            }
            else
            {
                if (currentItem.Quality > 0)
                {
                    if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        currentItem.Quality = currentItem.Quality - 1;
                    }
                }
            }

            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
            {
                currentItem.SellIn = currentItem.SellIn - 1;
            }

            if (currentItem.SellIn < 0)
            {
                if (currentItem.Name != "Aged Brie")
                {
                    if (currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (currentItem.Quality > 0)
                        {
                            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                currentItem.Quality = currentItem.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        currentItem.Quality = currentItem.Quality - currentItem.Quality;
                    }
                }
                else
                {
                    IncrementQualityWithBoundsCheck(currentItem);
                }
            }
        }

        private static bool IsAgedBrie(Item currentItem)
        {
            return currentItem.Name == "Aged Brie";
        }

        private static void IncrementConcertTicketQuality(Item currentItem)
        {
            if (currentItem.SellIn < 11)
            {
                IncrementQualityWithBoundsCheck(currentItem);
            }

            if (currentItem.SellIn < 6)
            {
                IncrementQualityWithBoundsCheck(currentItem);
            }
        }

        private static bool IsConcertTicket(Item currentItem)
        {
            return currentItem.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static void IncrementQualityWithBoundsCheck(Item currentItem)
        {
            if (currentItem.Quality < 50)
            {
                currentItem.Quality = currentItem.Quality + 1;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
