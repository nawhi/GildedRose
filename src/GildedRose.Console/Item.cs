﻿namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public bool IsExpired()
        {
            return SellIn < 0;
        }

        public void IncrementQualityWithBoundsCheck()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        public void IncrementConcertTicketQuality()
        {
            IncrementQualityWithBoundsCheck();

            if (SellIn < 11)
            {
                IncrementQualityWithBoundsCheck();
            }

            if (SellIn < 6)
            {
                IncrementQualityWithBoundsCheck();
            }
        }

        public bool IsConcertTicket()
        {
            return Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public bool IsAgedBrie()
        {
            return Name == "Aged Brie";
        }

        public bool IsNotSulfuras()
        {
            return Name != "Sulfuras, Hand of Ragnaros";
        }

        public void UpdateQuality()
        {
            if (!IsNotSulfuras())
            {

            }
            else
            {
                if (IsAgedBrie())
                {
                    IncrementQualityWithBoundsCheck();
                }
                else if (IsConcertTicket())
                {
                    IncrementConcertTicketQuality();
                }
                else if (IsNotSulfuras())
                {
                    DecrementQuality();
                }

                if (IsNotSulfuras())
                {
                    SellIn = SellIn - 1;
                }

                if (IsExpired())
                {
                    if (IsAgedBrie())
                    {
                        IncrementQualityWithBoundsCheck();
                    }
                    else if (IsConcertTicket())
                    {
                        Quality = 0;
                    }
                    else
                    {
                        DecrementQuality();
                    }
                }
            }
           
        }

        private void DecrementQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}