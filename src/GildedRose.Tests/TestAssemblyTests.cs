using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        protected internal readonly Program app;

        public TestAssemblyTests()
        {
            app = new Program()
            {
                Items = new List<Item>()
            };
        }

        [Fact]
        public void Standard_Item_Degrades_By_1()
        {
            app.Items.Add(StandardItem(sellIn: 10, quality: 10));

            app.UpdateQuality();

            Assert.Equal(9, app.Items[0].Quality);
            Assert.Equal(9, app.Items[0].SellIn);
        }

        [Fact]
        public void Quality_Never_Drops_Below_Zero()
        {
            app.Items.Add(StandardItem(sellIn: 0, quality: 0));
            app.Items.Add(StandardItem(sellIn: -1, quality: 0));

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(0, app.Items[1].Quality);
        }

        [Fact]
        public void SellIn_Can_Drop_Below_Zero()
        {
            app.Items.Add(StandardItem(sellIn: 0, quality: 0));

            app.UpdateQuality();

            Assert.Equal(-1, app.Items[0].SellIn);

        }

        [Fact]
        public void Quality_Degrades_Twice_As_Fast_After_Sell_By_Date()
        {
            app.Items.Add(StandardItem(sellIn: 0, quality: 10));

            app.UpdateQuality();

            Assert.Equal(8, app.Items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_Increases_In_Value_As_It_Ages()
        {
            app.Items.Add(BrieItem(sellIn: 10, quality: 10));

            app.UpdateQuality();

            Assert.Equal(11, app.Items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_Increases_Twice_As_Fast_After_Its_Sell_By_Date()
        {
            app.Items.Add(BrieItem(sellIn: 0, quality: 10));
            app.Items.Add(BrieItem(sellIn: -1, quality: 10));

            app.UpdateQuality();

            Assert.Equal(12, app.Items[0].Quality);
            Assert.Equal(12, app.Items[1].Quality);
        }

        private Item BrieItem(int sellIn, int quality)
        {
            return new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        private static Item StandardItem(int sellIn, int quality)
        {
            return new Item { Name = "Standard boring item", SellIn = sellIn, Quality = quality };
        }
    }
}