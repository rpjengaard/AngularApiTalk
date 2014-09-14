using System.Collections.Generic;
using System.Linq;
using Examine;

namespace apitalk.Indexers
{
    class ExamineIndexer
    {
        public ExamineIndexer()
        {
            var externalIndexer = ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"];
            var memberIndexer = ExamineManager.Instance.IndexProviderCollection["InternalMemberIndexer"];

            externalIndexer.GatheringNodeData += externalIndexer_GatheringNodeData;
            memberIndexer.GatheringNodeData += memberIndexer_GatheringNodeData;

        }


        void externalIndexer_GatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            //Bruges til at lave custom handlinger til et Examine index. I dette tilfælde "ExternalIndexer"

            //Eksempel: laver LowerCaseIndex af felterne
            var lcifields = e.Fields.Where(a => !a.Key.EndsWith("_lci"));

            Dictionary<string, string> lci = new Dictionary<string, string>();

            foreach (var field in lcifields)
            {
                lci[field.Key + "_lci"] = field.Value.ToLowerInvariant();
            }

            foreach (var field in lci)
                e.Fields[field.Key] = field.Value;

        }

        void memberIndexer_GatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            //Bruges til at lave custom handlinger til et Examine index. I dette tilfælde "InternalMemberIndexer"
        }
    }
}
