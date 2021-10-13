using System;
using System.Collections.Generic;
using System.Linq;
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
                    new Tag() { Name="WhatManLiveBy"},
                    new Tag() { Name="WhatsApp"},
                    new Tag() { Name="Apple"},
                    new Tag() { Name="IOS"},
                    new Tag() { Name="App"},
                    new Tag() { Name="Facebook"},
                    new Tag() { Name="Google"},
                    new Tag() { Name="Guitar"},
                    new Tag() { Name="Musics"}
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
                    },
                 new Post()
                 {
                     Title="A new feature is added to WhatsApp's iOS app that converts voice messages to text",
                     Thumbnail="WhatsApp.png",
                     IsPublished=false,
                     PublishDate=DateTime.Now,
                     Summary="WhatsApp is coming to a feature that we have been waiting for a long time, which will make those who love to send voice messages happy. WhatsApp, which is under the umbrella of Facebook, will now allow us to see voice messages in text format whenever we want.",
                     Content="WhatsApp, the world's most popular messaging application, which was fined 225 million euros for violating the personal data protection law in Europe in the past weeks, is coming with a long-awaited feature that will make those who love to send voice messages happy. WhatsApp, which is under the umbrella of Facebook, will now allow us to see voice messages in text format whenever we want.With the feature revealed by WABetaInfo, WhatsApp is working on a new voicemail transcription that will be done entirely on the user's device, meaning that WhatsApp and Facebook will not be able to access these messages. WABetaInfo states that the user's voice messages will help Apple improve its speech recognition technology, and that this is a completely optional feature. In other words, not every voice message will be automatically translated into text, if the user wishes, he or she will use this feature.The first time you use the transcription of the voice message, WhatsApp will send you a notification saying WhatsApp Wants to Access Speech Recognition. The content of the notification reads, Speech data from this app will be sent to Apple to process your requests. This will also help Apple improve speech recognition technology. Convert voice messages to text. statement is included.If you approve this notification, your voice messages are automatically ready to be converted to text. After accepting the application to access speech recognition, users will be able to try the transcription service with the Transcript section.The aforementioned feature is still under development, so WhatsApp's public beta testers are currently unable to try this feature. It remains unclear when the feature will be activated or whether it will come to Android."
                 },
                 new Post()
                 {
                     Title="Guitar tuning feature came to Google searches",
                     Thumbnail="google.png",
                     IsPublished=false,
                     PublishDate=DateTime.Now.AddDays(-4),
                     Summary="You can access the feature by typing Google Tuner in the search field. The search engine, which supports search results such as weather, currency, time zone and calculator with widgets, offers musicians a new widget.",
                     Content="Google searches allows you to tune guitar using your phone's microphone, thanks to its newly released feature. The feature, which we can call Google Tuner, was released last week. You can access the feature by typing Google Tuner in the search field. In fact, many digital tuning applications have been published so far. There are different options that musicians can use whenever they want. So it's surprising that Google offers services in this area.Still, the search engine, which supports search results such as weather, currency, time zone and calculator with widgets, offers musicians a new widget. Those who have tried it say that the feature gains functionality with the sound quality of the device you are using. It states that if you try it on Safari with iPhone12 Pro or Edge with Blue Snowball USB microphone, the feature has no difficulty in getting sound. However, when tested on Android devices via Chrome, the feature is said to have difficulty receiving sound. Despite what has been said, our advice is to try and see the results yourself.When I tried it on a Mac with sound, but not with a guitar, I found that the feature did not have any difficulty in getting sound. However, unlike guitar tuning, I was content with seeing the equivalents of the sounds I gave in guitar chords. Of course, when my voice did not vibrate, I also met with the correct setting warning.Adding features such as Humming to Search to the Search process and Short videos tab to search results in 2020, Google does not stop renewing itself. However, especially voice-oriented features can contribute to Google's improvement of voice command search capabilities."
                 }
            };
            var postCategories = new List<PostCategory>()
            {
                new PostCategory()
                {
                    Category=categories[3],
                    Post=posts[0]
                },             
                new PostCategory()
                {
                    Category=categories[0],
                    Post=posts[1]
                },                
                new PostCategory()
                {
                    Category=categories[4],
                    Post=posts[1]
                },                  
                new PostCategory()
                {
                    Category=categories[0],
                    Post=posts[2]
                },                
                new PostCategory()
                {
                    Category=categories[4],
                    Post=posts[2]
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
                },                
                new PostTag()
                {
                    Tag=tags[5],
                    Post=posts[1]
                },              
                new PostTag()
                {
                    Tag=tags[6],
                    Post=posts[1]
                },               
                new PostTag()
                {
                    Tag=tags[7],
                    Post=posts[1]
                },               
                new PostTag()
                {
                    Tag=tags[8],
                    Post=posts[1]
                },               
                new PostTag()
                {
                    Tag=tags[9],
                    Post=posts[1]
                },                
                new PostTag()
                {
                    Tag=tags[6],
                    Post=posts[2]
                },                
                new PostTag()
                {
                    Tag=tags[7],
                    Post=posts[2]
                },                
                new PostTag()
                {
                    Tag=tags[10],
                    Post=posts[2]
                },                
                new PostTag()
                {
                    Tag=tags[11],
                    Post=posts[2]
                },                
                new PostTag()
                {
                    Tag=tags[12],
                    Post=posts[2]
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
