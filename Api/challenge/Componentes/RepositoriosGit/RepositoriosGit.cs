using System.Threading.Tasks;
using Take.Challenge.Api;
using Take.Challenge.Models;

namespace Take.Challenge.Componentes.RepositoriosGit
{
    public class RepositoriosGit
    {        
        public async Task<RetornoApiModel> GetRepositoriosGitApi() 
        {
            var retornoApiGit = await new RepositoriosGitApi().GetRepositoriosGit();

            RetornoApiModel objetoRetorno = new RetornoApiModel();
            objetoRetorno.itemType = "application/vnd.lime.document-select+json";
            
            foreach (var item in retornoApiGit.Items)
            {
                objetoRetorno.items.Add(await MontarItem(item));
            }

            return objetoRetorno;           
        }


        private async Task<Item> MontarItem(Api.Models.Response.Item itemGitApi)
        {
            return await Task.Run(() =>
            {
                var item = new Item();
                item.header = MontarHeader(itemGitApi).Result;
                return item;
            });
        }

        private async Task<Header> MontarHeader(Api.Models.Response.Item itemGitApi)
        {
            return await Task.Run(() =>
            {
                var Header = new Header();
                Header.type = "application/vnd.lime.media-link+json";
                Header.value = MontarValue(itemGitApi).Result;

                return Header;
            });
        }

        private async Task<Value> MontarValue(Api.Models.Response.Item itemGitApi)
        {
            return await Task.Run(() =>
            {
                return itemGitApi.ToValueAPI();
            });
        }
    }
}
