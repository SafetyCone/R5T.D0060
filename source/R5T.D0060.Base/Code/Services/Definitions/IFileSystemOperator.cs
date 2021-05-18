using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Magyar.IO;


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
    public interface IFileSystemOperator
    {
        Task<IDictionary<TKey, bool>> DeleteFilesByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey);
        Task<IDictionary<string, IDistinctEnumerable<string>>> EnumerateFilePaths(IDistinctEnumerable<string> directoryPaths);
        Task<IDictionary<string, bool>> ExistsFiles(IDistinctEnumerable<string> filePaths);
        Task<IDictionary<TKey, string>> ReadContentsByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey);
        Task WriteContents(IDictionary<string, string> writes, bool overwrite = IOHelper.DefaultOverwriteValue);
    }
}
