﻿using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.RavenDB.Entities
{
    public class RavenUserLogin
    {
        public RavenUserLogin() { }
        public RavenUserLogin(string userId, UserLoginInfo loginInfo)
        {
            if (userId == null) throw new ArgumentNullException("userId");
            if (loginInfo == null) throw new ArgumentNullException("loginInfo");

            Id = GenerateKey(loginInfo.LoginProvider, loginInfo.ProviderKey);
            UserId = userId;
            LoginProvider = loginInfo.LoginProvider;
            ProviderKey = loginInfo.ProviderKey;
        }

        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string LoginProvider { get; private set; }
        public string ProviderKey { get; private set; }

        internal static string GenerateKey(string loginProvider, string providerKey)
        {
            return string.Format(Constants.RavenUserLoginKeyTemplate, loginProvider, providerKey);
        }
    }
}