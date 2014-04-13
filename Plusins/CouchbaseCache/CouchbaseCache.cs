﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Enyim.Caching.Memcached;
using Couchbase.Extensions;

namespace FC.Framework.CouchbaseCache
{
    public class CouchbaseCache : ICache
    {
        private readonly CouchbaseClient _client;

        public CouchbaseCache()
        {
            this._client = new CouchbaseClient();
        }

        public object Get(string key)
        {
            return this._client.Get(key);
        }

        public bool TryGet(string key, out object value)
        {
            return this._client.TryGet(key, out value);
        }

        public T Get<T>(string key) where T : class
        {
            var returnVal = default(T);

            if (IsPrimitive(typeof(T)))
                returnVal = this._client.Get<T>(key);
            else
                returnVal = this._client.GetJson<T>(key);

            return returnVal;
        }

        public bool TryGet<T>(string key, out T value) where T : class
        {
            object returnVal;
            bool result = false;

            if (IsPrimitive(typeof(T)))
                returnVal = this._client.Get<T>(key);
            else
                returnVal = this._client.GetJson<T>(key);

            if (returnVal != null)
            {
                value = (T)returnVal;
                result = true;
            }
            else value = default(T);

            return result;
        }

        public void Add<T>(string key, T value)
        {
            if (IsPrimitive(typeof(T)))
                this._client.Store(StoreMode.Set, key, value);
            else
                this._client.StoreJson(StoreMode.Set, key, value);
        }

        public void Add<T>(string key, T value, DateTime absoluteExpiration)
        {
            if (IsPrimitive(typeof(T)))
                this._client.Store(StoreMode.Set, key, value, absoluteExpiration);
            else
                this._client.StoreJson(StoreMode.Set, key, value, absoluteExpiration);
        }

        public void Add<T>(string key, T value, TimeSpan slidingExpiration)
        {
            if (IsPrimitive(typeof(T)))
                this._client.Store(StoreMode.Set, key, value, slidingExpiration);
            else
                this._client.Store(StoreMode.Set, key, value, slidingExpiration);
        }

        public void Remove(string key)
        {
            this._client.Remove(key);
        }

        /// <summary>
        /// the type is or not build-type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsPrimitive(Type type)
        {
            if (type.IsPrimitive || type == typeof(string) || type == typeof(decimal))
                return true;
            else return false;
        }
    }
}
