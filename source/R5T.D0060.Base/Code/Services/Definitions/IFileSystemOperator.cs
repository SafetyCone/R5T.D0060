using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0060
{
    /// <summary>
    /// Operates on a file system.
    /// </summary>
    /// <remarks>
    /// Unline other operators, the file system the operator operates upon is implicit.
    /// See prior (synchronous) work in R5T.Gepidia.Base.
    /// Stringly-typed paths.
    /// </remarks>
    [ServiceDefinitionMarker]
    public interface IFileSystemOperator : IServiceDefinition
    {
        Task<IDictionary<TKey, bool>> DeleteFilesByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey);
        Task<IDictionary<string, IDistinctEnumerable<string>>> EnumerateFilePaths(IDistinctEnumerable<string> directoryPaths);
        Task<IDictionary<string, bool>> ExistsFiles(IDistinctEnumerable<string> filePaths);
        Task<IDictionary<TKey, string>> ReadContentsByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey);
        Task WriteContents(IDictionary<string, string> writes, bool overwrite = IOHelper.DefaultOverwriteValue);
    }
}
