using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class ContextInitializer : DropCreateDatabaseAlways<CollaboratorContext>
    {
        protected override void Seed(CollaboratorContext context)
        {


            SearchCriteria sc1 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Carsten" });
            SearchCriteria sc2 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Swienty" });
            SearchCriteria sc3 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Eltavle" });
            SearchCriteria sc4 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Pro Automatic" });
            SearchCriteria sc5 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "EliteIT" });
            SearchCriteria sc6 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Klaus" });
            SearchCriteria sc7 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = new DateTime(2016, 8, 7).ToString() });
            SearchCriteria sc8 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Ronni" });
            SearchCriteria sc9 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Finans" });
            SearchCriteria sc10 = context.SearchCriterias.Add(new SearchCriteria() { Criteria = "Hamburg" });





            //Email email1 = context.Emails.Add(new Email()
            //{

            //    BodyText = "Første bodytext Første bodytext Første bodytext Første bodytext Første bodytext Første bodytext" +
            //                "Første bodytext Første bodytext Første bodytext Første bodytext ",
            //    Recipiant = "klausgaarde@live.dk",
            //    Sender = "Carsten@eliteit.dk",
            //    Subject = "Collaborator",
            //    ReceivedDate = new DateTime(2014, 8, 7),
            //    SearchCriteria = { sc1, sc4 }
            //});

            //Email email2 = context.Emails.Add(new Email()
            //{

            //    BodyText = "Anden bodytext Anden bodytext Anden bodytext Anden bodytext Anden bodytext Anden bodytext Anden" +
            //                "Anden bodytext Anden bodytext Anden bodytext Anden bodytext Anden bodytext ",
            //    Recipiant = "klausgaarde@live.dk",
            //    Sender = "Carsten@eliteit.dk",
            //    Subject = "Arbejder",
            //    ReceivedDate = new DateTime(2015, 7, 8),
            //    SearchCriteria = { sc1, sc2 }
            //});

            Theme theme1 = context.Themes.Add(new Theme() { Title = "Carsten", SearchCriterias = { sc1 } });
            Theme theme2 = context.Themes.Add(new Theme() { Title = "Klaus", SearchCriterias = { sc6 } });
            Theme theme3 = context.Themes.Add(new Theme() { Title = "EliteIT", SearchCriterias = { sc5, sc1, sc6, sc8 } });
            Theme theme4 = context.Themes.Add(new Theme() { Title = "Ronni", SearchCriterias = { sc8 } });
            Theme theme5 = context.Themes.Add(new Theme() { Title = "Swienty", SearchCriterias = { sc2 } });
            Theme theme6 = context.Themes.Add(new Theme() { Title = "Finans", SearchCriterias = { sc9 } });
            Theme theme7 = context.Themes.Add(new Theme() { Title = "Hamburg", SearchCriterias = { sc10 } });



            //EmailAccount account1 = context.EmailAccounts.Add(new EmailAccount() { EmailAddress = "Klaus@eliteit.dk", Password = "Kg240789." });
            //EmailAccount account2 = context.EmailAccounts.Add(new EmailAccount() { EmailAddress = "ronni@eliteit.dk", Password = "oz1akhEI" });
            CreateRolesandUsers();
            base.Seed(context);
        }
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "ronni@eliteit.dk";
                user.Email = "ronni@eliteit.dk";

                string userPWD = "Bohrs6Vej";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
    }
    }
