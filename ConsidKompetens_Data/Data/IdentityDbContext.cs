using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsidKompetens_Data.Data
{
  public class IdentityDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
  {
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
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

      modelBuilder.Entity<IdentityUser>().HasData(new List<IdentityUser>(users));
    }
  }
}
