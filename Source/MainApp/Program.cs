using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Enyim.Caching.Memcached;
using Enyim.Caching.Memcached.Results;

namespace MainApp
{
    class Program
    {
        public static void Main() {
            var clientA = new CouchbaseClient("couchbase");
            var clientB = new CouchbaseClient();

            clientA.Remove("fooA");

            IStoreOperationResult result = clientA.ExecuteStore(StoreMode.Set, "fooA", "barA");
            var itemA = clientA.Get<string>("fooA");
            Console.WriteLine(itemA);

            clientB.ExecuteStore(StoreMode.Set, "fooB", "barB");
            var itemB = clientB.Get<string>("fooB");
            Console.WriteLine(itemB);

            Console.ReadLine();
        }
    }
}
