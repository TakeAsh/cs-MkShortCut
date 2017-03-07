using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkShortCut {

    class Program {

        static int Main(string[] args) {
            if(args.Length < 1) {
                Console.WriteLine("usage: MkShortCut <TargetPath> [<OutputPath> [<Arguments>]]");
                return 1;
            }
            var result = ShortCut.Create(
                args[0],
                args.Length < 2 ? null : args[1],
                args.Length < 3 ? null : args[2]
            );
            Console.WriteLine(ShortCut.Message);
            return result;
        }
    }
}
