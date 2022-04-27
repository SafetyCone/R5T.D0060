using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0060
{
    [ServiceImplementationMarker]
    public class CurrentDirectoryPathProvider : ICurrentDirectoryPathProvider, IServiceImplementation
    {
        public Task<string> GetCurrentDirectoryPath()
        {
            var currentDirectoryPath = Environment.CurrentDirectory;
            return Task.FromResult(currentDirectoryPath);
        }
    }
}
