using System;

namespace N9.Models
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public DateTime AttemptTime { get; set; }
        public bool Success { get; set; }
        public string IpAddress { get; set; }
    }
}
