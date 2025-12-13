using System;

namespace N9.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public bool IsLocked { get; set; }
        public int RemainingLockSeconds { get; set; }
    }
}
