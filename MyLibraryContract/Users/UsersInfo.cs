using System;
namespace AlquerqueContract.Users
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public DateTime LastLogTime { get; set; }

    }
}
