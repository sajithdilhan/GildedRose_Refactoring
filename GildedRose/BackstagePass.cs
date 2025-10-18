using System;

namespace GildedRoseKata
{
    public class BackstagePass : AbstractItem
    {
        public BackstagePass(string Name, int SellIn, int Quality)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
        }

        public override void UpdateItem()
        {
            ProcessSellInDate();
            ProcessQuality();
        }

        private void ProcessQuality()
        {
            if (SellIn < 0)
            {
                Quality = 0;
                return;
            }
            Quality += QualityFactor;
            Quality = Math.Clamp(Quality, 0, 50);
        }

        private void ProcessSellInDate()
        {
            SellIn -= SellInFactor;
            QualityFactor = SellIn switch
            {
                > 11 => 1,
                > 6 => 2,
                > 0 => 3,
                _ => 0,
            };
        }
    }
}