using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Take.Challenge.Api.Models.Response;

namespace Take.Challenge.Api
{
    public class RepositoriosGitApi : BaseClienteApi
    {        
        public const string ROTA = "search/repositories?q=language:c%23+user:takenet";

        public RepositoriosGitApi() : base(new URLBase().URLBaseGitApi) { }

        public async Task<RepositorioGitApiModel> GetRepositoriosGit()
        {  
            return await this.Get<RepositorioGitApiModel>(await MontarUrl());
        }

        private async Task<Uri> MontarUrl()
        {
            return await Task.Run(() =>
            {
                var param = new Dictionary<string, string>() { { "sort", "created" },
                                                           { "direction", "asc" },
                                                           { "per_page", "5" },
                                                           { "page", "1" } };

                var url = new Uri(QueryHelpers.AddQueryString(string.Concat(base.UrlBase, ROTA), param));

                return url;
            });
        }        

    }
}
