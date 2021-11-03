using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NSOL.Extensions.StringExt
{
	public static class StringExtensions
	{
		private const string GUID_PATTERN = @"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$";

		/// <summary>
		/// Является ли строк GUID
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsGuid(this string value)
		{
			if (string.IsNullOrEmpty(value)) return false;
			return Regex.Match(value, GUID_PATTERN).Success;
		}

		public static bool IsEmptyGuid(this string value)
		{
			if (value.IsGuid())
			{
				return Guid.Parse(value) == Guid.Empty;
			}
			return false;
		}

		/// <summary>
		/// Обрезаем строку по длине
		/// </summary>
		/// <param name="value"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static string Truncate(this string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value)) return value;
			return value.Length <= maxLength ? value : value.Substring(0, maxLength);
		}

		/// <summary>
		/// Обрезаем строку по длине, в конец добавляем текст
		/// </summary>
		/// <param name="value"></param>
		/// <param name="maxLength">кол-во символов до которого нужно обрезать</param>
		/// <param name="postfixMsg">сообщение в конец</param>
		/// <returns></returns>
		public static string Truncate(this string value, int maxLength, string postfixMsg)
		{
			if (string.IsNullOrEmpty(value)) return value;

			if (!string.IsNullOrEmpty(postfixMsg))
			{
				maxLength -= postfixMsg.Length;
			}
			return value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), postfixMsg);
		}

		/// <summary>
		/// Реверс строки
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Reverse2(this string value)
		{
			char[] charArray = value.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
