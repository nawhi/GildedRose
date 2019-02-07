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

        [Fact]
        public void Item_Quality_Never_Goes_Above_50()
        {
            app.Items.Add(BrieItem(sellIn: 5, quality: 49));
            app.Items.Add(BrieItem(sellIn: -1, quality: 49));

            app.UpdateQuality();
            app.UpdateQuality();

            Assert.Equal(50, app.Items[0].Quality);
            Assert.Equal(50, app.Items[1].Quality);

        }

        [Fact]
        public void Backstage_Passes_Increase_In_Quality()
        {
            app.Items.Add(BackStagePassItem(sellIn: 15, quality: 10));

            app.UpdateQuality();

            Assert.Equal(11, app.Items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Increase_In_Quality_By_2_When_SellIn_Is_10_Or_Less()
        {
            app.Items.Add(BackStagePassItem(sellIn: 10, quality: 10));
            app.Items.Add(BackStagePassItem(sellIn: 9, quality: 10));

            app.UpdateQuality();

            Assert.Equal(12, app.Items[0].Quality);
            Assert.Equal(12, app.Items[1].Quality);
        }

        [Fact]
        public void Backstage_Passes_Increase_In_Quality_By_3_When_SellIn_Is_5_Or_Less()
        {
            app.Items.Add(BackStagePassItem(sellIn: 5, quality: 10));
            app.Items.Add(BackStagePassItem(sellIn: 4, quality: 10));
            app.Items.Add(BackStagePassItem(sellIn: 1, quality: 10));

            app.UpdateQuality();

            Assert.Equal(13, app.Items[0].Quality);
            Assert.Equal(13, app.Items[1].Quality);
            Assert.Equal(13, app.Items[2].Quality);
        }

        [Fact]
        public void Backstage_Passes_Quality_Goes_to_0_When_SellIn_Is_0_Or_Less()
        {
            app.Items.Add(BackStagePassItem(sellIn: 0, quality: 10));
            app.Items.Add(BackStagePassItem(sellIn: -1, quality: 0));

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
            Assert.Equal(0, app.Items[1].Quality);
        }

        [Fact]
        public void Sulfuras_Never_Has_To_Be_Sold()
        {
            app.Items.Add(SulfurasItem(sellIn: 5));

            app.UpdateQuality();

            Assert.Equal(5, app.Items[0].SellIn);
        }

        [Fact]
        public void Sulfuras_Never_Decreases_In_Quality()
        {
            app.Items.Add(SulfurasItem(sellIn: 5));

            app.UpdateQuality();

            Assert.Equal(80, app.Items[0].Quality);
        }

        [Fact]
        public void Conjured_Items_Degrade_Twice_As_Fast_As_Normal_Items()
        {
            app.Items.Add(new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

            app.UpdateQuality();

            Assert.Equal(4, app.Items[0].Quality);
        }

        private Item SulfurasItem(int sellIn)
        {
            return new SulfurasItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 };
        }

        private Item BackStagePassItem(int sellIn, int quality)
        {
            return new BackstagePassItem { SellIn = sellIn, Quality = quality };
        }

        private Item BrieItem(int sellIn, int quality)
        {
            return new AgedBrieItem { SellIn = sellIn, Quality = quality };
        }

        private static Item StandardItem(int sellIn, int quality)
        {
            return new StandardItem { Name = "Standard boring item", SellIn = sellIn, Quality = quality };
        }
    }
}