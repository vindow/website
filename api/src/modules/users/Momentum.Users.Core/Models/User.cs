using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using momentum.framework.core;
using Momentum.Framework.Core;

namespace Momentum.Users.Core.Models
{
    public class User : AggregateRoot
    {
        public User(Guid id)
        {
            Id = id;

            this.AddEvent(new Momentum.Framework.Core.Events.UserEvents.UserCreatedEvent()
            {
                UserId = id
            });

        }
        public Guid Id { get; private set; }

        public Enums.Role Role { get; private set; }
        public Enums.Ban Ban { get; private set; }

        public Authentication Authentication { get; private set; }

        public static User FromUser(User user)
        {

            var newUser = new User(Guid.NewGuid())
            {
                Ban = user.Ban,
                Role = user.Role
            };

            newUser.AddEvent(new Momentum.Framework.Core.Events.UserEvents.UserMigratedEvent()
            {
                FromUserId = user.Id,
                UserId = newUser.Id
            });

            return newUser;
        }

        public void ApplyToken(string refreshToken, DateTime issuedAt)
        {
            Authentication = new Authentication()
            {
                IssuedAt = issuedAt,
                RefreshToken = refreshToken
            };
        }

        public void RevokeToken()
        {
            Authentication = null;
        }




        //        public void UpdateSteamInfo()
        //        {
        //            if (newProfile.country && usr.country !== newProfile.country)
        //                usr.country = newProfile.country;
        //            if ((usr.bans & module.exports.Ban.BANNED_AVATAR) === 0)
        //                usr.avatarURL = newProfile.avatarURL;
        //            if ((usr.bans & module.exports.Ban.BANNED_ALIAS) === 0 && !usr.aliasLocked)
        //                usr.alias = newProfile.alias;
        //            return usr.save();
        //        }

        //        createPlaceholder: (alias) => {
        //		return User.create({
        //			alias: alias,
        //			roles: module.exports.Role.PLACEHOLDER,
        //			profile: {},
        //		}, {
        //			include: [
        //                Profile,
        //            ]
        //});
        //	},
    }


}
