﻿using System.Collections.Generic;
using System.Web.Http;
using System.Threading;
using System;

namespace Lab01
{
    public class ValuesController : ApiController
    {
        private readonly IStorage _storage;
        
        public ValuesController()
        {
            _storage = new RedisStorage();
        }

        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(string id)
        {
            var result = _storage.Get(id);
            Console.WriteLine("Getting data: " + result);

            return result;
        }

        // POST api/values 
        public string Post([FromBody]Data data)
        {
            Thread.Sleep(500);
            Console.WriteLine("Writing Data: " + data?.value);

            _storage.Save(data?.id, data?.value);
            return data?.id;
        }
    }
}