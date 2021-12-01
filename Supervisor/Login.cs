using Firebase.Auth;
using Newtonsoft.Json;
using Supervisor.Helpers;
using Supervisor.Models;
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
        protected readonly FirebaseAuthProvider FirebaseAuth = new FirebaseAuthProvider(new FirebaseConfig(webAPIkey));
        private static readonly string webAPIkey = "AIzaSyApIY-Eo7vVosS24J_sJMRdx9oo42wt16g";
        private IniHelper IniHelper;
        public Login()
        {
            InitializeComponent();
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
                IniHelper.Write("Email", content.User.Email);

                // chua co token
                if (string.IsNullOrWhiteSpace(token))
                {
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
            catch (FirebaseAuthException ex)
            {
                if (ex.ResponseData == "N/A")
                    MessageBox.Show("Internet connection error", "Error");
                else
                {
                    var response = JsonConvert.DeserializeObject<ResponseFirebase>(ex.ResponseData);
                    MessageBox.Show(response.error.message, "Error");
                }
            }
        }
    }
}
