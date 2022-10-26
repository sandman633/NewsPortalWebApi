using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model;
using System.Collections.Generic;
using System.Linq;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public class DbContextHelper
    {
        public WebApiContext WebApiContext { get; set; }
        public DbContextHelper(bool consistency)
        {
            var builder = new DbContextOptionsBuilder<WebApiContext>();
            builder.UseInMemoryDatabase("UNIT_TEST_DB").ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            var options = builder.Options;
            WebApiContext = new WebApiContext(options);
            if (consistency)
            {
                WebApiContext.Database.EnsureDeleted();
                WebApiContext.Database.EnsureCreated();
            }
            #region seed Db
            if (!WebApiContext.Users.Any())
            {
                WebApiContext.AddRange(UserHelper.GetMany(2));
                var groups = new Dictionary<int, string>()
                {
                   { 1,"GroupNewsAdmin"},
                   { 2,"GroupCommentsAdmin"},
                   { 3,"GroupNewsUser"},
                   { 4,"GroupCommentsUser"},
                };

                WebApiContext.AddRange(GroupHelper.GetMany(groups));
                WebApiContext.AddRange(NewsHelper.GetMany());
                WebApiContext.AddRange(CommentsHelper.GetMany());
                var userGroupIds = new List<KeyValuePair<int, int>>()
                {
                    new KeyValuePair<int, int>(1,1)
                };
                WebApiContext.AddRange(UserGroupHelper.GetMany(userGroupIds));
                var fullRights = (short)(Permissions.Read | Permissions.Create | Permissions.Update | Permissions.Delete);
                var readRights = (short)(Permissions.Read);
                var groupPolicies = new Dictionary<int, IEnumerable<KeyValuePair<string, short>>>()
                {
                   { 1,new[]
                        {
                            new KeyValuePair<string,short>("News",fullRights),
                        }
                   },
                   { 2,new[]
                        {
                            new KeyValuePair<string,short>("Comments",readRights),
                        }
                   },
                   { 3,new[]
                        {
                            new KeyValuePair<string,short>("News",readRights),
                        }
                   },
                   { 4,new[]
                        {
                            new KeyValuePair<string,short>("Comments",readRights),
                        }
                   }
                };
                WebApiContext.AddRange(GroupPolicyHelper.GetMany(groupPolicies));
            }
            WebApiContext.SaveChanges();
            #endregion
        }
    }
}
