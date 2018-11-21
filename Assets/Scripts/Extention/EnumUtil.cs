using System;
using System.Collections.Generic;

/// <summary>
/// ジェネリックを利用した汎用ヘルパクラス
/// https://qiita.com/tricogimmick/items/38fe86a09e8e0865d471 
/// </summary>
/// <typeparam name="T"></typeparam>

static class EnumUtil<T>
{
	// 整数値が enum で定義済みかどうか？
	public static bool IsDefined(int n)
	{
		return Enum.IsDefined(typeof(T), n);
	}

	// Foreach用のGetEnumeratorを持つヘルパクラス
	public class EnumerateEnum
	{
		public IEnumerator<T> GetEnumerator()
		{
			foreach (T e in Enum.GetValues(typeof(T)))
				yield return e;
		}
	}

	// enum定義をforeachに渡すためのヘルパクラスを返す
	public static EnumerateEnum Enumerate()
	{
		return new EnumerateEnum();
	}
}