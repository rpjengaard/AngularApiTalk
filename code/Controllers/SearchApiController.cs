using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apitalk.Models;
using Skybrud.WebApi.Json;
using Skybrud.WebApi.Json.Meta;
using Umbraco.Web.WebApi;

namespace apitalk.Controllers
{
    [JsonOnlyConfiguration]
    public class SearchApiController : UmbracoApiController
    {
        [System.Web.Http.HttpGet]
        public object Search(string keywords, int offset = 0, int limit = 10)
        {
            var r = apitalk.Search.SearchDocuments(keywords, new string[] { "umbNewsItem", "umbTextPage" });

            return JsonMetaResponse.GetSuccessFromIEnumerable(r, SearchModel.GetFromContent, limit: limit);
        }
    }
}
