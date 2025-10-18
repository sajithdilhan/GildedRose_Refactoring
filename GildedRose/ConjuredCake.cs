using System;

namespace GildedRoseKata
{
    public class ConjuredCake : Item, IUpdateableItem
    {
        public int QualityFactor { get; private set; }
        public int SellInFactor { get; set; } = 1;

        public ConjuredCake(string Name, int SellIn, int Quality)
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
            QualityFactor = 2;
            QualityFactor = SellIn switch
            {
                <= 0 => 4,
                _ => 2,
            };
        }
    }
}
