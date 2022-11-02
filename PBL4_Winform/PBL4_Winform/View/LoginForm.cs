﻿using System;
using PBL4_Winform.ConfigManagers;
using System.Windows.Forms;
using IdentityModel.Client;
using System.Net.Http;
using PBL4_Winform.BaseFunction;

namespace PBL4_Winform
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text == null ? string.Empty : txtUsername.Text.ToString();
            string password = txtPassword.Text == null ? string.Empty : txtPassword.Text.ToString();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập lại username");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập lại password");
                return;
            }

            SetToken(username, password);

            if (!string.IsNullOrWhiteSpace(ConfigManager.Token))
            {
                // get thông tin user fail
                if (!FunctionModule.SetCurrentUserLogin(username))
                {
                    MessageBox.Show("Bạn không đủ quyền");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác, vui lòng kiểm tra lại !");
                return;
            }

            this.Close();

        }

        public void SetToken(string username, string password)
        {
            var client = new HttpClient();
            var address = ConfigManager.Configuration.GetSection("IdentityClients:Default:Authority").Value + "/connect/token";
            var clientId = ConfigManager.Configuration.GetSection("IdentityClients:Default:ClientId").Value;
            var clientSecret = ConfigManager.Configuration.GetSection("IdentityClients:Default:ClientSecret").Value;
            var scope = ConfigManager.Configuration.GetSection("IdentityClients:Default:Scope").Value;
            var tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = address,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = scope,
                UserName = username,
                Password = password,
                GrantType="password"
            }).GetAwaiter().GetResult();
            if (tokenResponse.IsError)
            {
                ConfigManager.Token = string.Empty;
                return;
            }
            ConfigManager.Token = tokenResponse.AccessToken;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}