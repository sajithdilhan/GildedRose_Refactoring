namespace GildedRoseKata
{
    public abstract class AbstractItem : Item, IUpdateableItem
    {
        public int QualityFactor { get; set; }
        public int SellInFactor { get; set; } = 1;
        public abstract void UpdateItem();
    }
}
