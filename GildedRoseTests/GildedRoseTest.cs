using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory]
    [InlineData("Elixir of the Mongoose", 11, 10, 10, 9)]
    [InlineData("Elixir of the Mongoose", 0, 10, -1, 8)]
    [InlineData("Elixir of the Mongoose", 1, 5, 0, 3)]
    public void NormalItem_DegradeQuality(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new RegularItem(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(expected: sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }

    [Theory]
    [InlineData(Constants.AgedBrie, 11, 10, 10, 11)]
    [InlineData(Constants.AgedBrie, 0, 10, -1, 11)]
    public void AgedBrie_IncresedQuality(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new AgedBrie(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }

    [Theory]
    [InlineData(Constants.Sulfuras, 20, 80, 20, 80)]
    [InlineData(Constants.Sulfuras, 0, 80, 0, 80)]
    public void Sulfuras_Quality_DoesNotChange(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new Sulfuras(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }

    [Theory]
    [InlineData(Constants.BackstagePasses, 20, 10, 19, 11)]
    [InlineData(Constants.BackstagePasses, 10, 10, 9, 12)]
    [InlineData(Constants.BackstagePasses, 4, 5, 3, 8)]
    [InlineData(Constants.BackstagePasses, 0, 5, -1, 0)]
    public void Backstage_Returns_Expected(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new BackstagePass(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }

    [Theory]
    [InlineData(Constants.ConjuredItem, 20, 10, 19, 8)]
    [InlineData(Constants.ConjuredItem, 0, 10, -1, 6)]
    public void Conjured_QualityDoubleDegrade_AfterOneDay(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new ConjuredCake(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }

    [Theory]
    [InlineData(Constants.CheeseCake, 20, 8, 19, 4)]
    [InlineData(Constants.CheeseCake, 0, 10, -1, 0)]
    public void CheeseCake_Quality4XDegrade(string itemName, int sellIn, int quality, int sellInexpected, int qualityExpected)
    {
        IList<Item> Items = [new CheeseCake(itemName, sellIn, quality)];
        GildedRose app = new(Items);
        app.UpdateQuality();
        Assert.Equal(itemName, Items[0].Name);
        Assert.Equal(sellInexpected, Items[0].SellIn);
        Assert.Equal(qualityExpected, Items[0].Quality);
    }
}