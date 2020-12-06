using System;
using System.Collections.Generic;
using CornSDK;

namespace ddlBot
{
    class Program
    {
        static void Main(string[] args)
        {
            C.QQ = new Corn(new CornConfig()
            {
                listenPort = 3668,
                handlers = new Dictionary<long, ICornEventHandler>()
                {
                    [C.self] = new MsgHandler(),
                }
            });
            while (true)
            {
                var em = Console.ReadLine();
                if (em is null)
                    continue;
                try
                {
                    Console.WriteLine(Cmds.RunCommand(0, em));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}