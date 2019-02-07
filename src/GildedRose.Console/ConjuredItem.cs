namespace GildedRose.Console
{
    public class ConjuredItem : Item
    {
        public override void UpdateQuality()
        {
            DecrementQuality();
            DecrementQuality();
        }
    }
}