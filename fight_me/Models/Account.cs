namespace fight_me.Models
{

    public class Profile {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; } 
        public int Elo { get; set; }
        public int rankedElo { get; set; }
        public int MatchesWon { get; set; }
    }
  public class Account : Profile
    {
        public string Email { get; set; }
    
    }
}