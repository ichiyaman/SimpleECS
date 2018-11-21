using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  StringExtentions
/// </summary>
public static class StringExtentions {

	public static bool FastStartsWith( this string a, string b )
	{
		int aLen = a.Length;
		int bLen = b.Length;
		int ap = 0;
		int bp = 0;
	
		while ( ap < aLen && bp < bLen && a[ ap ] == b[ bp ] )
		{
			ap++;
			bp++;
		}
	
		return ( bp == bLen && aLen >= bLen ) || ( ap == aLen && bLen >= aLen );
	}
	
	public static bool FastEndsWith( this string a, string b )
	{
		int ap = a.Length - 1;
		int bp = b.Length - 1;
	
		while ( ap >= 0 && bp >= 0 && a[ ap ] == b[ bp ] )
		{
			ap--;
			bp--;
		}
	
		return ( bp < 0 && a.Length >= b.Length ) || ( ap < 0 && b.Length >= a.Length );
	}
	
	public static string Coloring(this string str, string color) {
		return string.Format ("<color={0}>{1}</color>", color, str);
	}
	public static string Red(this string str) {
		return str.Coloring ("red");
	}
	public static string Green(this string str) {
		return str.Coloring ("green");
	}
	public static string Blue(this string str) {
		return str.Coloring ("blue");
	}

	public static string Resize(this string str, int size) {
		return string.Format ("<size={0}>{1}</size>", size, str);
	}
	public static string Medium(this string str) {
		return str.Resize (11);
	}
	public static string Small(this string str) {
		return str.Resize (9);
	}
	public static string Large(this string str) {
		return str.Resize (16);
	}

	public static string Bold(this string str) {
		return string.Format ("<b>{0}</b>", str);
	}
	public static string Italic(this string str) {
		return string.Format ("<i>{0}</i>", str);
	}	
}
