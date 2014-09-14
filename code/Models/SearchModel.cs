using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace apitalk.Models
{
    public class SearchModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teaser")]
        public string Teaser { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonIgnore]
        public bool HideInNavigation { get; set; }

        public static SearchModel GetFromContent(IPublishedContent a)
        {
            return new SearchModel
            {
                Id = a.Id,
                Name = a.Name,
                Teaser = a.GetPropertyValue<string>("subheader"),
                Url = a.Url,
                Created = a.CreateDate,
                Updated = a.UpdateDate,
                HideInNavigation = a.GetPropertyValue<bool>("umbracoNaviHide"),
            };
        }
    }
}
