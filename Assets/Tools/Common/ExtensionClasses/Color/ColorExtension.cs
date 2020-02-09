using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extension class for <see cref="Color"/>
/// </summary>
public static class ColorExtension
{
		/// <summary>
		/// Get the RGB hex string of the color #XXXXXX
		/// </summary>
		public static string HexStringRGB(this Color color)
		{
				return ColorUtility.ToHtmlStringRGB(color);
		}


		/// <summary>
		/// Get the RGBA hex string of the color #XXXXXXXX
		/// </summary>
		public static string HexStringRGBA(this Color color)
		{
				return ColorUtility.ToHtmlStringRGBA(color);
		}


		/// <summary>
		/// Parse a color string and set it to this color <para />
		///
		/// Strings that begin with '#' will be parsed as hexadecimal in the following way: #RRGGBB or #RRGGBBAA <para />
		///
		/// Strings that do not begin with '#' will be parsed as literal colors, with the following supported: <para />
		/// red, cyan, blue, darkblue, lightblue, purple, yellow, lime, fuchsia, white, silver, grey, black, orange, brown, maroon, green, olive, navy, teal, aqua, magenta.
		///
		/// </summary>
		/// <param name="color">The color that will be set</param>
		/// <param name="str"></param>
		/// <returns></returns>
		public static void ParseHexString(this Color color, string str)
		{
				ColorUtility.TryParseHtmlString(str, out color);
		}
}
