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
            if (Regex.IsMatch(input, pattern))
                return true;
            return false;
        }

    }
}
