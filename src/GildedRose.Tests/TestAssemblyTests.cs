using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void Standard_Item_Degrades_By_1()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Standard boring item", SellIn = 10, Quality = 10}
                }
            };

            app.UpdateQuality();

            Assert.Equal(9, app.Items[0].Quality);
            Assert.Equal(9, app.Items[0].SellIn);
        }

        [Fact]
        public void Quality_Never_Drops_Below_Zero()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Standard boring item", SellIn = 0, Quality = 0}
                }
            };

            app.UpdateQuality();

            Assert.Equal(0, app.Items[0].Quality);
        }

        [Fact]
        public void SellIn_Can_Drop_Below_Zero()
        {
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Standard boring item", SellIn = 0, Quality = 0}
                }
            };

            app.UpdateQuality();

            Assert.Equal(-1, app.Items[0].SellIn);

        }
    }
}