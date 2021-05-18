using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.D0060
{
    public static class IFileSystemOperatorExtensions
    {
        public static async Task<IDistinctEnumerable<string>> EnumerateFilePaths(this IFileSystemOperator @operator, string directoryPath)
        {
            var output = await EnumerableHelper.ProcessSingular(@operator.EnumerateFilePaths, directoryPath);
            return output.AsDistinct();
        }

        public static Task<bool> ExistsFile(this IFileSystemOperator @operator, string filePath)
        {
            return EnumerableHelper.ProcessSingular(@operator.ExistsFiles, filePath);
        }

        public static async Task<IDictionary<TKey, bool>> ExistsFilesByKey<TKey>(this IFileSystemOperator @operator, IDistinctValuedDictionary<TKey, string> filePathsByKey)
        {
            var keysByFilePath = filePathsByKey.Invert();

            var existsByFilePath = await @operator.ExistsFiles(keysByFilePath.Keys.AsDistinct());

            var output = keysByFilePath.Join(existsByFilePath,
                keys => keys.Key,
                exists => exists.Key,
                (keys, exists) => (Key: keys.Value, Exists: exists.Value))
                .ToDictionary(
                    x => x.Key,
                    x => x.Exists);

            return output;
        }

        public static Task<IDictionary<string, string>> ReadContentsByFilePath(this IFileSystemOperator @operator, IDistinctEnumerable<string> filePaths)
        {
            var filePathsByFilePath = filePaths.ToDictionarySameKeyAndValue().AsDistinctValued();

            var contentsByFilePath = @operator.ReadContentsByKey(filePathsByFilePath);
            return contentsByFilePath;
        }

        public static Task<string> ReadContent(this IFileSystemOperator @operator, string filePath)
        {
            return EnumerableHelper.ProcessSingular(@operator.ReadContentsByFilePath, filePath);
        }

        public static Task WriteContent(this IFileSystemOperator @operator, string filePath, string content, bool overwrite = true)
        {
            var writes = DictionaryHelper.From(filePath, content);

            return @operator.WriteContents(writes, overwrite);
        }
    }
}
