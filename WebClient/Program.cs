using System;
using System.Xml.Schema;

namespace WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var caller = new WebCaller();
            var result = caller.DoACall("https://gitlab-stg.gigya.net/");
        }
    }
}