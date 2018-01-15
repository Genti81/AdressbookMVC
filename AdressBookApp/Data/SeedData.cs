using AdressBookApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace AdressBookApp.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                var admin = new IdentityRole { Name = "Admin" };
                var result = roleManager.CreateAsync(admin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser { UserName = "genti@gmail.com", Email = "genti@gmail.com" }; 
                var result = userManager.CreateAsync(user, "Genti81@").Result;
                var roleResult = userManager.AddToRoleAsync(user, "Admin").Result;
            }

            // var gentrit = new Person
            // {
            //     FirstName = "Gentrit",
            //     LastName = "Sahiti",
            //     Email = "sahiti.gentrit@gmail.com",
            //     StreetAddress = "Sångv. 62 lgh 1802",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(gentrit);

            // var adelina = new Person
            // {
            //     FirstName = "Adelina",
            //     LastName = "Sahiti",
            //     Email = "sahiti.adelina@gmail.com",
            //     StreetAddress = "Sångv. 62 lgh 1802",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(adelina);
            // var noel = new Person
            // {
            //     FirstName = "Noel",
            //     LastName = "Sahiti",
            //     Email = "sahiti.noel@gmail.com",
            //     StreetAddress = "Sångv. 62 lgh 1802",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(noel);
            // var ylli = new Person
            // {
            //     FirstName = "Ylli",
            //     LastName = "Sahiti",
            //     Email = "yllisahiti@gmail.com",
            //     StreetAddress = "Jönköpingsv. 5A",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(ylli);
            // var aril = new Person
            // {
            //     FirstName = "Arguriana",
            //     LastName = "Sahiti",
            //     Email = "sahiti.aril@gmail.com",
            //     StreetAddress = "Arrendervägen 7A",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(aril);
            // var nora = new Person
            // {
            //     FirstName = "Leonora",
            //     LastName = "Sahiti",
            //     Email = "sahiti.nora@gmail.com",
            //     StreetAddress = "Dragspelsv. 17A",
            //     Country = "Sweden"
            // };
            // context.People.AddRange(nora);

            // context.Addresses.AddRange(
            //   new Address
            //   {
            //       Description = "Phone: 0723707515 \n\r Område: Jakobsberg",
            //       Person = gentrit,
            //   },
            //   new Address
            //   {
            //       Description = "Phone: 0700996423 \n\r Område: Vilkjö Centrum",
            //       Person = adelina,
            //   },
            //   new Address
            //   {
            //       Description = "Phone: 0745456981 \n\r Område: Vikjö Gård",
            //       Person = noel,
            //   },
            //   new Address
            //   {
            //       Description = "Phone: 0734671856 \n\r Område: Säby Gård",
            //       Person = ylli,
            //   },
            //   new Address
            //   {
            //       Description = "Phone: 0728349081 \n\r Område: Barkarby Centrum",
            //       Person = aril,
            //   },
            //   new Address
            //   {
            //       Description = "Phone: 0734765346 \n\r Område: Vikjö Villaområdet",
            //       Person = nora,
            //   }
            //);
            // context.SaveChanges();
        }
    }
}
