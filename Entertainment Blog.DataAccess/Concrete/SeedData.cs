using System;
using System.Collections.Generic;
using System.Linq;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entertainment_Blog.DataAccess.Concrete
{
    public static class SeedData
    {
        public static async void Seed(IApplicationBuilder app)
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
                    new Tag() { Name="Musics"},
                    new Tag() { Name="Celebrity"},
                    new Tag() { Name="LilyCollins"},
                    new Tag() { Name="Actress"},
                    new Tag() { Name="Charlie"},
                    new Tag() { Name="Wedding"},
                    new Tag() { Name="Director"}
            };
            var users = new List<ApplicationUser>() {
                new ApplicationUser()
                {
                    Name="Freya",
                    Surname="Allan",
                    UserName="Freyaallan",
                    NormalizedUserName="FREYAALLAN",
                    About="Hello, everyone I am Freya Allan. I am an actresss. I am 20 years old. Right now, I play the role Ciri in Witcher. ",
                    DateOfBirth=new DateTime(2001,9,6),
                    Country=Entity.Enums.CountryTypes.UnitedKingdom,
                    Email="freyaallan@gmail.com",
                    NormalizedEmail="FREYYAALLAN@GMAIL.COM",
                    Gender=Entity.Enums.GenderTypes.Female,
                    Job="Actress",
                    Picture="5716172.jpg",
                    Address="United Kingdom",
                    PhoneNumber="4547420254",
                    PhoneNumberConfirmed=true,
                    EmailConfirmed=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    ConfirmPassword="Witcherciri01",
                },
                new ApplicationUser()
                {
                    Name="Tom",
                    Surname="Hanks",
                    UserName="TomHanks01",
                    NormalizedUserName="TOMHANKS01",
                    About="Hello, everyone I am Tom Hanks. I am an actor. I played most popular films. Right now, I am writing some posts and I publish them in here. ",
                    DateOfBirth=new DateTime(1956,8,9),
                    Country=Entity.Enums.CountryTypes.Brazil,
                    Email="tomhanks01@hotmail.com",
                    NormalizedEmail="TOMHANKS01@HOTMAIL.COM",
                    Gender=Entity.Enums.GenderTypes.Male,
                    Job="Actor",
                    Picture="tomhanks.jpg",
                    Address="United Kingdom",
                    PhoneNumber="3547420254",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    ConfirmPassword="ForrestGump56",
                },
                new ApplicationUser()
                {
                    Name="Austin Richard",
                    Surname="Post",
                    UserName="PostMalone",
                    NormalizedUserName="POSTMALONE",
                    About="Hello, everyone I am Austin Richard Post, most people know me as Post Malone. I am a rapper. I love singing songs. I want to share my experience with you. ",
                    DateOfBirth=new DateTime(1995,8,4),
                    Country=Entity.Enums.CountryTypes.UnitedKingdom,
                    Email="autinrichardpost@hotmail.com",
                    NormalizedEmail="AUTINRICHARDPOST@HOTMAIL.COM",
                    Gender=Entity.Enums.GenderTypes.Male,
                    Job="Rapper",
                    Picture="postmalone.jpg",
                    Address="United Kingdom in New York",
                    PhoneNumber="7547420254",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    ConfirmPassword="Sunflower95"
                },
                new ApplicationUser()
                {
                    Name="İrem",
                    Surname="Bulut",
                    UserName="iremblt",
                    NormalizedUserName="IREMBLT",
                    About="Hello, everyone I am İrem Bulut. I am a student. I like reading posts and comments of them. ",
                    DateOfBirth=new DateTime(2000,4,12),
                    Country=Entity.Enums.CountryTypes.Turkey,
                    Email="irem_bulut_626@hotmail.com",
                    NormalizedEmail="IREM_BULUT_626@HOTMAIL.COM",
                    Gender=Entity.Enums.GenderTypes.Female,
                    Job="Student",
                    Picture="avatar3.jpg",
                    Address="Turkey in İstanbul",
                    PhoneNumber="5378445151",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    ConfirmPassword="İremblt00"
                },
                new ApplicationUser()
                {
                    Name="Kerem",
                    Surname="Can",
                    UserName="none",
                    NormalizedUserName="NONE",
                    About="Hello, everyone I am Kerem Can.",
                    DateOfBirth=new DateTime(2003,5,1),
                    Country=Entity.Enums.CountryTypes.Germany,
                    Email="none@hotmail.com",
                    NormalizedEmail="NONE@HOTMAIL.COM",
                    Gender=Entity.Enums.GenderTypes.Male,
                    Job="Librarian",
                    Address="Germany in Hamburg",
                    PhoneNumber="784513221",
                    SecurityStamp=Guid.NewGuid().ToString(),
                    ConcurrencyStamp=Guid.NewGuid().ToString(),
                    ConfirmPassword="fakeAccount03"
                }
            };
            var posts = new List<Post>()
            {
                 new Post() 
                 {
                     Title="What Man Live By",
                     Thumbnail="what-men-live-by-and-other-tales.jpg",
                     IsPublished=false,
                     PublishDate=DateTime.Now.AddDays(-200),
                     Summary= "There are works that have influenced their readers for hundreds of years and have guided human behavior for generations. Undoubtedly, one of the most well-known of these is “What Does Man Live By?” It is the work of the famous writer L. N. Tolstoy.",
                     User=users[1]
                 },
                 new Post()
                 {
                     Title="A new feature is added to WhatsApp's iOS app that converts voice messages to text",
                     Thumbnail="WhatsApp.png",
                     IsPublished=false,
                     PublishDate=DateTime.Now,
                     Summary="WhatsApp is coming to a feature that we have been waiting for a long time, which will make those who love to send voice messages happy. WhatsApp, which is under the umbrella of Facebook, will now allow us to see voice messages in text format whenever we want.",
                     User= users[0]
                 },
                 new Post()
                 {
                     Title="Guitar tuning feature came to Google searches",
                     Thumbnail="google.png",
                     IsPublished=false,
                     PublishDate=DateTime.Now.AddDays(-4),
                     Summary="You can access the feature by typing Google Tuner in the search field. The search engine, which supports search results such as weather, currency, time zone and calculator with widgets, offers musicians a new widget.",
                     User = users[2]
                 }
                 //new Post()
                 //{
                 //    Title="Lily Collins Is Married",
                 //    Thumbnail="lily-collins-bf-removebg.png",
                 //    IsPublished=true,
                 //    PublishDate=DateTime.Now.AddDays(-8),
                 //    Summary="Big congratulations are in order for Lily Collins and her partner, filmmaker Charlie McDowell, who officially became a married couple over the weekend! Lily Collins and Charlie McDowell tied the knot on Sept. 4 in Colorado. See photos of the bride and groom on their special day! ",
                 //}
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
                //new PostCategory()
                //{
                //    Category=categories[1],
                //    Post=posts[3]
                //}
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
                //new PostTag()
                //{
                //    Tag=tags[13],
                //    Post=posts[3]
                //},                
                //new PostTag()
                //{
                //    Tag=tags[14],
                //    Post=posts[3]
                //},                
                //new PostTag()
                //{
                //    Tag=tags[15],
                //    Post=posts[3]
                //},                
                //new PostTag()
                //{
                //    Tag=tags[16],
                //    Post=posts[3]
                //},                
                //new PostTag()
                //{
                //    Tag=tags[17],
                //    Post=posts[3]
                //},                
                //new PostTag()
                //{
                //    Tag=tags[18],
                //    Post=posts[3]
                //}
            };
            var contents = new List<Contents>() {
                new Contents()
                {
                    Text = "Lev Nikolayevich (1828-1910) Tolstoy is a writer who has built great works for Russian Literature with his books such as War and Peace, Anna Karenina, Resurrection. The sincerity, simplicity, and striking storytelling of the love of humanity, belief and inner world he deals with prompted the readers to think inwardly. When I started reading the book, there was only a shadow of having read it as a child years ago, what this mature man would see between the lines.The first story begins with the shoemaker Semyon, whose poverty-stricken business is not going well at all, with helping, dressing and feeding the naked young man who is in a difficult situation and who obviously has a problem, while returning home without being able to ask for money from the people who owe him.A great story, a great test of humanity, people keep asking themselves what would you do if it were you. While the finale ends with a surprise, three words of God remain in our minds: What is in man? What has not been given to man? What does man live with? The second story, He Who Doesn't Extinguish the Spark Can't Contain the Fire. It tells the series of events that started with the lack of tolerance of two families who were neighbors in village life and reached a frightening pace day by day. Again, the lessons to be learned are clear and very convincing. The experience of age is something to be listened to, for thousands of years the elders of every society represented wisdom.Perhaps this is not the case for the first time in the age of instagram and botox, the intergenerational knowledge perspective has opened up a lot as scissors.The name of the third story is Candle This story tells of a landed overlord's overseer who had his landed slaves tormented. Despite the past centuries, it is possible to adapt this story to the present with minor changes. There are still long working hours, fear of mobbing, insufficient wages and unemployment. The power of the story's karma to reflect on the person who does whatever is done is told in an impressive sequence of events. The fourth story, Does Man Need a Lot of Land? A story that is mentioned and referred to a lot in literature is human nature's greed and inexhaustible passion for possession. Everything starts with a claim, Poham, a simple villager, is defying the devil, Our only problem is little land! If I had as much land as I wanted, I would not be afraid of anyone, not even the devil! Fifth story Elijah. It tells the story of a well-established family that made its fortune by working hard with his wife, and made the guests well-hospitalized and drank, and I personally lived most of my life with this perspective.",
                    Post=posts[0]
                },
                new Contents()
                {
                    Text ="WhatsApp, the world's most popular messaging application, which was fined 225 million euros for violating the personal data protection law in Europe in the past weeks, is coming with a long-awaited feature that will make those who love to send voice messages happy. WhatsApp, which is under the umbrella of Facebook, will now allow us to see voice messages in text format whenever we want.With the feature revealed by WABetaInfo, WhatsApp is working on a new voicemail transcription that will be done entirely on the user's device, meaning that WhatsApp and Facebook will not be able to access these messages. WABetaInfo states that the user's voice messages will help Apple improve its speech recognition technology, and that this is a completely optional feature. In other words, not every voice message will be automatically translated into text, if the user wishes, he or she will use this feature.The first time you use the transcription of the voice message, WhatsApp will send you a notification saying WhatsApp Wants to Access Speech Recognition. ",
                    Image="whatsapp.jpg",
                    Post=posts[1]
                },
                new Contents()
                {
                    Text="The content of the notification reads, Speech data from this app will be sent to Apple to process your requests. This will also help Apple improve speech recognition technology. Convert voice messages to text. statement is included.If you approve this notification, your voice messages are automatically ready to be converted to text. After accepting the application to access speech recognition, users will be able to try the transcription service with the Transcript section. The aforementioned feature is still under development, so WhatsApp's public beta testers are currently unable to try this feature. It remains unclear when the feature will be activated or whether it will come to Android.",
                    Post=posts[1]
                },
                new Contents()
                {
                    Text="It states that if you try it on Safari with iPhone12 Pro or Edge with Blue Snowball USB microphone, the feature has no difficulty in getting sound. However, when tested on Android devices via Chrome, the feature is said to have difficulty receiving sound. Despite what has been said, our advice is to try and see the results yourself.When I tried it on a Mac with sound, but not with a guitar, I found that the feature did not have any difficulty in getting sound. However, unlike guitar tuning, I was content with seeing the equivalents of the sounds I gave in guitar chords. Of course, when my voice did not vibrate, I also met with the correct setting warning.Adding features such as Humming to Search to the Search process and Short videos tab to search results in 2020, Google does not stop renewing itself. However, especially voice-oriented features can contribute to Google's improvement of voice command search capabilities.",
                    Post=posts[2]
                },
                new Contents()
                {
                    Text= "Google searches allows you to tune guitar using your phone's microphone, thanks to its newly released feature. The feature, which we can call Google Tuner, was released last week. You can access the feature by typing Google Tuner in the search field. In fact, many digital tuning applications have been published so far. There are different options that musicians can use whenever they want. So it's surprising that Google offers services in this area.Still, the search engine, which supports search results such as weather, currency, time zone and calculator with widgets, offers musicians a new widget. Those who have tried it say that the feature gains functionality with the sound quality of the device you are using. ",
                    Image="applesafari.jpg",
                    Post=posts[2]
                },
                //new Contents()
                //{
                //    Text="Neither Lily nor Charlie have shared too many details about the origins of their relationship, but the two seem to have started dating in 2019. The actor, best known for her leading role in Emily in Paris, announced their engagement on Instagram about a year ago.",
                //    Image="Emily-in-Paris.jpg",
                //    Post=posts[3]
                //},
                //new Contents()
                //{
                //    Text="I’ve never wanted to be someone’s someone more than I do yours, and now I get to be your wife, Lily wrote alongside a photo of the bride and groom smooching. On September 4th, 2021 we officially became each other’s forever. I love you beyond @charliemcdowell…⁣, she added. The British beauty shared two more shots from her wedding day: the first featured a close up of the couple embracing, which she captioned, Never been happier…, and the second post showed the happy couple sharing another romantic kiss next to a waterfall. She captioned that scenic shot, What started as a fairytale, is now my forever reality. I’ll never be able to properly describe how otherworldly this past weekend was, but magical is a pretty good place to start…",
                //    Image="LilyCollinsandCharlieMacDowellweddingFB-4e6edd085fa042d4ab688e289cd6fda2.jpg",
                //    Post=posts[3]
                //},
                //new Contents()
                //{
                //    Text="Charlie shared the same few pics from Saturday’s nuptials but included his own heartfelt messages about marrying Lily. I married the most generous, thoughtful, and beautiful person I’ve ever known. I love you @lilyjcollins, the film director wrote on one post. Alongside the magnificent snap of the couple kissing at the waterfall, Charlie said, This moment will forever play inside my head. Lily and Charlie received a plethora of congratulatory wishes on their wedding from their famous friends. What a beautiful picture ! So happy for y’all! , Reese Witherspoon commented on one of the wedding snaps, while Lily’s Emily in Paris co-star Ashley Park said, MOM AND DAD. Sarah Hyland was super excited about the big news as well, writing, YASSSSSSS!!!!!!!!!!! under one of Lily’s snaps.",
                //    Image="26797316-8186863-Stocking_up_Lily_Collins_and_her_director_boyfriend_Charlie_McDo-a-6_1585976187071.jpg",
                //    Post=posts[3]
                //},
                //new Contents()
                //{
                //    Text="The daughter of Phil Collins announced her engagement to Charlie who is the son of Malcolm McDowell and Mary Steenburgen — on Sept. 24, 2020, a year after the two were first linked romantically. Charlie appeared to propose while the two were on a hike, and Lily shared the big news with an up-close look at her engagement ring, a pic of the couple kissing, and an adorable snap of the moment Charlie got down on one knee. I’ve been waiting my lifetime for you and I can’t wait to spend our lifetime together…, she captioned the pics. Charlie also shared the news on his Instagram page, writing, In a time of uncertainty and darkness you have illuminated my life. I will forever cherish my adventure with you. How pure is this?! Let me know in the comments below if you too are feeling a little emotional after seeing Lily and Charlie's wedding photos.",
                //    Post=posts[3]
                //}
            };
            var comment = new List<Comment>()
            {
                new Comment()
                {
                    Date= DateTime.Now,
                    Message="Hey, I like your every posts. I am very big you. I will read this book as soon as possible.",
                    Post=posts[0],
                    User=users[3]
                },
                new Comment()
                {
                    Date= DateTime.Now.AddDays(-40),
                    Message="I saw this feature and I really like it. Because sometimes, I am too lazy to write message.",
                    Post=posts[1],
                    User=users[3]
                },
                new Comment()
                {
                    Date= DateTime.Now.AddDays(-65),
                    Message="Hey, I read this book and it was not perfect like your mentioned. I didnt understand how did you like this book.",
                    Post=posts[0],
                    User=users[4]
                },
                new Comment()
                {
                    Date= DateTime.Now.AddDays(50),
                    Message="I am learning playing guitar. So, this feature is it will be good for me",
                    Post=posts[2],
                    User=users[0]
                },
                new Comment()
                {
                    Date= DateTime.Now.AddDays(-40),
                    Message="I cant play guitar. I am very bad too playing, but who know the playing guiar, there will be good oppornutiy for them",
                    Post=posts[2],
                    User=users[1]
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
                if (!context.Users.Any())
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    users[0].PasswordHash = password.HashPassword(users[0], "Witcherciri01");
                    users[1].PasswordHash = password.HashPassword(users[1], "ForrestGump56");
                    users[2].PasswordHash = password.HashPassword(users[2], "Sunflower95");
                    users[3].PasswordHash = password.HashPassword(users[3], "İremblt00");
                    users[4].PasswordHash = password.HashPassword(users[4], "fakeAccount03");
                    var userStore = new UserStore<ApplicationUser>(context);
                    await userStore.CreateAsync(users[0]);
                    await userStore.CreateAsync(users[1]);
                    await userStore.CreateAsync(users[2]);
                    await userStore.CreateAsync(users[3]);
                    await userStore.CreateAsync(users[4]);
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
                if (!context.Contents.Any())
                {
                    context.Contents.AddRange(contents);
                }
                if (!context.Comments.Any())
                {
                    context.Comments.AddRange(comment);
                }
                context.SaveChanges();
            }
        }
    }
}