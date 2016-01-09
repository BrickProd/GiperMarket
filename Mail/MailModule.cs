using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace Mail
{
    public class MailModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public MailModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            //regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.HelloWorldView));
        }
    }
}
