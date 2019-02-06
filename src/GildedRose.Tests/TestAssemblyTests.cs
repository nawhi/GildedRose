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

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
        }

        [Fact]
        public void SellIn_Can_Drop_Below_Zero()
        {
            app.Items.Add(StandardItem(sellIn: 0, quality: 0));

            app.UpdateQuality();

            Assert.Equal(-1, app.Items[0].SellIn);

        }

        private static Item StandardItem(int sellIn, int quality)
        {
            return new Item { Name = "Standard boring item", SellIn = sellIn, Quality = quality };
        }
    }
}