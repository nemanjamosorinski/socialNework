﻿using System.Data.Entity;
using SimpleSocialNetworkMyApp.Views;

namespace SimpleSocialNetworkMyApp.Models
{
    public class UsersDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SimpleSocialNetworkMyApp.Models.UsersDBContext>());

        public UsersDBContext() : base("name=UsersDBContext")
        {
        }

        public DbSet<UserRegistration> UserRegistrations { get; set; }
    }
}
