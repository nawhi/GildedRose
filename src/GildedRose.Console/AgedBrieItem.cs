namespace GildedRose.Console
{
    public class AgedBrieItem : Item
    {
        public override void UpdateQuality()
        {
            IncrementQualityWithBoundsCheck();
            DecrementSellIn();
            if (IsExpired())
            {
                IncrementQualityWithBoundsCheck();
            }
        }
    }
}