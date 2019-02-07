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

        public bool IsConcertTicket()
        {
            return Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public bool IsAgedBrie()
        {
            return Name == "Aged Brie";
        }

        public virtual void UpdateQuality()
        {
            if (IsAgedBrie())
            {
                IncrementQualityWithBoundsCheck();
            }
            else if (IsConcertTicket())
            {
                IncrementConcertTicketQuality();
            }
            else
            {
                DecrementQuality();
            }

            DecrementSellIn();

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

        private void DecrementSellIn()
        {
            SellIn = SellIn - 1;
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