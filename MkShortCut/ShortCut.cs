using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MkShortCut {

    public static class ShortCut {

        /// <summary>
        /// Windows Script Host Class ID
        /// </summary>
        private const string WshClassID = "72C24DD5-D70A-438B-8A42-98424B88AFB8";

        private const string ShortCutExtension = ".lnk";

        public static string Message { get; private set; }

        /// <summary>
        /// create the shortcut.
        /// </summary>
        /// <param name="targetPath">The shortcut's target path.</param>
        /// <param name="outputPath">The pathname of the shortcut to create. If omitted, this will be the current directory.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>
        /// - ==0: succeeded.
        /// - !=0: failed.
        /// </returns>
        /// <remarks>
        /// - [ショートカットを作成する: .NET Tips: C#, VB.NET](http://dobon.net/vb/dotnet/file/createshortcut.html)
        /// </remarks>
        public static int Create(
            string targetPath,
            string outputPath = null,
            string arguments = null
        ) {
            var targetPath2 = Path.GetFullPath(Environment.ExpandEnvironmentVariables(targetPath));
            if(!File.Exists(targetPath2)) {
                Message = "TargetPath not exist: " + targetPath;
                return 1;
            }
            var outputPath2 = outputPath == null ?
                Directory.GetCurrentDirectory() :
                Path.GetFullPath(Environment.ExpandEnvironmentVariables(outputPath));
            outputPath2 = !Directory.Exists(outputPath2) ?
                outputPath2 + ShortCutExtension :
                Path.Combine(outputPath2, Path.GetFileNameWithoutExtension(targetPath2) + ShortCutExtension);
            dynamic shell = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(WshClassID)));
            var shortcut = shell.CreateShortcut(outputPath2);
            shortcut.TargetPath = targetPath2;
            shortcut.IconLocation = targetPath2;
            shortcut.Arguments = arguments;
            shortcut.Save();
            Marshal.FinalReleaseComObject(shortcut);
            Marshal.FinalReleaseComObject(shell);
            Message = "ShortCut was made: " + outputPath2;
            return 0;
        }
    }
}
