using System;

namespace GildedRoseKata;

public class RegularItem : Item, IUpdateableItem
{
    public bool IsNonDegradable { get; set; } = false;
    public int QualityFactor { get; private set; }
    public bool IsIncrementingFactor { get; private set; } = false;
    public int SellInFactor { get; set; } = 1;

    public RegularItem(string Name, int SellIn, int Quality)
    {
        this.Name = Name;
        this.SellIn = SellIn;
        this.Quality = Quality;
    }

    public void UpdateItem()
    {
        ProcessSellInDate();
        ProcessQuality();
    }

    private void ProcessQuality()
    {
        Quality -= QualityFactor;
        Quality = Math.Clamp(Quality, 0, 50);
    }

    private void ProcessSellInDate()
    {
        SellIn -= SellInFactor;
        QualityFactor = SellIn switch
        {
            <= 0 => 2,
            _ => 1,
        };
    }
}