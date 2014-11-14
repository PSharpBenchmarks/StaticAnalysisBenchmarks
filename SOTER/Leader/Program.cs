using System;
using System.Collections.Generic;
using Microsoft.PSharp;

namespace Leader
{
    /// <summary>
    /// This is an example of usign P#.
    /// 
    /// This example implements the leader election benchmark.
    /// It attempts to be a faithful port from the SOTER
    /// actor version.
    /// </summary>
    public class Program
    {
        public static void Go()
        {
            Runtime.RegisterNewEvent(typeof(eLocal));
            Runtime.RegisterNewEvent(typeof(eStart));
            Runtime.RegisterNewEvent(typeof(eInit));
            Runtime.RegisterNewEvent(typeof(eReceive));

            Runtime.RegisterNewMachine(typeof(Driver));
            Runtime.RegisterNewMachine(typeof(LProcess));

            Runtime.Start(30);
            Runtime.Wait();
            Runtime.Dispose();
        }

        static void Main(string[] args)
        {
            Go();
        }
    }

    public class ChessTest
    {
        public static bool Run()
        {
            Program.Go();
            return true;
        }
    }
}
