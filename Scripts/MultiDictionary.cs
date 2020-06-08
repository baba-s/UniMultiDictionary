using System.Collections;
using System.Collections.Generic;

namespace Kogane
{
	/// <summary>
	/// 1 つのキーに対して複数の値を登録できる Dictionary
	/// </summary>
	public class MultiDictionary<TKey, TValue> : IDictionary<TKey, List<TValue>>
	{
		//================================================================================
		// 変数（readonly）
		//================================================================================
		private readonly Dictionary<TKey, List<TValue>> m_dictionary;

		//================================================================================
		// プロパティ
		//================================================================================
		/// <summary>
		/// 指定されたキーに紐付く値を取得または設定します
		/// </summary>
		public List<TValue> this[ TKey key ] { get => m_dictionary[ key ]; set => m_dictionary[ key ] = value; }

		/// <summary>
		/// キーの一覧を返します
		/// </summary>
		public ICollection<TKey> Keys => m_dictionary.Keys;

		/// <summary>
		/// 値の一覧を返します
		/// </summary>
		public ICollection<List<TValue>> Values => m_dictionary.Values;

		/// <summary>
		/// 要素の数を返します
		/// </summary>
		public int Count => m_dictionary.Count;

		/// <summary>
		/// 読み取り専用の場合 true 返します
		/// </summary>
		public bool IsReadOnly => false;


		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MultiDictionary( IEqualityComparer<TKey> comparer )
		{
			m_dictionary = new Dictionary<TKey, List<TValue>>( comparer );
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MultiDictionary()
		{
			m_dictionary = new Dictionary<TKey, List<TValue>>();
		}

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( TKey key, TValue value )
		{
			if ( !m_dictionary.ContainsKey( key ) )
			{
				m_dictionary.Add( key, new List<TValue>() );
			}

			m_dictionary[ key ].Add( value );
		}

		/// <summary>
		/// IEnumerator を返します
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return m_dictionary.GetEnumerator();
		}

		/// <summary>
		/// IEnumerator を返します
		/// </summary>
		public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
		{
			return m_dictionary.GetEnumerator();
		}

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( KeyValuePair<TKey, List<TValue>> pair )
		{
			foreach ( TValue value in pair.Value )
			{
				Add( pair.Key, value );
			}
		}

		/// <summary>
		/// 値を削除します
		/// </summary>
		public bool Remove( KeyValuePair<TKey, List<TValue>> pair )
		{
			return Remove( pair.Key );
		}

		/// <summary>
		/// 全ての要素を削除します
		/// </summary>
		public void Clear()
		{
			m_dictionary.Clear();
		}

		/// <summary>
		/// 指定されたキーに紐付くリストに値を追加します
		/// </summary>
		public void Add( TKey key, List<TValue> values )
		{
			foreach ( TValue value in values )
			{
				Add( key, value );
			}
		}

		/// <summary>
		/// 指定されたキーを削除します
		/// </summary>
		public bool Remove( TKey key )
		{
			return m_dictionary.Remove( key );
		}

		/// <summary>
		/// 指定されたキーが存在する場合 true を返します
		/// </summary>
		public bool ContainsKey( TKey key )
		{
			return m_dictionary.ContainsKey( key );
		}

		/// <summary>
		/// 指定されたキーに紐付く値を返します
		/// </summary>
		public bool TryGetValue( TKey key, out List<TValue> value )
		{
			return m_dictionary.TryGetValue( key, out value );
		}

		public bool Contains( KeyValuePair<TKey, List<TValue>> item )
		{
			throw new System.NotImplementedException();
		}

		public void CopyTo( KeyValuePair<TKey, List<TValue>>[] array, int arrayIndex )
		{
			throw new System.NotImplementedException();
		}
	}
}