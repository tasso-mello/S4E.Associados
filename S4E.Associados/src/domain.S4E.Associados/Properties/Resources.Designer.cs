﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace domain.S4E.Associados.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("domain.S4E.Associados.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE master;
        ///
        ///IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = &apos;S4E-Associados&apos;)
        ///BEGIN
        ///    CREATE DATABASE [S4E-Associados]
        ///END
        ///
        ///
        ///IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = &apos;s4e&apos;)
        ///BEGIN
        ///    CREATE LOGIN [s4e] WITH PASSWORD=N&apos;jZBMGg+XwNSlPkPeqH7XMR/RzpCYeilPG4DnbojPmtI=&apos;, DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Português (Brasil)], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
        ///    ALTER LOGIN [s4e] DISABLE
        ///    ALTER SERVER ROLE [sysadmin] ADD MEMBER [s4e]
        ///END.
        /// </summary>
        internal static string CreateDatabase {
            get {
                return ResourceManager.GetString("CreateDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS (SELECT name FROM sys.databases WHERE name = &apos;S4E-Associados&apos;)
        ///BEGIN    
        ///    USE [S4E-Associados]
        ///
        ///    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = &apos;Associados&apos;)
        ///    BEGIN
        ///        CREATE TABLE Associados
        ///        (
        ///            Id BIGINT IDENTITY(1,1) PRIMARY KEY,
        ///            Nome NVARCHAR(MAX),
        ///            CPF NVARCHAR(11) UNIQUE,
        ///            Nascimento DATETIME
        ///        )
        ///    END
        ///
        ///    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateTables {
            get {
                return ResourceManager.GetString("CreateTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS (SELECT name FROM sys.databases WHERE name = &apos;S4E-Associados&apos;)
        ///BEGIN    
        ///	USE [S4E-Associados]
        ///	SET IDENTITY_INSERT [dbo].[Associados] ON 
        ///	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [Nascimento]) VALUES (15, N&apos;Associado 1&apos;, N&apos;12345678901&apos;, CAST(N&apos;1990-01-08T00:00:00.000&apos; AS DateTime))
        ///	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [Nascimento]) VALUES (16, N&apos;Associado 2&apos;, N&apos;98765432101&apos;, CAST(N&apos;1985-05-15T00:00:00.000&apos; AS DateTime))
        ///	INSERT [dbo].[Associados] ([Id], [Nome], [CPF], [N [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InitialSeed {
            get {
                return ResourceManager.GetString("InitialSeed", resourceCulture);
            }
        }
    }
}
