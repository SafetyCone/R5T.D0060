using System;
using System.Threading.Tasks;


namespace R5T.D0060
{
    public class CurrentDirectoryPathProvider : ICurrentDirectoryPathProvider
    {
        public Task<string> GetCurrentDirectoryPath()
        {
            var currentDirectoryPath = Environment.CurrentDirectory;
            return Task.FromResult(currentDirectoryPath);
        }
    }
}
