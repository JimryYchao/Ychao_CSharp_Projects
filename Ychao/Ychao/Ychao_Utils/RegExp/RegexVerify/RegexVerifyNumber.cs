


namespace Ychao.Util.RegExp.RegexVerify
{
    /* >> RegexVerifyNumber <<
     *  
     *  提供对数字字符串类型的校验功能
     * 
     */

    public sealed class RegexVerifyNumber : RegexVerify
    {
        /// <summary>
        /// 验证实数
        /// </summary>
        public static bool VerifyNumber(string input)
        {
            return IsMatch(input, RegexPatterns.NumberPattern);
        }

        /// <summary>
        /// 验证整数
        /// </summary>
        public static bool VerifyInteger(string input)
        {
            return IsMatch(input, RegexPatterns.IntegerPattern);
        }

        /// <summary>
        /// 验证自然数
        /// </summary>
        public static bool VerifyNaturalNumber(string input)
        {
            return IsMatch(input, RegexPatterns.NaturalNumberPattern);
        }

        /// <summary>
        /// 验证小数 
        /// </summary>
        public static bool VerifyDecimal(string input)
        {
            return IsMatch(input, RegexPatterns.DecimalPattern);
        }

        /// <summary>
        /// 验证正整数 
        /// </summary>
        public static bool VerifyPositiveInteger(string input)
        {
            return IsMatch(input, RegexPatterns.PositiveIntegerPattern);
        }

        /// <summary>
        /// 验证负整数 
        /// </summary>
        public static bool VerifyNegativeInteger(string input)
        {
            return IsMatch(input, RegexPatterns.NegativeIntegerPatttern);
        }

        /// <summary>
        /// 验证正数 
        /// </summary>
        public static bool VerifyPositiveNumber(string input)
        {
            return IsMatch(input, RegexPatterns.PositiveNumberPattern);
        }

        /// <summary>
        /// 验证负数 
        /// </summary>
        public static bool VerifyNegativeNumber(string input)
        {
            return IsMatch(input, RegexPatterns.NegativeNumberPattern);
        }

        /// <summary>
        /// 验证分数
        /// </summary>
        public static bool VerifyFraction(string input)
        {
            return IsMatch(input, RegexPatterns.FractionPattern);
        }

        /// <summary>
        /// 验证百分数
        /// </summary>
        public static bool VerifyPercentage(string input)
        {
            return IsMatch(input, RegexPatterns.PercentagePattern);
        }

    }
}
