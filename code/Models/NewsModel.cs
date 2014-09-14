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
    public class NewsModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("subheader")]
        public string SubHeader { get; set; }

        [JsonProperty("content")]
        public String Content { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonIgnore]
        public bool HideInNavigation { get; set; }


        public static NewsModel GetFromContent(IPublishedContent a)
        {
            return new NewsModel
            {
                Id = a.Id,
                Name = a.Name,
                SubHeader = a.GetPropertyValue<string>("subheader"),
                Content = a.GetPropertyValue<string>("bodyText"),
                Created = a.CreateDate,
                Updated = a.UpdateDate,
                HideInNavigation = a.GetPropertyValue<bool>("umbracoNaviHide"),
                ImageUrl = a.GetPropertyValue<string>("image"),
                PublishDate = a.GetPropertyValue<DateTime>("publishDate")
            };
        }
                     
    }
}
