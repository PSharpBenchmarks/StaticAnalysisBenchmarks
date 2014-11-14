﻿using System;
using System.Collections.Generic;
using Microsoft.PSharp;

namespace TwoPhaseCommit
{
    /// <summary>
    /// This is an example of usign P#.
    /// 
    /// This example implements a replication system.
    /// </summary>
    public class Program
    {
        public static void Go()
        {
            Runtime.RegisterNewEvent(typeof(eREQ_REPLICA));
            Runtime.RegisterNewEvent(typeof(eRESP_REPLICA_COMMIT));
            Runtime.RegisterNewEvent(typeof(eRESP_REPLICA_ABORT));
            Runtime.RegisterNewEvent(typeof(eGLOBAL_ABORT));
            Runtime.RegisterNewEvent(typeof(eGLOBAL_COMMIT));
            Runtime.RegisterNewEvent(typeof(eWRITE_REQ));
            Runtime.RegisterNewEvent(typeof(eWRITE_FAIL));
            Runtime.RegisterNewEvent(typeof(eWRITE_SUCCESS));
            Runtime.RegisterNewEvent(typeof(eREAD_REQ));
            Runtime.RegisterNewEvent(typeof(eREAD_FAIL));
            Runtime.RegisterNewEvent(typeof(eREAD_UNAVAILABLE));
            Runtime.RegisterNewEvent(typeof(eREAD_SUCCESS));
            Runtime.RegisterNewEvent(typeof(eUnit));
            Runtime.RegisterNewEvent(typeof(eUpdate));
            Runtime.RegisterNewEvent(typeof(eStop));
            Runtime.RegisterNewEvent(typeof(eTimeout));
            Runtime.RegisterNewEvent(typeof(eStartTimer));
            Runtime.RegisterNewEvent(typeof(eCancelTimer));
            Runtime.RegisterNewEvent(typeof(eCancelTimerFailure));
            Runtime.RegisterNewEvent(typeof(eCancelTimerSuccess));
            Runtime.RegisterNewEvent(typeof(eMONITOR_WRITE));
            Runtime.RegisterNewEvent(typeof(eMONITOR_READ_SUCCESS));
            Runtime.RegisterNewEvent(typeof(eMONITOR_READ_UNAVAILABLE));

            Runtime.RegisterNewMachine(typeof(Master));
            Runtime.RegisterNewMachine(typeof(Timer));
            Runtime.RegisterNewMachine(typeof(Replica));
            Runtime.RegisterNewMachine(typeof(Coordinator));
            Runtime.RegisterNewMachine(typeof(Client));
            Runtime.RegisterNewMachine(typeof(Monitor));

            Runtime.Start();
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
