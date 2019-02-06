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

            Assert.Equal(app.Items[0].Quality, 9);
            Assert.Equal(app.Items[0].SellIn, 9);
        }
    }
}