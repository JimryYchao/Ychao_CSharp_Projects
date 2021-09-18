# Ychao.Utils.RegExp


- RegexCatch【正则捕捉】
 


- RegexReplace【正则替换】



- RegexVerify【正则验证】
   - RegexVerifyNumber【提供校验数字功能】
     - VerifyNumber(string input)【验证实数】
     - VerifyInteger(string input)【验证整数】
     - VerifyNaturalNumber(string input)【验证自然数】
     - VerifyDecimal(string input)【验证小数】
     - VerifyPositiveInteger(string input)【验证正整数】
     - VerifyNegativeInteger(string input)【验证负整数】
     - VerifyPositiveNumber(string input)【验证正数】
     - VerifyNegativeNumber(string input)【验证负数】
     - VerifyFraction(string input)【验证分数】
     - VerifyPercentage(string input)【验证百分数】
   
   - RegexVerifyString【提供校验字符串功能】
     - VerifyContainStringSnippet(string input, string snippet)【验证是否包含字符串片段】
     - VerifyContainChineseChar(string input)【验证是否包含中文】
     - VerifyContainJapaneseChar(string input)【验证是否包含日文】
     - VerifyContainKoreanChar(string input)【验证是否包含韩文】
     - VerifyEnglishChar(string input) 【验证是否包含英文】
     - VerifyContainChars(string input,char[] chars)【验证字符串中是否包含指定字符集】
     - VerifyContainNumber(string input)【验证是否包含数字】
     - VerifyContainNumOrLetter(string input)【验证是否包含数字或字母】
     
   - RegexVerifyNormal【提供常规情景验证方法】
     - VerifyQQNumber(string input)【验证QQ格式】
     - VerifyStringLength(string input, int minLength, int maxLength)【校验字符串长度】
     - VerifyPassword(string input, PassWordFormat format)【校验密码格式合法性】
     - VerifyEmail(string input)【验证邮箱格式】
     - VerifyIPv4(string input)【验证IPv4】
     - VerifyIPv6(string input)【验证IPv6】
     - VerifyMobileTel(string input)【验证国内手机号码格式】
     - VerifyFixedLineTel(string input)【验证固定电话格式】
     - VerifyLongitude(string input)【验证地理经度】
     - VeridyLatitude(string input)【验证地理纬度】
     - VerifyUserName(string input, UserNameFormat nameFormat)【验证用户名合法性】
     - VerifyNickName(string input, NickNameFormat nameFormat)【验证昵称合法性】

- RegexPatterns【表达式参考】

