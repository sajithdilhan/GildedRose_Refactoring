using System;

namespace GildedRoseKata
{
    public class AgedBrie : AbstractItem, IUpdateableItem
    {
        public AgedBrie(string Name, int SellIn, int Quality)
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
            Quality += QualityFactor;
            Quality = Math.Clamp(Quality, 0, 50);
        }

        private void ProcessSellInDate()
        {
            SellIn -= SellInFactor;
            QualityFactor = 1;
        }
    }
}