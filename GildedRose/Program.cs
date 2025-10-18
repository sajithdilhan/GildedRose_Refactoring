using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        IList<Item> items = new List<Item>
        {
            new RegularItem("+5 Dexterity Vest", 10,20 ),
            new AgedBrie("Aged Brie", 2, 0),
            new RegularItem("Elixir of the Mongoose", 5, 7),
            new Sulfuras("Sulfuras, Hand of Ragnaros", 0, 80),
            new Sulfuras("Sulfuras, Hand of Ragnaros", -1, 80),
            new BackstagePass("Backstage passes to a TAFKAL80ETC concert",5,20),
            new BackstagePass("Backstage passes to a TAFKAL80ETC concert",10,49),
            new BackstagePass("Backstage passes to a TAFKAL80ETC concert",5,9),
            new ConjuredCake("Conjured Mana Cake", 3,  6),
            new CheeseCake("Cheese Cake", 5, 7)
        };

        var app = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}