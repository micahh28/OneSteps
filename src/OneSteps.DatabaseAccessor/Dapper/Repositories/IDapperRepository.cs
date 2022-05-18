﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSteps.DatabaseAccessor.Dapper.Repositories
{
    /// <summary>
    /// 非泛型 Dapper 仓储
    /// </summary>
    public partial interface IDapperRepository
    {
        /// <summary>
        /// 连接上下文
        /// </summary>
        IDbConnection Context { get; }

        /// <summary>
        /// 动态连接上下文
        /// </summary>
        dynamic DynamicContext { get; }

        /// <summary>
        /// 查询返回特定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 查询返回特定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }

    /// <summary>
    /// Dapper 仓储接口定义
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial interface IDapperRepository<TEntity> : IDapperRepository
        where TEntity : class, new()
    {
        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        TEntity Get(object id, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object id, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        long Insert(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="sqlAdapter"></param>
        /// <returns></returns>
        Task<int> InsertAsync(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null);

        /// <summary>
        /// 新增多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        long Insert(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 新增多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="sqlAdapter"></param>
        /// <returns></returns>
        Task<int> InsertAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null, ISqlAdapter sqlAdapter = null);

        /// <summary>
        /// 更新一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Update(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 更新一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 更新多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Update(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 更新多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 删除一条
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        bool Delete(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(IEnumerable<TEntity> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Query(string sql, object param = null);

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行。 忽略其他行。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        TEntity QueryFirstOrDefault(string sql, object param = null);

        /// <summary>
        /// 简单分页，返回分页后的泛型集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Tuple<IEnumerable<TEntity>, int> QueryPagination(string sql, object param = null);
    }
}
