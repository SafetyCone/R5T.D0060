using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0060
{
    [ServiceDefinitionMarker]
    public interface ICurrentDirectoryPathProvider : IServiceDefinition
    {
        Task<string> GetCurrentDirectoryPath();
    }
}
