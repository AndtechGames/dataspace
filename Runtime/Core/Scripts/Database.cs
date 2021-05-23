/*
 *	Copyright (c) 2021, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Andtech.Dataspace
{

	public class DatabaseEventArgs<TKey, TValue> : EventArgs
	{
		public readonly TKey Key;
		public readonly TValue Data;

		public DatabaseEventArgs(TKey key, TValue data)
		{
			Key = key;
			Data = data;
		}
	}

	public class Database<TKey, TValue>
		: IDictionary<TKey, TValue>
	{
		private readonly IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

		#region INTERFACE
		public void Add(TKey key, TValue value)
		{
			dictionary.Add(key, value);

			Created?.Invoke(new DatabaseEventArgs<TKey, TValue>(key, value));
		}

		public bool Remove(TKey key)
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				Deleted?.Invoke(new DatabaseEventArgs<TKey, TValue>(key, value));

				return true;
			}

			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return dictionary.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return dictionary.TryGetValue(key, out value);
		}

		public TValue this[TKey key]
		{
			get => dictionary[key];
			set => dictionary[key] = value;
		}

		public ICollection<TKey> Keys => dictionary.Keys;
		public ICollection<TValue> Values => dictionary.Values;

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			dictionary.Add(item);
		}

		public void Clear()
		{
			dictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return dictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			dictionary.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return dictionary.Remove(item);
		}

		public int Count => dictionary.Count;
		public bool IsReadOnly => dictionary.IsReadOnly;

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return dictionary.GetEnumerator();
		}
		#endregion

		#region EVENT
		public event Action<DatabaseEventArgs<TKey, TValue>> Created;
		public event Action<DatabaseEventArgs<TKey, TValue>> Deleted;
		#endregion
	}
}
