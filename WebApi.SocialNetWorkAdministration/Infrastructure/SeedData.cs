using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Domain;
using System;
using System.Linq;
using WebApi.SocialNetWorkAdministration.Infrastructure.AuthOptions;

namespace WebApi.SocialNetWorkAdministration.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            WebApiContext context = app.ApplicationServices.CreateScope().ServiceProvider
    .GetRequiredService<WebApiContext>();
            context.Database.EnsureCreated();
            if (context.Database.IsInMemory()==false)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            if (!context.Users.Any())
            {
                #region users
                context.Users.AddRange(
                    new User
                    {
                        Name = "Sam",
                        Email = "Sam@gmail.com",
                        Age = 20,
                        Surname = "Johns",
                        Id = 1,
                        Password = "P@ssw0rd",
                        PhoneNumber = "224424",
                    },
                    new User
                    {
                        Name = "Doo",
                        Email =  "Doo@gmail.com",
                        Age = 20,
                        Surname = "Rames",
                        Id = 2,
                        Password = "P@ssw0rd",
                        PhoneNumber = "2wewe24424",
                    });
                #endregion

                #region news
                context.News.AddRange(
                    new News
                    {
                        Id = 1,
                        Title = "News1",
                        Text = "Text1",
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                    },
                    new News
                    {
                        Id = 2,
                        Title = "News2",
                        Text = "Text2",
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 2,
                    }, new News
                    {
                        Id = 3,
                        Title = "News3",
                        Text = "Text3",
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 2,
                    });
                #endregion

                #region comments
                context.Comments.AddRange(
                    new Comments
                    {
                        Id = 1,
                        NewsId = 1,
                        CommentState = 0,
                        Root = 0,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                        Text = "Comment1 news1",
                    }, new Comments
                    {
                        Id = 2,
                        NewsId = 1,
                        CommentState = 0,
                        Root = 1,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                        Text = "Linked Comment to 1 news1",
                        LinkedCommentId = 1,
                    }, new Comments
                    {
                        Id = 3,
                        NewsId = 1,
                        CommentState = 0,
                        Root = 0,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                        Text = "Linked Comment to 2 news1",
                        LinkedCommentId = 2,
                    }, new Comments
                    {
                        Id = 4,
                        NewsId = 1,
                        CommentState = 0,
                        Root = 0,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                        Text = "Comment1 news1",
                    }, new Comments
                    {
                        Id = 5,
                        NewsId = 2,
                        CommentState = 0,
                        Root = 0,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        UserId = 1,
                        Text = "Comment5 news2",
                    });
                #endregion

                #region userPolicies
                context.UsersPolicies.AddRange(
                    new UserPolicy
                    {
                        Id = 1,
                        UserId = 1,
                        PolicyType = "News",
                        PolicyValue = (short)(Permissions.Read | Permissions.Create | Permissions.Update | Permissions.Delete),
                    },
                    new UserPolicy
                    {
                        Id = 2,
                        UserId = 1,
                        PolicyType = "Comments",
                        PolicyValue = (short)(Permissions.Read | Permissions.Create | Permissions.Update | Permissions.Delete),
                    },
                    new UserPolicy
                    {
                        Id = 3,
                        UserId = 2,
                        PolicyType = "News",
                        PolicyValue = (short)(Permissions.Read),
                    },
                    new UserPolicy
                    {
                        Id = 4,
                        UserId = 2,
                        PolicyType = "Comments",
                        PolicyValue = (short)(Permissions.Read),
                    });
                #endregion

                context.SaveChanges();
            }
        }
    }
}
