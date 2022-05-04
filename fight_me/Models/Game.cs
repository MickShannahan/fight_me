namespace fight_me.Models
{
  public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Subtitle { get; set; }
        public string Img  { get; set; }
        public string  Icon { get; set; }
        public string CoverImg { get; set; }
        public string PosterImg { get; set; }
        public string ColorPrimary { get; set; }
        public string ColorSecondary { get; set; }
        public int? Popularity { get; set; }
    }

    public class GameLeague : Game
    {
      public League? League { get; set; }
      public string AccountId { get; set; }      
      public int Elo { get; set; }
      public int Matches { get; set; }
      public int RankedElo { get; set; }
      public int RankedMatches { get; set; }
    }
}