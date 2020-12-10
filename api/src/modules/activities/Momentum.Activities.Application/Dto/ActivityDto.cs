using System;
using System.Collections.Generic;
using System.Text;

namespace Momentum.Activities.Application.Dto
{
    public class ActivityDto
    {
        public Guid id { get; set; }
        public int type { get; set; }
        public int data { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Guid userID { get; set; }
        public User user { get; set; }
    }
    public class User
    {
        public string id { get; set; }
        public string alias { get; set; }
        public string avatarURL { get; set; }
        public int roles { get; set; }
        public int bans { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Profile profile { get; set; }
    }
    public class Profile
    {
        public int id { get; set; }
        public string userID { get; set; }
        public string bio { get; set; }
        public string twitterName { get; set; }
        public string discordName { get; set; }
        public string youtubeName { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }


}
