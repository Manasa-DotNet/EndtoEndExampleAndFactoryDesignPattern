using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Web.Controllers
{
    public class GitHubController : Controller
    {
        // GET: GitHubController
        private readonly IGitHubDataService gitHubDataService;
        public GitHubController(IGitHubDataService gitHubDataService)
        {
            this.gitHubDataService = gitHubDataService;
        }
        public async Task<ActionResult> Index()
        {
            var result = await gitHubDataService.GetGitHubRepos();
            return View(result);
        }


    }
}
