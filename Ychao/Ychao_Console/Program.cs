using System;
using Ychao.Util.RegExp.RegexVerify;

namespace Ychao_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine( RegexVerifyString.VerifyContainChars("啊实打实大苏打实打实大 ",new char[] { '#',' ','$','@'}));
            
           // var a = { new int[]}

        }
    }
}
