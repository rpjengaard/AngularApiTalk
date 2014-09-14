using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using apitalk.Models;
using Skybrud.WebApi.Json;
using Skybrud.WebApi.Json.Meta;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace apitalk.Controllers
{
    [JsonOnlyConfiguration]
    public class NewsApiController : UmbracoApiController
    {

        private UmbracoHelper _helper = new UmbracoHelper(UmbracoContext.Current);


        public object GetNews(int id)
        {
            var c = _helper.TypedContent(id);

            if (c == null)
            {
                return Request.CreateResponse(JsonMetaResponse.GetError(HttpStatusCode.NotFound, "Nyhedsartiklen blev ikke fundet", c));

            }

            return Request.CreateResponse(JsonMetaResponse.GetSuccessFromObject(c, NewsModel.GetFromContent));
        }

        [System.Web.Http.HttpGet]
        public object Search(string keywords = "", int offset = 0, int limit = 10)
        {
            IEnumerable<IPublishedContent> results = Enumerable.Empty<IPublishedContent>();

            try
            {
                results = apitalk.Search.SearchDocuments(keywords, new string[] { "umbNewsItem" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(JsonMetaResponse.GetError(HttpStatusCode.InternalServerError, "Der skete en fejl på serveren"));
            }

            return Request.CreateResponse(JsonMetaResponse.GetSuccessFromIEnumerable(results, NewsModel.GetFromContent, offset, limit));
        }

                
    }
}
