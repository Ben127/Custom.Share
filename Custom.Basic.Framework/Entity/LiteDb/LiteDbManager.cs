using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Entity.LiteDb
{
    /// <summary>
    /// LiteDbManager
    /// </summary>
    public class LiteDbManager
    {
        private string _connectionString = "";
        private string _tableName = "";

        public LiteDbManager(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }


        private LiteCollection<T> GetLiteCollection<T>()
        {
            using (var db = new LiteDB.LiteDatabase(_connectionString))
            {
                var q = db.GetCollection<T>(_tableName);

                return q;
            }
        }

        private LiteStorage GetLiteFileStorage()
        {
            using (var db = new LiteDB.LiteDatabase(_connectionString))
            {
                var q = db.FileStorage;
                return q;
            }
        }


        // find
        public List<T> FindAll<T>()
        {
            var q = GetLiteCollection<T>();
            return q.FindAll().ToList();
        }

        public List<T> Find<T>(Query query, int skip, int take, out int total)
        {
            var q = GetLiteCollection<T>();
            total = Count<T>(query);

            if (take == 0)
            {
                return q.Find(query, skip).ToList();
            }

            return q.Find(query, skip, take).ToList();
        }

        public T FindById<T>(BsonValue id)
        {
            var q = GetLiteCollection<T>();
            return q.FindById(id);
        }

        public T FindOne<T>(Query query)
        {
            var q = GetLiteCollection<T>();
            return q.FindOne(query);
        }

        //update
        public bool Update<T>(T data)
        {
            var q = GetLiteCollection<T>();
            return q.Update(data);
        }

        public int Update<T>(IEnumerable<T> data)
        {
            var q = GetLiteCollection<T>();
            return q.Update(data);
        }

        public bool Update<T>(BsonValue id, T data)
        {
            var q = GetLiteCollection<T>();
            return q.Update(id, data);
        }

        //insert
        public BsonValue Insert<T>(T data)
        {
            var q = GetLiteCollection<T>();
            return q.Insert(data);
        }

        public int Insert<T>(IEnumerable<T> data)
        {
            var q = GetLiteCollection<T>();
            return q.Insert(data);
        }

        public void Insert<T>(BsonValue id, T data)
        {
            var q = GetLiteCollection<T>();
            q.Insert(id, data);
        }

        // exists
        public bool Exists<T>(Query query)
        {
            var q = GetLiteCollection<T>();
            return q.Exists(query);
        }

        // delete
        public bool Delete<T>(BsonValue id)
        {
            var q = GetLiteCollection<T>();
            return q.Delete(id);
        }

        public int Delete<T>(Query query)
        {
            var q = GetLiteCollection<T>();
            return q.Delete(query);
        }

        // max
        public BsonValue Max<T>()
        {
            var q = GetLiteCollection<T>();
            return q.Max();
        }

        // count
        public int Count<T>(Query query)
        {
            var q = GetLiteCollection<T>();
            if (query == null)
            {
                return q.Count();
            }
            return q.Count(query);
        }



        /*
         *  文件
         * 
         */
        public LiteFileInfo FileUpload(string id, string filename, Stream stream)
        {
            var q = GetLiteFileStorage();
            if (stream == null)
                return q.Upload(id, filename);
            return q.Upload(id, filename, stream);

        }

        public LiteFileInfo FileDownload(string id, Stream stream)
        {
            var q = GetLiteFileStorage();
            return q.Download(id, stream);
        }

        public LiteFileInfo FileGet(string id)
        {
            var q = GetLiteFileStorage();
            return q.FindById(id);
        }

        public List<LiteFileInfo> FileGets()
        {
            var q = GetLiteFileStorage();
            return q.FindAll().ToList();
        }

        public bool FileExists(string id)
        {
            var q = GetLiteFileStorage();
            return q.Exists(id);
        }

        public bool FileDelete(string id)
        {
            var q = GetLiteFileStorage();
            return q.Delete(id);
        }

        public LiteFileStream OpenRead(string id)
        {
            var q = GetLiteFileStorage();
            return q.OpenRead(id);
        }


    }
}
