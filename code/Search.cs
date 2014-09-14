using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Examine;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace apitalk
{
    public static class Search
    {
        public static IEnumerable<IPublishedContent> SearchDocuments(string keywords, string[] documentTypes = null)
        {
            List<string> query = new List<string>();

            if (documentTypes.Length != 0)
                query.Add(string.Format("nodeTypeAlias:({0})", string.Join(" ", documentTypes.Select(a => string.Format("\"{0}\"", Lucene.Net.QueryParsers.QueryParser.Escape(a))).ToArray())));

            if (!string.IsNullOrEmpty(keywords))
            {
                keywords = Regex.Replace(keywords, @"[^\wæøåÆØÅ\- ]", "").ToLowerInvariant().Trim();
                var terms = keywords.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string[] fields = new string[] { "nodeName_lci", "subheader_lci", "bodyText_lci" };

                var searchTerms = terms.Select(a => "(" + string.Join(" OR ", fields.Select(b => string.Format("{1}:({0} {0}*)", Lucene.Net.QueryParsers.QueryParser.Escape(a), b)).ToArray()) + ")");

                query.Add(string.Join(" AND ", searchTerms.ToArray()));
            }

            var externalSearcher = ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"];
            var criteria = externalSearcher.CreateSearchCriteria();
            criteria = criteria.RawQuery(string.Join(" AND ", query.ToArray()));

            return externalSearcher.Search(criteria).Select(a => UmbracoContext.Current.ContentCache.GetById(int.Parse(a.Fields["id"])));


        }
    }
}
