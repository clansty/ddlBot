using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace ddlBot
{
    public class Cmds
    {
        public static string RunCommand(long sdr, string command)
        {
            try
            {
                var key = (command.Contains(' ') ? command.ToLower() : command.GetLeft(" ")).ToLower();
                var act = command.GetRight(" ");
                switch (key)
                {
                    case "link":
                    case "token":
                    case "url":
                    case "ui":
                    {
                        var ret = (C.backendUrl + "/api/bot/resetToken")
                            .WithHeader("x-auth", C.botToken)
                            .PostJsonAsync(
                                new
                                {
                                    uid = Md5(sdr.ToString())
                                })
                            .ReceiveJson<JObject>().Result;
                        if (ret.Value<int>("code") == 200)
                            return C.frontendUrl + "/#/u/" + ret.Value<string>("newToken");
                        return "Server Request Error:\n" + ret;
                    }
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        private static string Md5(string str)
        {
            var md5 = MD5.Create();
            var byteOld = Encoding.UTF8.GetBytes(str);
            var byteNew = md5.ComputeHash(byteOld);
            var sb = new StringBuilder();
            foreach (var b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}