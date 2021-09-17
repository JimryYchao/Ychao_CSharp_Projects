using System;
using System.Collections.Generic;

namespace Ychao.Util.RegExp.RegexVerify
{
    /* >> RegexVerifyNormal <<
     *  
     *  提供一些情境下的字符串校验功能
     * 
     */

    public sealed class RegexVerifyNormal : RegexVerify
    {
        /// <summary>
        /// 验证 QQ 号码格式
        /// </summary>
        public static bool VerifyQQNumber(string input)
        {
            return IsMatch(input, RegexPatterns.QQNumberPattern);
        }

        /// <summary>
        /// 验证 input 字符串长度是否在要求范围内
        /// </summary>
        public static bool VerifyStringLength(string input, int minLength, int maxLength)
        {
            return IsMatch(input, "^\\d{" + minLength + "," + maxLength + "}$");
        }

        /// <summary>
        /// 验证 Password 格式
        /// </summary>
        public static bool VerifyPassword(string input, PassWordFormat format)
        {
            switch (format)
            {
                case PassWordFormat.Only_N:
                    return IsMatch(input, "^\\d+$");
                case PassWordFormat.Only_L:
                    return IsMatch(input, "^[A-Za-z]+$");
                case PassWordFormat.Must_N_and_L:
                    return IsMatch(input, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]+$");
                case PassWordFormat.With_N_or_L:
                    return IsMatch(input, "^[A-Za-z0-9]+$");
                case PassWordFormat.NL_1_Upper:
                    return IsMatch(input, "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]+$");
                case PassWordFormat.NLU_1_point:
                    return IsMatch(input, "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*\\.)[A-Za-z\\d.]+$");
             //   case PassWordFormat.Without_IllegalChar:
             //       return IsMatch(input, @"^[^!@~`#$%^*():;""]+$");

                case PassWordFormat.A_Za_z0_9_point:
                    return IsMatch(input, "^[A-Za-z0-9.]+$");

            }
            return false;
        }

        /// <summary>
        /// 验证邮箱格式
        /// </summary>
        public static bool VerifyEmail(string input)
        {
            return IsMatch(input, RegexPatterns.EmailPattern);
        }

        /// <summary>
        /// 验证 IPv4 地址格式
        /// </summary>
        public static bool VerifyIPv4(string input)
        {
            return IsMatch(input, RegexPatterns.IPv4Pattern);
        }

        /// <summary>
        /// 验证 IPv6 地址格式
        /// </summary>
        public static bool VerifyIPv6(string input)
        {
            return IsMatch(input, RegexPatterns.IPv6Pattern);
        }

        /// <summary>
        /// 验证手机号格式, 从13-19开头校验, 号码有效性不校验
        /// </summary>
        public static bool VerifyMobileTel(string input)
        {
            return IsMatch(input, RegexPatterns.MobTelPattern);
        }

        /// <summary>
        /// 验证国内固定电话格式
        /// </summary>
        public static bool VerifyFixedLineTel(string input)
        {
            return IsMatch(input, RegexPatterns.FixedLineTelPattern);
        }

        /// <summary>
        /// 验证地理经度
        /// </summary>
        public static bool VerifyLongitude(string input)
        {
            return IsMatch(input, RegexPatterns.LongitudePattern);
        }

        /// <summary>
        /// 验证地理纬度
        /// </summary>
        public static bool VeridyLatitude(string input)
        {
            return IsMatch(input, RegexPatterns.LatitudePattern);
        }

        public enum PassWordFormat
        {
            /// <summary>
            /// N : Number
            /// </summary>
            Only_N,
            /// <summary>
            /// L : Letter
            /// </summary>
            Only_L,
            /// <summary>
            /// Number and Letter
            /// </summary>
            Must_N_and_L,
            /// <summary>
            /// Number || Letter
            /// </summary>
            With_N_or_L,
            /// <summary>
            /// At least one Upper Letter
            /// </summary>
            NL_1_Upper,
            /// <summary>
            /// At least one Upper Letter and [.]
            /// </summary>
            NLU_1_point,
            /// <summary>
            /// With Special Char
            /// </summary>
           // With_SpecialChar,
            /// <summary>
            /// Number or Letter or point
            /// </summary>
            A_Za_z0_9_point,


        }
    }
}
