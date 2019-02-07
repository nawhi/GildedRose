namespace GildedRose.Console
{
    public class AgedBrieItem : Item
    {
        public AgedBrieItem()
        {
            Name = "Aged Brie";
        }

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