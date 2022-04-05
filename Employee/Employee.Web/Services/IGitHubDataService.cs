using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Web.Services
{
    public interface IGitHubDataService
    {
        Task<List<GitHubItem>> GetGitHubRepos();
    }
}