﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace WebSurge.Cli
{
    public class CommandLineOptions 
    {
        public string Url { get; set; }

        [ValueOption(1)]        
        public string SessionFile { get; set;  }

        [Option('s',"seconds",HelpText = "Length of time in seconds to run the test")]
        public int Time { get; set;  }

        [Option('t',"threads",HelpText = "Number of simultaneous threads to run")]
        public int Threads { get; set; }

        [Option('d', "delay", HelpText = "DelayTimeMs between individual requests in milliseconds")]
        public int DelayTimeMs { get; set; }

        [Option('r', "randomize", HelpText = "Randomize requests in the Session file.")]
        public bool RandomizeRequests { get; set; }

        [Option('y', "silent", HelpText = "Silent operation - output only results.")]
        public bool Silent { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("West Wind WebSurge v" + Program.GetVersion());            

            string options = @"------------------------
usage:   WebSurgeCli <SessionFile|Url> -sXX -tXX -dXX -r -y

Parameters:
-----------
SessionFile     Filename to a WebSurge/Fiddler HTTP session file
Url             Single URL to to hit

Commands:
---------
-h | -?      This help display           

Value Options:
--------------
-s          Number of seconds to run the test (10)
-t          Number of simultaneous threads to run (2)
-d          Per request delay (0)

Switches:
---------
-r          Randomize order of requests in Session file
-y          Silent operation - output only results

Examples:
---------
WebSurgeCli c:\temp\LoadTest.txt  -s20 -t10
WebSurgeCli http://localhost/testpage/  -s20 -t10
";

            sb.AppendLine(options);            
            return sb.ToString();
        }
        

        public CommandLineOptions()
        {
            Time = 10;
            Threads = 2;
        }
    }
}
