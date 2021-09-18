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
                case PassWordFormat._1:
                    return IsMatch(input, "^\\d+$");
                case PassWordFormat._Aa:
                    return IsMatch(input, "^[A-Za-z]+$");
                case PassWordFormat._1Aa:
                    return IsMatch(input, "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]+$");
                case PassWordFormat._1orAa:
                    return IsMatch(input, "^[A-Za-z0-9]+$");
                case PassWordFormat._1Aa_U:
                    return IsMatch(input, "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]+$");
                case PassWordFormat._1AaU_point:
                    return IsMatch(input, "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*\\.)[A-Za-z\\d.]+$");


                case PassWordFormat._1orAa_or_point:
                    return IsMatch(input, "^[A-Za-z0-9.]+$");
                case PassWordFormat.U_1Aa:
                    return IsMatch(input, "^[A-Z]{1}[a-zA-Z0-9]+$");

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

        /// <summary>
        /// 验证用户名合法性
        /// </summary>
        public static bool VerifyUserName(string input, UserNameFormat nameFormat)
        {
            switch (nameFormat)
            {
                case UserNameFormat.Aa1_:
                    return IsMatch(input, "^[A-Za-z]{1}[\\w]+$");
                case UserNameFormat.a1_ignoreCase:
                    return IsMatch(input, "^(?i)[A-Za-z]{1}[\\w]+$");


                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// 验证昵称格式合法性
        /// </summary>
        public static bool VerifyNickName(string input, NickNameFormat nameFormat)
        {
            switch (nameFormat)
            {
                case NickNameFormat.En:
                    return IsMatch(input, "^\\w+$");
                case NickNameFormat.En_Zn:
                    return IsMatch(input, "^[\\w\\u4e00-\\u9fa5]+$");
                case NickNameFormat.En_Zn_Jp:
                    return IsMatch(input, "^[\\w\u4e00-\u9fa5\u0800-\u4e00]+$");
                case NickNameFormat.En_Kr:
                    return IsMatch(input, "^[\\w(\x3130-\x318F|\xAC00-\xD7A3)]+$");
                case NickNameFormat.En_Jp:
                    return IsMatch(input, "^[\\w\u0800-\u4e00]+$");
                case NickNameFormat.cn_hk:
                    return IsMatch(input, "^[\\w\u3400-\u4db5\u4e00-\u9fa5]+$");
                default:
                    break;
            }
            return false;
        }






        public enum UserNameFormat
        {
            /// <summary>
            /// 可由数字字母下划线组成, 必须字母开头,大小写敏感
            /// </summary>
            Aa1_,
            /// <summary>
            /// 可由数字字母下划线组成, 必须字母开头,大小写不敏感
            /// </summary>
            a1_ignoreCase,

        }
        public enum NickNameFormat
        {
            /// <summary>
            /// 英文, 包括英文字符
            /// </summary>
            En,
            /// <summary>
            /// 中英文
            /// </summary>
            En_Zn,
            /// <summary>
            /// 中日英
            /// </summary>
            En_Zn_Jp,
            /// <summary>
            /// 英韩
            /// </summary>
            En_Kr,
            /// <summary>
            /// 英日
            /// </summary>
            En_Jp,
            /// <summary>
            /// 简繁体
            /// </summary>
            cn_hk,

        }
        public enum PassWordFormat
        {
            /// <summary>
            /// 仅数字组成
            /// </summary>
            _1,
            /// <summary>
            /// 仅英文组成
            /// </summary>
            _Aa,
            /// <summary>
            /// 数字和英文组成
            /// </summary>
            _1Aa,
            /// <summary>
            /// 数字或英文组成
            /// </summary>
            _1orAa,
            /// <summary>
            /// 数字和英文组成, 必有一个大写和小写
            /// </summary>
            _1Aa_U,
            /// <summary>
            /// 数字, 大小写, [.]
            /// </summary>
            _1AaU_point,
            /// <summary>
            /// With Special Char
            /// </summary>
           // With_SpecialChar,
            /// <summary>
            /// 由数字,字母,[.]组成, 非必要包含
            /// </summary>
            _1orAa_or_point,
            /// <summary>
            /// 开头字母大写,包含数字与字母,无特殊符号
            /// </summary>
            U_1Aa

        }
    }
}
