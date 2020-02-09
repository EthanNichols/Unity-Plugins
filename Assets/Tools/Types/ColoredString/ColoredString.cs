using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColoredString
{
		/// <summary>
		/// The text that will be colored
		/// </summary>
		[DisplayName("String")]
		public string str;
		/// <summary>
		/// The color that the text will appear as
		/// </summary>
		public Color color;


		#region Cast Operators

		/// <summary>
		/// Operator to cast from TimeSpanProperty to System.TimeSpan
		/// </summary>
		public static implicit operator string(ColoredString coloredString)
		{
				return coloredString.str;
		}


		/// <summary>
		/// Operator to cast from System.TimeSpan to TimeSpanProperty
		/// </summary>
		public static implicit operator ColoredString(string str)
		{
				return new ColoredString() { str = str };
		}

		#endregion


		/// <summary>
		/// Return a string with the color markup
		/// </summary>
		/// <param name="stripColor">If true the color markup won't be added to the string</param>
		public string ToString(bool stripColor = false)
		{
				if (stripColor)
				{
						return str;
				}

				return ToString();
		}


		/// <summary>
		/// Return a string with the color markup
		/// </summary>
		public override string ToString()
		{
				return string.Format("<color=#{0}>{1}</color>", color.HexStringRGB(), str);
		}
}
