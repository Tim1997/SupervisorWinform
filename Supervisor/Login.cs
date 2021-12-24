using Firebase.Auth;
using Newtonsoft.Json;
using Supervisor.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class Login : Form
    {
        protected readonly FirebaseAuthProvider FirebaseAuth;
        private string webAPIkey = "AIzaSyApIY-Eo7vVosS24J_sJMRdx9oo42wt16g";
        private IniHelper IniHelper;
        public Login()
        {
            InitializeComponent();
            FirebaseAuth = new FirebaseAuthProvider(new FirebaseConfig(webAPIkey));
            IniHelper = new IniHelper();
        }

        string GetToken()
        {
            return IniHelper.Read("Token");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = tbEmail.Text;
            var pass = tbPassword.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Email or Password can not be empty", "Error");
                return;
            }

            try
            {
                var auth = await FirebaseAuth.SignInWithEmailAndPasswordAsync(email, pass);
                var content = await auth.GetFreshAuthAsync();
                var token = GetToken();

                // chua co token
                if (string.IsNullOrWhiteSpace(token))
                {
                    IniHelper.Write("Email", content.User.Email);
                    IniHelper.Write("Token", content.User.LocalId);
                    DialogResult = DialogResult.OK;
                }
                else
                // co token
                {
                    if (token == content.User.LocalId)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Invalid useremail or password", "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User does not exist", "Error");
            }
        }
    }
}
