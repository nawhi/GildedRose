namespace GildedRose.Console
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

        public virtual void UpdateQuality()
        {
            DecrementQuality();
            DecrementSellIn();
            if (IsExpired())
            {
                DecrementQuality();
            }
        }

        public void DecrementSellIn()
        {
            SellIn = SellIn - 1;
        }

        public void DecrementQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}