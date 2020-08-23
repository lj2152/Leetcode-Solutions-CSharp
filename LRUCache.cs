//https://leetcode.com/problems/lru-cache/

 public class CacheRecord
    {
        public int CacheKey { get; set; }
        public int CacheValue { get; set; }
    }

    public class LRUCache {
    private readonly int capacity;
    private readonly LinkedList<CacheRecord> records;
    private readonly Dictionary<int, LinkedListNode<CacheRecord>> cache;
    

    public LRUCache(int capacity) {
        this.capacity = capacity;
        records = new LinkedList<CacheRecord>();
        cache = new Dictionary<int, LinkedListNode<CacheRecord>>();
    }

    public int Get(int key) {
        if (!cache.ContainsKey(key))
        {
            return -1;
        }
        else
        {
            var nodeToGet = cache[key];
            records.Remove(nodeToGet);
            records.AddFirst(nodeToGet);
            return nodeToGet.Value.CacheValue;
        }       
    }

    public void Put(int key, int value) {
        if (cache.ContainsKey(key))
        {
            records.Remove(cache[key]);
        }

        records.AddFirst(new CacheRecord()
        {
             CacheKey = key,
             CacheValue = value
        });
        
        cache[key] = records.First;

        if (records.Count > capacity)
        {
              cache.Remove(records.Last.Value.CacheKey);
              records.RemoveLast();
        }     
    }
}