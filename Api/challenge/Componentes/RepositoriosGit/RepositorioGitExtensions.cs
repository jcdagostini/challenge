using Take.Challenge.Models;

namespace Take.Challenge.Componentes.RepositoriosGit
{
    public static class RepositorioGitExtensions
    {

        public static Value ToValueAPI(this Api.Models.Response.Item itemGitApi)
        {
            return new Value
            {
                title = itemGitApi.FullName,
                text = itemGitApi.Description,
                type = "image/png",
                uri = itemGitApi.Owner.AvatarUrl,             
            };
        }        
    }
}
