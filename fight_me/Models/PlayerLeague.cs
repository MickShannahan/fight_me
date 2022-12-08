namespace fight_me.Models
{
  public class PlayerLeague
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int GameId { get; set; }
        public int Elo { get; set; }
        public int Matches { get; set; }
        public int RankedElo { get; set; }
        public int RankedMatches { get; set; }
        public int RankedDownSaves { get; set; }

        public Profile? Account { get; set; }
        public Game? Game { get; set; }
        public League? League { get; set; }
    }
}