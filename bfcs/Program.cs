using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace bfcs {
    
    class Program {
        static char[] cells = new char[Int16.MaxValue];
        static int cellLocation = 0;
        static void Main(string[] args) {
            string bfString;
            if(args.Length == 0){
                //print usage
                string[] usage = {"brainfuck C# Usage:",
                                  "    bfcs.exe <brainfuck string>",
                                  "    bfcs.exe -f <file>"
                                 };
                foreach(string line in usage) {
                    Console.WriteLine(line);
                }
            }else if(args[0] == "-f") {
                //from file
                try {
                    bfString = System.IO.File.ReadAllText(args[1]);
                    bfcs.bfParse(bfString.ToCharArray(), false);
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                }
            } else {
                bfString = String.Join("", args);
                bfcs.bfParse(bfString.ToCharArray(), false);
            }
        }
       
    }
}
