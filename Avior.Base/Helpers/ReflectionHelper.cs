using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Avior.Base.Helpers
{
    public class ReflectionHelper
    {
        private static readonly Lazy<Assembly[]> _applicationAssemblies = new Lazy<Assembly[]>(() =>
        {
            LoadAllBinDirectoryAssemblies();

            return AppDomain.CurrentDomain.GetAssemblies().ToArray();
        });

        public static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            return _applicationAssemblies.Value;
        }

        public static IEnumerable<Assembly> GetAviorAssemblies()
        {
            return GetApplicationAssemblies()
                .Where(assembly => assembly.FullName.ToLower().StartsWith("avior."));
        }

        public static void LoadAllBinDirectoryAssemblies()
        {
            var codebaseUriString = Assembly.GetExecutingAssembly().GetName().CodeBase;
            var binPath = Path.GetDirectoryName(new Uri(codebaseUriString).LocalPath);
            var assemblyFiles = Directory.GetFiles(binPath, "*.*", SearchOption.AllDirectories)
                .Where(f =>
                {
                    var ext = Path.GetExtension(f).ToLower();
                    return ext == ".dll" || ext == ".exe";
                });

            foreach (var assemblyFile in assemblyFiles)
            {
                try
                {
                    var assemblyName = AssemblyName.GetAssemblyName(assemblyFile);
                    var isLoaded = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName == assemblyName.FullName);
                    if (!isLoaded)
                    {
                        var loadedAssembly = Assembly.LoadFile(assemblyFile);
                    }
                }
                catch (FileLoadException)
                { }
                catch (BadImageFormatException)
                { } 
            } 
        }
    }
}
