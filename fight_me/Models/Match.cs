namespace fight_me.Models
{
  public class Match
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public Profile Account { get; set; }
    }
}