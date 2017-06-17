using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bfcs {
    class bfcs {
        private static char[] cells = new char[Int16.MaxValue];
        private static int cellLocation = 0;
        public static int bfParse(char[] commands, bool isLoop) {
        redo:
            //Console.Write(String.Join("",commands));
            if(isLoop & (int)cells[cellLocation] == 0) return 0;
            for(long i = 0;i < commands.LongLength;++i) {
                switch(commands[i]) {
                    case '<':
                        --cellLocation;
                        break;
                    case '>':
                        ++cellLocation;
                        break;
                    case '+':
                        ++cells[cellLocation];
                        break;
                    case '-':
                        --cells[cellLocation];
                        break;
                    case '.':
                        Console.Write(cells[cellLocation]);
                        break;
                    case '!':
                        Console.Write((int)cells[cellLocation] + " ");
                        break;
                    case ',':
                        cells[cellLocation] = Console.ReadKey().KeyChar;
                        break;
                    case '[':
                        ulong passedLeftSquareBracket = 0;
                        string loopString = "";
                        for(;;) {
                            ++i;
                            if(commands[i] == '[') ++passedLeftSquareBracket;
                            if(commands[i] == ']') {
                                if(passedLeftSquareBracket > 0) {
                                    --passedLeftSquareBracket;
                                } else {
                                    break;
                                }
                            }
                            loopString += commands[i].ToString();
                        }
                        bfParse(loopString.ToCharArray(), true);
                        break;
                }
            }
            if(isLoop) goto redo;
            return 0;




        }
    }
}
