using apitalk.Indexers;
using Umbraco.Core;

namespace apitalk
{
    public class Startup : IApplicationEventHandler
    {
        private static object _lock = new object();
        private static bool _started = false;

        private static ExamineIndexer _examineIndexer;

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (_started)
                return;

            lock (_lock)
            {
                if (!_started)
                {
                    _started = true;

                    _examineIndexer = new ExamineIndexer(); //Register events for examine
                }
            }
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}
