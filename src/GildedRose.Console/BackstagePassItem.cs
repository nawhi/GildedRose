namespace GildedRose.Console
{
    public class BackstagePassItem : Item
    {
        public BackstagePassItem()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void UpdateQuality()
        {
            IncrementConcertTicketQuality();
            DecrementSellIn();
            if (IsExpired())
            {
                Quality = 0;
            }
        }

        private void IncrementConcertTicketQuality()
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
    }
}