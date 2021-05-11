using System;
using System.Threading.Tasks;


namespace R5T.D0060
{
    public interface ICurrentDirectoryPathProvider
    {
        Task<string> GetCurrentDirectoryPath();
    }
}
