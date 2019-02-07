namespace GildedRose.Console
{
    public class BackstagePassItem : Item
    {
        public override void UpdateQuality()
        {
            IncrementConcertTicketQuality();
            DecrementSellIn();
            if (IsExpired())
            {
                Quality = 0;
            }
        }
    }
}