using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entertainment_Blog.DataAccess.Concrete
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<EntertainmentBlogContext>();
            context.Database.Migrate();
            var categories = new List<Category>() 
            {
                    new Category() { Name = "News" },
                    new Category() { Name = "Gossip" },
                    new Category() { Name = "Sport" },
                    new Category() { Name = "Books" },
                    new Category() { Name = "Technology" },
                    new Category() { Name = "Game" },
                    new Category() { Name = "Tv & Movies" },
                    new Category() { Name = "Musics" },
                    new Category() { Name = "Fashion" },
                    new Category() { Name = "Tasty" }
            };
            var tags = new List<Tag>()
            {
                    new Tag() { Name="Tolstoy"},
                    new Tag() { Name="Books"},
                    new Tag() { Name= "Literature"},
                    new Tag() { Name="Author"},
                    new Tag() { Name="WhatManLiveBy"}
            };
            var posts = new List<Post>()
            {
                 new Post() {
                        Title="What Man Live By",
                        Thumbnail="whatmanliveby.png",
                        IsPublished=false,
                        PublishDate=DateTime.Now.AddDays(-200),
                        Summary= "There are works that have influenced their readers for hundreds of years and have guided human behavior for generations. Undoubtedly, one of the most well-known of these is “What Does Man Live By?” It is the work of the famous writer L. N. Tolstoy.",
                        Content= "Lev Nikolayevich (1828-1910) Tolstoy is a writer who has built great works for Russian Literature with his books such as War and Peace, Anna Karenina, Resurrection. The sincerity, simplicity, and striking storytelling of the love of humanity, belief and inner world he deals with prompted the readers to think inwardly. When I started reading the book, there was only a shadow of having read it as a child years ago, what this mature man would see between the lines. The first story begins with the shoemaker Semyon, whose poverty-stricken business is not going well at all, with helping, dressing and feeding the naked young man who is in a difficult situation and who obviously has a problem, while returning home without being able to ask for money from the people who owe him. A great story, a great test of humanity, people keep asking themselves what would you do if it were you. While the finale ends with a surprise, three words of God remain in our minds: What is in man? What has not been given to man? What does man live with? The second story, He Who Doesn't Extinguish the Spark Can't Contain the Fire. It tells the series of events that started with the lack of tolerance of two families who were neighbors in village life and reached a frightening pace day by day. Again, the lessons to be learned are clear and very convincing. The experience of age is something to be listened to, for thousands of years the elders of every society represented wisdom. Perhaps this is not the case for the first time in the age of instagram and botox, the intergenerational knowledge perspective has opened up a lot as scissors. The name of the third story is Candle This story tells of a landed overlord's overseer who had his landed slaves tormented. Despite the past centuries, it is possible to adapt this story to the present with minor changes. There are still long working hours, fear of mobbing, insufficient wages and unemployment. The power of the story's karma to reflect on the person who does whatever is done is told in an impressive sequence of events. The fourth story, Does Man Need a Lot of Land? A story that is mentioned and referred to a lot in literature is human nature's greed and inexhaustible passion for possession. Everything starts with a claim, Poham, a simple villager, is defying the devil, Our only problem is little land! If I had as much land as I wanted, I would not be afraid of anyone, not even the devil! Fifth story Elijah. It tells the story of a well-established family that made its fortune by working hard with his wife, and made the guests well-hospitalized and drank, and I personally lived most of my life with this perspective."
                    }
            };
            var postCategories = new List<PostCategory>()
            {
                new PostCategory()
                {
                    Category=categories[3],
                    Post=posts[0]
                }
            };
            var postTags = new List<PostTag>()
            {
                new PostTag()
                {
                    Tag=tags[0],
                    Post=posts[0]
                },                
                new PostTag()
                {
                    Tag=tags[1],
                    Post=posts[0]
                },                
                new PostTag()
                {
                    Tag=tags[2],
                    Post=posts[0]
                },                
                new PostTag()
                {
                    Tag=tags[3],
                    Post=posts[0]
                }
            };
            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(categories);
                }                
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(tags);
                }                
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(posts);
                }                
                if (!context.PostCategories.Any())
                {
                    context.PostCategories.AddRange(postCategories);
                }                
                if (!context.PostTags.Any())
                {
                    context.PostTags.AddRange(postTags);
                }
                context.SaveChanges();
            }
        }
    }
}
