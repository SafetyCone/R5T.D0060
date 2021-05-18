using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.Magyar.IO;


namespace R5T.D0060
{
    /// <summary>
    /// For the local, currently executing machine.
    /// </summary>
    /// <remarks>
    /// See prior work in R5T.Gepidia.Local.
    /// </remarks>
    public class FileSystemOperator : IFileSystemOperator
    {
        public Task<IDictionary<TKey, bool>> DeleteFilesByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey)
        {
            var output = new Dictionary<TKey, bool>();
            foreach (var pair in filePathsByKey)
            {
                var exists = FileHelper.Exists(pair.Value);

                FileHelper.DeleteOnlyIfExists(pair.Value);

                output.Add(pair.Key, exists);
            }

            return Task.FromResult(output as IDictionary<TKey, bool>);
        }

        public async Task<IDictionary<TKey, string>> ReadContentsByKey<TKey>(IDistinctValuedDictionary<TKey, string> filePathsByKey)
        {
            var output = new Dictionary<TKey, string>();
            foreach (var pair in filePathsByKey)
            {
                var content = await FileHelper.Read(pair.Value);

                output.Add(pair.Key, content);
            }

            return output;
        }

        public async Task WriteContents(IDictionary<string, string> writes, bool overwrite = true)
        {
            foreach (var pair in writes)
            {
                await FileHelper.Write(pair.Key, pair.Value, overwrite);
            }
        }

        Task<IDictionary<string, IDistinctEnumerable<string>>> IFileSystemOperator.EnumerateFilePaths(IDistinctEnumerable<string> directoryPaths)
        {
            var output = new Dictionary<string, IDistinctEnumerable<string>>();
            foreach (var directoryPath in directoryPaths)
            {
                var filePaths = DirectoryHelper.EnumerateFilePaths(directoryPath);

                output.Add(directoryPath, filePaths);
            }

            return Task.FromResult(output as IDictionary<string, IDistinctEnumerable<string>>);
        }

        Task<IDictionary<string, bool>> IFileSystemOperator.ExistsFiles(IDistinctEnumerable<string> filePaths)
        {
            var output = new Dictionary<string, bool>();
            foreach (var filePath in filePaths)
            {
                var fileExists = FileHelper.Exists(filePath);

                output.Add(filePath, fileExists);
            }

            return Task.FromResult(output as IDictionary<string, bool>);
        }
    }
}
