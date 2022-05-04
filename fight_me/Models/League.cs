namespace fight_me.Models
{
  public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Img { get; set; }
        public int MinElo { get; set; }
        public int MaxElo { get; set; }
    }
}