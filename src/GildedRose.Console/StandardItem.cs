namespace GildedRose.Console
{
    public class StandardItem: Item
    {
        public override void UpdateQuality()
        {
            DecrementQuality();
            DecrementSellIn();
            if (IsExpired())
            {
                DecrementQuality();
            }
        }
    }
}
