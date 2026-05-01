using System.Collections;

namespace DefaultSolutions
{
    public static class EasyCollection
    {
        public static TValue? TryGet<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey? key)
        {
            if (key is null or "")
            {
                return default;
            }

            dictionary.TryGetValue(
                key,
                out TValue? serverInfo);
            return serverInfo;
        }

        public static TValue? TryGet<TKey, TValue>(
            this Hashtable hashtable,
            TKey? key)
        {
            if (key is null or "")
            {
                return default;
            }

            if (!hashtable.ContainsKey(key))
            {
                return default;
            }

            object? objectValue = hashtable[key];
            return (TValue?)objectValue;
        }
    }
}