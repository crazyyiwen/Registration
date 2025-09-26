namespace Registration.models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string password { get; set; } = null!;
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public bool isadminuser { get; set; }
        public string? permissions { get; set; }
    }
}
