using System;

namespace GildedRoseKata
{
    public class AgedBrie : Item, IUpdateableItem
    {
        public int QualityFactor { get; private set; }
        public int SellInFactor { get; set; } = 1;
        public AgedBrie(string Name, int SellIn, int Quality)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
        }

        public void UpdateItem()
        {
            QualityFactor = 1;
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
        }
    }
}
