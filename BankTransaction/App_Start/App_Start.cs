//// -----------------------------------------------------------------------
//// <copyright file="App_Start.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentTools;
using BankTransaction.DataBase;
using System.Data.SqlClient;
using System.Web.Mvc;
using System;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BankTransaction.App_Start), "PreStart")]

namespace BankTransaction {
    public static class App_Start {
        public static void PreStart() {
           
            FluentStartup.Initialize(typeof(DbContextLocal));
        }
    }
}