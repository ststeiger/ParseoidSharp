
namespace libParsoidSharp
{


    // node-version: v8.6.0
    // npm install 
    public class MediaWikiConverter
    {
        protected Microsoft.Extensions.DependencyInjection.ServiceCollection m_services;
        protected System.IServiceProvider m_serviceProvider;
        protected Microsoft.AspNetCore.NodeServices.INodeServices m_nodeServices;


        private static string GetDefaultPath()
        {
            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory;
            projectPath = System.IO.Path.Combine(projectPath, "..", "..", "..");
            projectPath = System.IO.Path.GetFullPath(projectPath);
            return projectPath;
        }

        
        public MediaWikiConverter() :this(GetDefaultPath())
        { }


        public MediaWikiConverter(string path)
        {
            InitInstance(path);
        }
        

        protected void InitInstance(string path)
        {
            this.m_services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            Microsoft.Extensions.DependencyInjection.NodeServicesServiceCollectionExtensions
                .AddNodeServices(this.m_services, options =>
                {
                    options.ProjectPath = path;
                });

            this.m_serviceProvider = Microsoft.Extensions.DependencyInjection
                .ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(this.m_services);

            this.m_nodeServices = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions
                .GetRequiredService<Microsoft.AspNetCore.NodeServices.INodeServices>(this.m_serviceProvider);
        }


        public string ToHtml(string moduleName, string markup)
        {
            return this.m_nodeServices.InvokeAsync<string>(moduleName, markup).Result;
        }


        public async System.Threading.Tasks.Task<string> ToHtmlAsync(string moduleName, string markup)
        {
            return await this.m_nodeServices.InvokeAsync<string>(moduleName, markup);
        }


    }


}
