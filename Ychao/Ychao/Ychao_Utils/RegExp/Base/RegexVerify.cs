using System;
using System.Text.RegularExpressions;

namespace Ychao.Util.RegExp.RegexVerify
{
    /* >> RegexVerify <<
     * 
     *  正则验证工具 【基类功能】
     *  
     *  使用正则表达式, 进行字符串校验的工作
     * 
     *  A ---> 数字校验
     *  B ---> 字符串校验
     *  C ---> 常规校验
     *  
     */

    public abstract class RegexVerify : BaseRegex
    {
        protected static bool IsMatch(string input, string pattern)
        {
            try
            {
                var isMatch = Regex.IsMatch(input, pattern);
                return isMatch;
            }
            catch (RegexMatchTimeoutException RMTE)
            {
                Console.WriteLine(TAG + RMTE.Message);
                return false;
            }
            catch (ArgumentNullException ANE)
            {
                Console.WriteLine(TAG + ANE.Message);
                return false;
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(TAG + AE.Message);
                return false;
            }
        }

    }
}
