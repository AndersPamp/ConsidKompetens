using ConsidKompetens_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsidKompetens_Data.Data
{
  public static class ModelBuilderExtensions
  {
    public static void SeedIdentity(this ModelBuilder modelBuilder)
    {
      var users = new List<IdentityUser>()
      {
        new IdentityUser{
          Id="062f39f9-5f27-476e-8bce-e7e447f8d874",
          UserName="test08@consid.se",
          NormalizedUserName="TEST08@CONSID.SE",
          Email="test08@consid.se",
          NormalizedEmail="TEST08@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEH+H4aWDMMUw2+5X3rd3QXksLo2N0ttyQPGp6amrO9h9zfpPl4JuvMaHrFi/jAcMrA==",
          SecurityStamp="5Z4KSSACVENKW2F4TVO4N7XCCR6F6YMF",
          ConcurrencyStamp="a42d7741-bef1-499c-984f-78dfde8394dc" },
        new IdentityUser{
          Id="1eb5b655-755d-4d21-b78c-8d19eeeb19a9",
          UserName="test05@consid.se",
          NormalizedUserName="TEST05@CONSID.SE",
          Email="test05@consid.se",
          NormalizedEmail="TEST05@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEPsBbb71lZtdTapbTyDxxUVhJYISTvtunWps5B4NTKLigAkXTU06yBpyXU7/ex4t6w==",
          SecurityStamp="FZ7WP5AIFFTV7HSNOGATMWQJODOGJCH5",
          ConcurrencyStamp="14cd057c-353b-407b-8dfa-5804c681d831" },
        new IdentityUser{
           Id="3a779fe9-15b0-4a10-b607-538393af8ed4",
          UserName="test06@consid.se",
          NormalizedUserName="TEST06@CONSID.SE",
          Email="test06@consid.se",
          NormalizedEmail="TEST08@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEJYouQJ/yNR9wQoeOhwF49Hb+yWSLl+1ZcFG+txxHyTG5CFMqUcO+pwe5JqFtQW8PA==",
          SecurityStamp="ZBTDM27HGFBTPCF2OKVTNT3W6TL4L5IO",
          ConcurrencyStamp="5b303bc4-71a3-4890-96b8-1929402dccd3" },
        new IdentityUser{
           Id="45f21477-00ef-436f-928b-504753249afa",
          UserName="test03@consid.se",
          NormalizedUserName="TEST03@CONSID.SE",
          Email="test03@consid.se",
          NormalizedEmail="TEST03@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEBukuiXoLi1UFKOy3ciTihooMYcxGKLjSGHZ5usGXL9GS2kriBVCOK5nCWdwQqs8HQ==",
          SecurityStamp="R5GFLIMSYEXS7GD42SG5WZ2C5WYUTBRY",
          ConcurrencyStamp="45d838ba-f116-488d-9c61-3d33e95d0821" },
        new IdentityUser{
           Id="65c97613-cd49-4aa8-ad5d-f53b05f609f9",
          UserName="test04@consid.se",
          NormalizedUserName="TEST04@CONSID.SE",
          Email="test04@consid.se",
          NormalizedEmail="TEST04@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEHAYJycGYv6YVSCEndvwcJRKpAte1XYj7GWrpz/CHfPMYe4nyGBr23YN4uB4TugWeA==",
          SecurityStamp="YCKY2RBQBWME52MQ47WMYH3J5DMFRLHS",
          ConcurrencyStamp="086aef08-c584-4e6d-a209-05f606a046b1" },
        new IdentityUser{
           Id="6c6c2eec-f58b-4728-8b6a-20492648ad83",
          UserName="test01@consid.se",
          NormalizedUserName="TEST01@CONSID.SE",
          Email="test01@consid.se",
          NormalizedEmail="TEST01@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEKVxOyt55J5c8FXP8u5PEuJ7u8RIoKSf8MzcUSrFKSkwKIUP9XmzLNY69MO/Y9dWHA==",
          SecurityStamp="Z46LD455L6DQH6MX5IF45TW3FRBSXUOP",
          ConcurrencyStamp="f0375821-a978-45fa-bc87-f6abb3f28687" },
        new IdentityUser{
           Id="84efc798-d9dd-48fe-ad64-e186488bfe88",
          UserName="test09@consid.se",
          NormalizedUserName="TEST09@CONSID.SE",
          Email="test09@consid.se",
          NormalizedEmail="TEST09@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEMK2rT1kfBzfMpDWZvbz41enyW5smrBSAZbU0VJNB9xTev3HoRylwiL1gqHe6ta0Zg==",
          SecurityStamp="FBZJKSHNPHDJNOC6YIFTRQYRKTQBWWZM",
          ConcurrencyStamp="108565f4-3fc9-42df-8116-cc25f1c305fe" },
        new IdentityUser{
           Id="b437b09d-615b-49ff-9317-bfab87d38c84",
          UserName="test02@consid.se",
          NormalizedUserName="TEST02@CONSID.SE",
          Email="test02@consid.se",
          NormalizedEmail="TEST02@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEIBrSfEqoUYhAEzvJT+D4h0dYvZUx1DTQiDblQNlOwympB7kJmLUj3QYkRzgYcbW1A==",
          SecurityStamp="XNTXT3KJOSOBTRJC4DSIFA3QDQYVQ3OU",
          ConcurrencyStamp="aeaa1a13-cda0-47f9-82be-779246b0a645" },
        new IdentityUser{
           Id="d3a961f6-603c-4c53-9e0b-3e49a81c7fc3",
          UserName="test07@consid.se",
          NormalizedUserName="TEST07@CONSID.SE",
          Email="test07@consid.se",
          NormalizedEmail="TEST07@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEMHqg4+z3zu2R5Zq2NCWTM0+2uXLJr+SxSuuA2rDyBgV2Hfo63E5HECHq/2cjx0hVg==",
          SecurityStamp="YU7JGCVN44WJDFH4GSHA4EKJI527DISU",
          ConcurrencyStamp="a9f4fc74-272d-4a11-86ef-c5c1a3484257" },
        new IdentityUser{
           Id="e9e8c451-f41c-4cf7-bfd0-07650578856e",
          UserName="test10@consid.se",
          NormalizedUserName="TEST10@CONSID.SE",
          Email="test10@consid.se",
          NormalizedEmail="TEST10@CONSID.SE",
          EmailConfirmed=true,
          PasswordHash="AQAAAAEAACcQAAAAEPf5H1iZD2F1c8FkKTxpBfqL/bPXPuhGa5M2ZuBQ7Spkz6pYPQDvTbSA+msPSong6w==",
          SecurityStamp="4QMMOJCAOGTBZWEDVBI2DTHF5SC66EFG",
          ConcurrencyStamp="cd651042-d2ad-41fb-b16a-728efe62e05b" }
      };
      modelBuilder.Entity<IdentityUser>().HasData(users);
    }

    public static void SeedData (this ModelBuilder modelBuilder)
    {
      var images = new List<ImageModel>()
      {
        new ImageModel{Id=1, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\6c6c2eec-f58b-4728-8b6a-20492648ad83.jpeg", Alt="Profile image"},
        new ImageModel{Id=2, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\b437b09d-615b-49ff-9317-bfab87d38c84.jpeg", Alt="Profile image"},
        new ImageModel{Id=3, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\45f21477-00ef-436f-928b-504753249afa.jpeg", Alt="Profile image"},
        new ImageModel{Id=4, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\65c97613-cd49-4aa8-ad5d-f53b05f609f9.jpeg", Alt="Profile image"},
        new ImageModel{Id=5, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\1eb5b655-755d-4d21-b78c-8d19eeeb19a9.jpeg", Alt="Profile image"},
        new ImageModel{Id=6, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\3a779fe9-15b0-4a10-b607-538393af8ed4.jpeg", Alt="Profile image"},
        new ImageModel{Id=7, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\d3a961f6-603c-4c53-9e0b-3e49a81c7fc3.jpeg", Alt="Profile image"},
        new ImageModel{Id=8, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\062f39f9-5f27-476e-8bce-e7e447f8d874.jpeg", Alt="Profile image"},
        new ImageModel{Id=9, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\84efc798-d9dd-48fe-ad64-e186488bfe88.jpeg", Alt="Profile image"},
        new ImageModel{Id=10, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Url="../ConsidKompetens_Data/ProfileImages\\e9e8c451-f41c-4cf7-bfd0-07650578856e.jpeg", Alt="Profile image"}
      };

      var offices = new List<OfficeModel>()
      {
        new OfficeModel{Id=1, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Jönköping", TelephoneNumber="036-120210"},
        new OfficeModel{Id=2, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Stockholm", TelephoneNumber="036-120210"},
        new OfficeModel{Id=3, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Göteborg", TelephoneNumber="036-120210"},
        new OfficeModel{Id=4, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Göteborg - Paradigm", TelephoneNumber="+46 31 761 56 10"},
        new OfficeModel{Id=5, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Malmö", TelephoneNumber="036-120210"},
        new OfficeModel{Id=6, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Uppsala", TelephoneNumber="036-120210"},
        new OfficeModel{Id=7, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Linköping", TelephoneNumber="036-120210"},
        new OfficeModel{Id=8, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Norrköping", TelephoneNumber="036-120210"},
        new OfficeModel{Id=9, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Örebro", TelephoneNumber="036-120210"},
        new OfficeModel{Id=10, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Helsingborg", TelephoneNumber="036-120210"},
        new OfficeModel{Id=11, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Gävle", TelephoneNumber="036-120210"},
        new OfficeModel{Id=12, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Ljungby", TelephoneNumber="036-120210"},
        new OfficeModel{Id=13, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Sundsvall", TelephoneNumber="036-120210"},
        new OfficeModel{Id=14, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Värnamo", TelephoneNumber="036-120210"},
        new OfficeModel{Id=15, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Karlskrona", TelephoneNumber="036-120210"},
        new OfficeModel{Id=16, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Västerås", TelephoneNumber="036-120210"},
        new OfficeModel{Id=17, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Borås", TelephoneNumber="036-120210"},
        new OfficeModel{Id=18, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Växjö", TelephoneNumber="036-120210"},
        new OfficeModel{Id=19, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Nyköping", TelephoneNumber="036-120210"},
        new OfficeModel{Id=20, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Karlshamn", TelephoneNumber="036-120210"},
        new OfficeModel{Id=21, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), City="Kalmar", TelephoneNumber="036-120210"}
      };

      var competences = new List<CompetenceModel>()
      {
        new CompetenceModel{Id=1, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="React"},
        new CompetenceModel{Id=2, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="React"},
        new CompetenceModel{Id=3, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="React"},
        new CompetenceModel{Id=4, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="DOTNET"},
        new CompetenceModel{Id=5, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="DOTNET"},
        new CompetenceModel{Id=6, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="DOTNET"},

        new CompetenceModel{Id=7, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Azure Dev Ops"},
        new CompetenceModel{Id=8, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Azure Dev Ops"},
        new CompetenceModel{Id=9, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Azure Dev Ops"},
        new CompetenceModel{Id=10, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Episerver"},
        new CompetenceModel{Id=11, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Episerver"},
        new CompetenceModel{Id=12, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Episerver"},

        new CompetenceModel{Id=13, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Data Analytics"},
        new CompetenceModel{Id=14, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Data Analytics"},
        new CompetenceModel{Id=15, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Data Analytics"},
        new CompetenceModel{Id=16, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="HTML"},
        new CompetenceModel{Id=17, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="HTML"},
        new CompetenceModel{Id=18, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="HTML"},

        new CompetenceModel{Id=19, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Java Script"},
        new CompetenceModel{Id=20, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Java Script"},
        new CompetenceModel{Id=21, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Java Script"},
        new CompetenceModel{Id=22, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Sharepoint"},
        new CompetenceModel{Id=23, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Sharepoint"},
        new CompetenceModel{Id=24, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Sharepoint"},

        new CompetenceModel{Id=25, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Umbraco"},
        new CompetenceModel{Id=26, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Umbraco"},
        new CompetenceModel{Id=27, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Umbraco"},
        new CompetenceModel{Id=28, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Umbraco"},
        new CompetenceModel{Id=29, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="C#"},
        new CompetenceModel{Id=30, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="C#"},

        new CompetenceModel{Id=31, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="C#"},
        new CompetenceModel{Id=32, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="C#"},
        new CompetenceModel{Id=33, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Xamarin"},
        new CompetenceModel{Id=34, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Xamarin"},
        new CompetenceModel{Id=35, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Xamarin"},
        new CompetenceModel{Id=36, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Value="Xamarin"}
      };

      var projectProfileRoles = new List<ProjectProfileRole>()
      {
        new ProjectProfileRole{ProjectModelId=1, ProfileModelId=1, RoleModelId=1},
        new ProjectProfileRole{ProjectModelId=2, ProfileModelId=5, RoleModelId=2},
        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=6, RoleModelId=2},
        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=3, RoleModelId=3},

        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=7, RoleModelId=3},
        new ProjectProfileRole{ProjectModelId=2, ProfileModelId=4, RoleModelId=4},
        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=8, RoleModelId=4},
        new ProjectProfileRole{ProjectModelId=3, ProfileModelId=10, RoleModelId=5},

        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=5, RoleModelId=5},
        new ProjectProfileRole{ProjectModelId=1, ProfileModelId=2, RoleModelId=6},
        new ProjectProfileRole{ProjectModelId=3, ProfileModelId=9, RoleModelId=6},
        new ProjectProfileRole{ProjectModelId=4, ProfileModelId=1, RoleModelId=6},
      };

      var timePeriods = new List<TimePeriod>()
      {
        new TimePeriod{Id=1, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Start=new DateTime(2001-06-01), Stop= new DateTime(2002-12-31)},
        new TimePeriod{Id=2, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Start=new DateTime(2002-03-01), Stop= new DateTime(2004-05-15)},
        new TimePeriod{Id=3, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Start=new DateTime(2003-10-01), Stop= new DateTime(2005-05-20)},
        new TimePeriod{Id=4, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03), Start=new DateTime(2004-08-10), Stop= new DateTime(2010-06-30)}
      };

      var projects = new List<ProjectModel>()
      {
        new ProjectModel{Id=1, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03),Name="Öresundskraft", Description="My alter-ego is crossfit giving massages if you like. For real though I live in constant amazement of nature and the universe I don't really read much these days extreme Juggalo, I have an IQ of 140, which means staying up late if you have to look it up don't bother work hard play hard trapped in a sexless marriage. When I get drunk I am extremely experienced and talented you should message me Libertarian my beard my deep, manly voice.", TimePeriodId=1},
        new ProjectModel{Id=2, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03),Name="Peab", Description="Is pretty awesome that means I am wonderful crossfit performance art. I hope there are good girls left extreme blackjack see, I told you in my birthday suit, if you have a BMI under 25 keep up with me I starred in my own reality show bald is sexy it's huge. Working on my screenplay dive bars laughing hysterically MFA I'm a nice guy clubbing.", TimePeriodId=2},
        new ProjectModel{Id=3, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03),Name="Vinslövs Bangolf", Description="Living on sailboats most cats eventually love me is probably a conspiracy my lizard tongue. Most cats eventually love me I know shirtless pics are a no-no, but P90X P90X full-contact, I will love you forever the fact that you are even considering schooling me I am a gentleman first and foremost I'm the last of a dying breed if you have an innie belly button. I may be somewhat jaded someone to provide for you if I make fun of you it's because I like you you're going to be trained to my satisfaction is pretty awesome I don't really read much these days.", TimePeriodId=3},
        new ProjectModel{Id=4, Created = new DateTime(2020-03-03),Modified=new DateTime(2020-03-03),Name="Kenneths Kennel & Kebab", Description="Most cats eventually love me proper grammar most cats eventually love me dive bars. I am a hoarder, but only of top shelf stuff throwing rocks at trains I starred in my own reality show staying up late motorcycle collection, I have an IQ of 140, which means if you dress up like a pin-up doll for me extreme everything destructive that I do full-contact. Really only soft drugs size 2 throwing rocks at trains friendzone one time in middle school I don't really keep a budget.", TimePeriodId=4}
      };

      var profiles = new List<ProfileModel>()
      {
        new ProfileModel{
          Id=1,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="6c6c2eec-f58b-4728-8b6a-20492648ad83",
          //OfficeModelId=1,
          FirstName="John",
          LastName= "Doe",
          AboutMe="I am oddly aroused by no crazy chicks see, I told you you're going to be trained to my satisfaction. " +
          "Unworthy of serious consideration when I picked this username I didn't realize I couldn't change it if you have " +
          "to look it up don't bother on the first date I should have grown up in the 40s, shooting it depends on the night " +
          "you're going to be trained to my satisfaction I'm kind of a genius it's huge. Cosplay I despise my wife if you " +
          "like my profile younger women ultramarathons.",
          Position="Developer",
          Experience=3,
          ImageModelId=1
          },
        new ProfileModel{
          Id=2,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="b437b09d-615b-49ff-9317-bfab87d38c84",
          //OfficeModelId=1,
          FirstName="Idi",
          LastName= "Amin",
          AboutMe="Complete lack of shame is probably a conspiracy documentary filmmaker I attract girls who are very good-looking. " +
          "I may be somewhat jaded unworthy of serious consideration I am extremely experienced and talented beekeeping I love the " +
          "smell of, no crazy chicks I will love you forever I attract girls who are very good-looking females I grow a creepy " +
          "mustache every February. Clubbing bald is sexy you should message me I'm an enormous man-child staying up late I may be somewhat jaded.",
          Position="Developer",
          Experience=7,
          ImageModelId=2
          },
        new ProfileModel{
          Id=3,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="45f21477-00ef-436f-928b-504753249afa",
          //OfficeModelId=1,
          FirstName="Hozni",
          LastName= "Mubarak",
          AboutMe="If you like please post your real pictures I am oddly aroused by it depends on the night. Shooting laughing hysterically " +
          "laughing hysterically I should have grown up in the 40s performance art, if that paragraph above turned you off nubile snapchat " +
          "The Game I am a gentleman first and foremost. I did a lot of modeling work in the mid-80s that just proves my point MFA unworthy " +
          "of serious consideration my beard when I picked this username I didn't realize I couldn't change it.",
          Position="Developer",
          Experience=12,
          ImageModelId=3
          },
        new ProfileModel{
          Id=4,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="65c97613-cd49-4aa8-ad5d-f53b05f609f9",
          //OfficeModelId=2,
          FirstName="Elisabeth",
          LastName= "Höglund",
          AboutMe="Please post your real pictures heyyy my deep, manly voice P90X. If you dress up like a pin-up doll for me The Game shooting " +
          "Juggalo with morals, complete lack of shame if you like my profile Ayn Rand no crazy chicks I will love you forever. I despise I'm " +
          "really good at I'm a nice guy my deep, manly voice I am a hoarder, but only of top shelf stuff I won't bite without permission.",
          Position="Developer",
          Experience=6,
          ImageModelId=4
          },
        new ProfileModel{
          Id=5,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="1eb5b655-755d-4d21-b78c-8d19eeeb19a9",
          //OfficeModelId=2,
          FirstName="Djingis",
          LastName= "Khan",
          AboutMe="If you have an innie belly button you could say I'm old-fashioned MFA on the first date. When I get drunk I don't really keep " +
          "a budget everything destructive that I do I attract girls who are very good-looking if that paragraph above turned you off, " +
          "nubile proper grammar I live in constant amazement of nature and the universe please post your real pictures bald is sexy. " +
          "I love the smell of I'm really good at my other half if you like are you really going to rule me out becausae of it? my last partner told me.",
          Position="Developer",
          Experience=5,
          ImageModelId=5
          },
        new ProfileModel{
          Id=6,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="3a779fe9-15b0-4a10-b607-538393af8ed4",
          //OfficeModelId=2,
          FirstName="Emperor",
          LastName= "Hirohito",
          AboutMe="My lizard tongue blackjack with morals well-built. Heyyy Think about it! making others feel good females my last partner told me, " +
          "I'm an enormous man-child other shenanigans keep up with me skydiving well-built. On my fetish list I'm an enormous man-child shooting " +
          "that just proves my point shooting size 2.",
          Position="Developer",
          Experience=8,
          ImageModelId=6
          },
        new ProfileModel{
          Id=7,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="d3a961f6-603c-4c53-9e0b-3e49a81c7fc3",
          //OfficeModelId=3,
          FirstName="Reinhard",
          LastName= "Heydrich",
          AboutMe="A fairly successful career in sports performance art years ago I discovered unworthy of serious consideration. The Game that's what she " +
          "said proper grammar with lots of self-respect wildly attractive doesn't hurt, when I picked this username I didn't realize I couldn't change it " +
          "I despise I grow a creepy mustache every February staying up late complete lack of shame. Someone to provide for you is pretty awesome working " +
          "on my screenplay I don't really read much these days everything destructive that I do or so I've been told.",
          Position="Developer",
          Experience=2,
          ImageModelId=7
          },
        new ProfileModel{
          Id=8,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="062f39f9-5f27-476e-8bce-e7e447f8d874",
          //OfficeModelId=3,
          FirstName="Hatte",
          LastName= "Furuhagen",
          AboutMe="If I make fun of you it's because I like you it's huge pics on request I'm really good at. I am a hoarder, but only of top shelf stuff you " +
          "could say I'm old-fashioned I will love you forever if you like documentary filmmaker, heyyy I will love you forever Libertarian Ayn Rand unworthy " +
          "of serious consideration. Making others feel good I don't really read much these days you need a real man I grow a creepy mustache every February " +
          "playing devil's advocate crying in my bathtub.",
          Position="Developer",
          ImageModelId=8
          },
        new ProfileModel{
          Id=9,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="84efc798-d9dd-48fe-ad64-e186488bfe88",
          //OfficeModelId=3,
          FirstName="Biskop",
          LastName= "Brask",
          AboutMe="Be my partner in crime is probably a conspiracy very successsful entrepreneur I will love you forever. In my birthday suit organized chaos " +
          "I grow a creepy mustache every February organized chaos I am a hoarder, but only of top shelf stuff, proper grammar Juggalo ages 18 - 22 well-built " +
          "for real though. Living on sailboats or so I've been told if you have to look it up don't bother you should message me I starred in my own reality show The Game.",
          Position="Developer",
          Experience=22,
          ImageModelId=9
          },
        new ProfileModel{
          Id=10,
          Created = new DateTime(2020-03-03),
          Modified = new DateTime(2020-03-03),
          OwnerID="e9e8c451-f41c-4cf7-bfd0-07650578856e",
          //OfficeModelId=3,
          FirstName="Griselda",
          LastName= "Blanco",
          AboutMe="If you have an innie belly button my other half work hard play hard because I am a paradox. I have an IQ of 140, which means complete lack of shame I am a hoarder, but only of top shelf stuff if you dress up like a pin-up doll for me playing devil's advocate, it's huge looking for a third Libertarian extreme living on sailboats. MFA years ago I discovered Juggalo are you really going to rule me out becausae of it? I did a lot of modeling work in the mid-80s but I only smoke when drinking.",
          Position="Developer",
          Experience=14,
          ImageModelId=10
          },

      };

      modelBuilder.Entity<TimePeriod>().HasData(timePeriods);
      modelBuilder.Entity<ImageModel>().HasData(images);
      modelBuilder.Entity<CompetenceModel>().HasData(competences);
      modelBuilder.Entity<OfficeModel>().HasData(offices);
      modelBuilder.Entity<ProfileModel>().HasData(profiles);
      //modelBuilder.Entity<ProjectProfileRole>().HasData(projectProfileRoles);
      modelBuilder.Entity<ProjectModel>().HasData(projects);
    }
  }
}