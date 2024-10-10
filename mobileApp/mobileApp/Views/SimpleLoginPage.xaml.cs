using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobileApp.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            this.InitializeComponent();
        }

        private void SignUpBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SimpleSignUpPage());
        }

        private void LogInBtn_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("login","button clicked", "ok");
            bool usernameExists = false;
            DataTable adminTable = SQLProcedures.SelectAdmin();
            DataTable userTable = SQLProcedures.SelectUser();
            DataTable organizationTable = SQLProcedures.SelectOrganization();
            foreach (DataRow user in userTable.Rows)
            {
                if (user["Email"].ToString() == Email.Value)
                {
                    if (user["Password"].ToString() == PasswordEntry.Text)
                    {
                        Navigation.PushAsync(new ArticleCardPage());
                    }
                    usernameExists = true;
                    break;
                }
            }
            if (usernameExists == false)
            {
                foreach (DataRow user in organizationTable.Rows)
                {
                    if (user["Username"].ToString() == Email.Value)
                    {
                        if (user["Passwords"].ToString() == PasswordEntry.Text)
                        {
                            Navigation.PushAsync(new ArticleCardPage());
                        }
                        usernameExists = true;
                        break;
                    }
                }
            }
            if (usernameExists == false)
            {
                foreach (DataRow user in adminTable.Rows)
                {
                    if (user["Username"].ToString() == Email.Value)
                    {
                        if (user["Passwords"].ToString() == PasswordEntry.Text)
                        {
                            Navigation.PushAsync(new ArticleCardPage());
                        }
                        usernameExists = true;
                        break;
                    }
                }
            }
            Console.ReadLine();
            // Do Something
            // check what kind of account it is
            //go to the account page
        }
    }
}