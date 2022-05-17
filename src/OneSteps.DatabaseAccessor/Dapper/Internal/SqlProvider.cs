﻿using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace OneSteps.DatabaseAccessor.Dapper.Internal
{
    /// <summary>
    /// Sql 类型
    /// </summary>
    public static class SqlProvider
    {
        /// <summary>
        /// SqlServer 提供器程序集
        /// </summary>
        public const string SqlServer = "System.Data.SqlClient";

        /// <summary>
        /// Sqlite 提供器程序集
        /// </summary>
        public const string Sqlite = "System.Data.SQLite";

        /// <summary>
        /// MySql 提供器程序集
        /// </summary>
        public const string MySql = "MySql.Data";

        /// <summary>
        /// PostgreSQL 提供器程序集
        /// </summary>
        public const string Npgsql = "Npgsql";

        /// <summary>
        /// Oracle 提供器程序集
        /// </summary>
        public const string Oracle = "Oracle.ManagedDataAccess";

        /// <summary>
        /// Firebird 提供器程序集
        /// </summary>
        public const string Firebird = "FirebirdSql.Data.FirebirdClient";

        /// <summary>
        /// 数据库提供器连接对象类型集合
        /// </summary>
        internal static readonly ConcurrentDictionary<string, Type> SqlProviderDbConnectionTypeCollection;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SqlProvider()
        {
            SqlProviderDbConnectionTypeCollection = new ConcurrentDictionary<string, Type>();
        }

        /// <summary>
        /// 获取数据库连接对象类型
        /// </summary>
        /// <param name="sqlProvider"></param>
        /// <returns></returns>
        internal static Type GetDbConnectionType(string sqlProvider)
        {
            // 加载对应的数据库提供器程序集
            var databaseProviderAssembly = Assembly.Load(sqlProvider);

            // 获取对应数据库连接对象
            var databaseDbConnectionTypeName = string.Empty;

            switch (sqlProvider)
            {
                case SqlServer:
                    databaseDbConnectionTypeName = "System.Data.SqlClient.SqlConnection";
                    break;
                case Sqlite:
                    databaseDbConnectionTypeName = "System.Data.SQLite.SQLiteConnection";
                    break;
                case MySql:
                    databaseDbConnectionTypeName = "MySql.Data.MySqlClient.MySqlConnection";
                    break;
                case Oracle:
                    databaseDbConnectionTypeName = "Oracle.ManagedDataAccess.Client.OracleConnection";
                    break;
                default:
                    break;
            }

            // 加载数据库连接对象类型
            var dbConnectionType = databaseProviderAssembly.GetType(databaseDbConnectionTypeName);

            return SqlProviderDbConnectionTypeCollection.GetOrAdd(sqlProvider, dbConnectionType);

        }
    }
}
