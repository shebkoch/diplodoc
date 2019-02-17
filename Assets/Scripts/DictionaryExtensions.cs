using System.Collections.Generic;

namespace DefaultNamespace
{
	public static class DictionaryExtensions
	{
		public static void AddOrUpdate<K, V>(this Dictionary<K, V> dictionary, K key, V value)
		{
			if (dictionary.ContainsKey(key))
				dictionary[key] = value;
			else
				dictionary.Add(key, value);
		}
	}
}