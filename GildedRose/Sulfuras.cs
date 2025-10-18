namespace GildedRoseKata
{
    public class Sulfuras : Item
    {
        public int SellInFactor { get; set; } = 1;

        public Sulfuras(string Name, int SellIn, int Quality)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
        } 
    }
}