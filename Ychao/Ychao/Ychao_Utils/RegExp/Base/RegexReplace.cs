using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ychao.Util.RegExp.RegexReplace
{
    public abstract class RegexReplace : BaseRegex
    {

        /// <summary>
        /// 替换匹配或返回原始字符串
        /// </summary>
        protected string Replace(string input, string pattern, string replacement, RegexOptions options = RegexOptions.None)
        {
            try
            {
                return Regex.Replace(input, pattern, replacement, options);

            }
            catch (RegexMatchTimeoutException RMTE)
            {
                Console.WriteLine(TAG + RMTE.Message);
                return null;
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(TAG + AE.Message);
                return null;
            }
        }

        /// <summary>
        /// 自定义 evaluator 方法, 检查每个匹配并返回原始或替换字符串
        /// </summary>
        protected static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options = RegexOptions.None)
        {
            try
            {
                return Regex.Replace(input, pattern, evaluator, options);

            }
            catch (RegexMatchTimeoutException RMTE)
            {
                Console.WriteLine(TAG + RMTE.Message);
                return null;
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(TAG + AE.Message);
                return null;
            }

        }



    }
}
