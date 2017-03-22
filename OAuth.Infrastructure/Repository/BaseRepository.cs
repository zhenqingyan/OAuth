using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth.Domain;
using Dapper;
using AutoMapper;

namespace OAuth.Infrastructure
{
    public class BaseRepository<TAggregate, TModel> : IBaseRepository<TAggregate>
        where TAggregate : IAggregateRoot
        where TModel : class
    {

        #region 私有变量
        private string _tableName
        {
            get
            {
                return getTableName();
            }
        }
        private string _keyName
        {
            get
            {
                return getKey();
            }
        }
        #endregion

        public string TableName
        {
            get { return _tableName; }
        }
      
        public string KeyName
        {
            get { return _keyName; }
        }

        public bool Delete(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                string sql = string.Format("delete from {0} where {1} = @{1}", _tableName, _keyName);
                var result = conn.Execute(sql, model);
                return result >= 1 ? true : false;
            }
        }

        public bool DeleteByGuid(object key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAggregate> FindAll(string wheresql = "", object obj = null)
        {
            using (var conn = DbClient.GetConnection())
            {
                string sql = string.Format("select * from {0}", _tableName);
                var result=conn.Query<TAggregate>(sql);
                return result;
            }
        }

        public TAggregate FindOne(object key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                var result = conn.Insert(model);

                return result > 0 ? true : false;
            }
        }

        public bool Update(TAggregate entity)
        {
            using (var conn = DbClient.GetConnection())
            {
                var model = Mapper.Map<TModel>(entity);
                var result = conn.Update(model);
                return result > 0 ? true : false;
            }
        }


        #region 私有变量
        private string getTableName()
        {
            var customAttrs = typeof(TModel).GetCustomAttributes(true);
            foreach (var obj in customAttrs)
            {
                TableAttribute table = obj as TableAttribute;
                if (table != null)
                {
                    return table.Name;
                }
            }
            return typeof(TModel).Name;
        }
        private string getKey()
        {
            var props = typeof(TModel).GetProperties();
            if (!props.Any(o => o.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute))))
                throw new ArgumentException("实体至少有一个[Key]");
            var keyprop = props.Where(o => o.GetCustomAttributes(true).Any(attr => attr.GetType() == typeof(KeyAttribute))).First();
            return keyprop.Name;
        }
        #endregion
    }
}
