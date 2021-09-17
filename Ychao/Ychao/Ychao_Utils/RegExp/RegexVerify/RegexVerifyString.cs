using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ychao.Util.RegExp.RegexVerify
{
    /* >> RegexVerifyString <<
     *  
     *  提供对字符串的校验功能
     * 
     */
    public sealed class RegexVerifyString : RegexVerify
    {
        /// <summary>
        /// 验证是否包含字符串片段
        /// </summary>
        public static bool VerifyContainStringSnippet(string input, string snippet)
        {
            return input.Contains(snippet);
        }

        /// <summary>
        /// 验证是否包含中文字符
        /// </summary>
        public static bool VerifyContainChineseChar(string input)
        {
            return IsMatch(input, RegexPatterns.ChineseCharPattern);
        }

        /// <summary>
        /// 验证是否包含日文字符
        /// </summary>
        public static bool VerifyContainJapaneseChar(string input)
        {
            return IsMatch(input, RegexPatterns.JapaneseCharPattern);
        }

        /// <summary>
        /// 验证是否包含韩文字符
        /// </summary>
        public static bool VerifyContainKoreanChar(string input)
        {
            return IsMatch(input, RegexPatterns.KoreanCharPattern);
        }

        /// <summary>
        /// 验证是否包含英文字母字符
        /// </summary>
        public static bool VerifyEnglishChar(string input)
        {
            return IsMatch(input, RegexPatterns.EnglishCharPattern);
        }

        /// <summary>
        /// 验证字符串中是否包含指定字符集
        /// </summary>
        public static bool VerifyContainChars(string input,char[] chars)
        {
            string pattern = "(?=.*[" + string.Join("", chars) + "]).+$";

            return IsMatch(input, pattern);
        }

        /// <summary>
        /// 验证是否包含数字
        /// </summary>
        public static bool VerifyContainNumber(string input)
        {
            return IsMatch(input, RegexPatterns.ContainNumberPattern);
        }

        /// <summary>
        /// 验证是否包含数字或字母
        /// </summary>
        public static bool VerifyContainNumOrLetter(string input)
        {
            return IsMatch(input, RegexPatterns.ContainNumLetterPattern);
        }


        void Func()
        {

        }

    }



}
