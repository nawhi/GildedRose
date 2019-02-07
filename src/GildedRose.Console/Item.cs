using System;
using System.CodeDom;

namespace GildedRose.Console
{
    public abstract class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public abstract void UpdateQuality();

        protected bool IsExpired()
        {
            return SellIn < 0;
        }

        protected void IncrementQualityWithBoundsCheck()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        protected void DecrementSellIn()
        {
            SellIn = SellIn - 1;
        }

        protected void DecrementQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}