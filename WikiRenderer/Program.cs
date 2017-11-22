
// using Microsoft.Extensions.DependencyInjection;


namespace WikiRenderer
{


    class Program
    {

        private static Microsoft.AspNetCore.NodeServices.INodeServices 
            CreateNonSharedInstance(System.IServiceProvider isp)
        {
            var options = new Microsoft.AspNetCore.NodeServices.NodeServicesOptions(isp)
            { 
                /* Assign/override any other options here */
            };

            options.ProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
            options.ProjectPath = System.IO.Path.Combine(options.ProjectPath, "..", "..", "..");
            options.ProjectPath = System.IO.Path.GetFullPath(options.ProjectPath);
            
            var nodeServices = Microsoft.AspNetCore.NodeServices.NodeServicesFactory.CreateNodeServices(options);
            return nodeServices;
        } // End Sub CreateNonSharedInstance 

        public async System.Threading.Tasks.Task<string> GetParsedWikiText(Microsoft.AspNetCore.NodeServices.INodeServices nodeServices)
        {
            return await nodeServices.InvokeAsync<string>("./Node/parsee");
        }


        static void TestOneInstance()
        {
            Microsoft.Extensions.DependencyInjection.ServiceCollection services = 
                new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            // services.AddNodeServices(options => {
            // // Set any properties that you want on 'options' here
            //});

            Microsoft.Extensions.DependencyInjection.NodeServicesServiceCollectionExtensions
                .AddNodeServices(services, options =>
                {
                    options.ProjectPath = System.AppDomain.CurrentDomain.BaseDirectory;
                    options.ProjectPath = System.IO.Path.Combine(options.ProjectPath, "..", "..", "..");
                    options.ProjectPath = System.IO.Path.GetFullPath(options.ProjectPath);
                    System.Console.WriteLine(options.ProjectPath);
                });
            
            // Microsoft.Extensions.DependencyInjection.ServiceProvider serviceProvider = 
            //    services.BuildServiceProvider();

            System.IServiceProvider serviceProvider = Microsoft.Extensions.DependencyInjection
                .ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);

            // var nodeServices = serviceProvider.GetRequiredService<INodeServices>();
            Microsoft.AspNetCore.NodeServices.INodeServices nodeServices = Microsoft.Extensions
                .DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService
                <Microsoft.AspNetCore.NodeServices.INodeServices>(serviceProvider);

            // createNonShared(serviceProvider);

            // node-version: v8.6.0
            // npm install 
            string mediaWiki = "== Getting started ==\n<code>maps.wikimedia.org</code>\u00A0serves standard\u00A0[[:en:Web Mercator|Web Mercator]]\u00A0raster tiles so it should be a drop-in replacement for other tileservers serving\u00A0[https://www.openstreetmap.org/ OpenStreetMap-based]\u00A0imagery. To point a tool to our mapserver, use the following URL schema:\n* '''<nowiki>https://maps.wikimedia.org/{style}/{z}/{x}/{y}.{format}</nowiki>'''\n* '''<nowiki>https://maps.wikimedia.org/{style}/{z}/{x}/{y}@{scale}x.</nowiki>''{format}'''''\u00A0- with the optional scaling factor\n{| class=\"wikitable\"\n|+URL parameters\n|'''style'''\n|Map style to use. Use\u00A0'''\"osm-intl\"'''\u00A0for map with labels,\u00A0'''\"osm\"'''\u00A0for map without labels.\n|-\n|'''z'''\n|zoom level, 0-18\n|-\n|'''x, y'''\n|Web Mercator grid coordinates\n|-\n|'''scale'''\n|Optional scale for the high-resolution screens such as\u00A0[[:en:Retina Display|Retina]]. Supported scales are 1.3, 1.5, 2, 2.6, 3\n|-\n|'''format'''\n|Use\u00A0'''\"png\"'''\u00A0for now, but you can also use\u00A0'''\"pbf\"'''\u00A0from the\u00A0'''/osm'''\u00A0style to get the raw vector tiles.\n|}\nAdding a maps within\u00A0[http://leafletjs.com/ Leaflet]\u00A0is as easy as<syntaxhighlight lang=\"javascript\">\nvar style = 'osm-intl';\nvar server = 'https://maps.wikimedia.org/';\n\n// Create a map\nvar map = L.map('map').setView([40.75, -73.96], 4);\n\n// Add a map layer\nL.tileLayer(server + style + '/{z}/{x}/{y}.png', {\n    maxZoom: 18,\n    id: 'wikipedia-map-01',\n    attribution: 'Wikimedia maps beta | Map data &copy; <a href=\"http://openstreetmap.org/copyright\">OpenStreetMap contributors</a>'\n}).addTo(map);\n</syntaxhighlight>An example of a map that uses our tiles is at\u00A0\u00A0[http://maps.beta.wmflabs.org/ maps.beta.wmflabs.org],\u00A0[https://github.com/MaxSem/maps-demo source].\n\n=== Static map images ===\nMaps are also capable of serving static images, such as\u00A0https://maps.wikimedia.org/img/osm-intl,7,43.66,4.719,800x600.png\n\nURL:\u00A0\u00A0'''<nowiki>https://maps.wikimedia.org/img/{style},{z},{lat},{lon},{width}x{height}@{scale}x.png</nowiki>'''\n{| class=\"wikitable\"\n|+URL parameters\n|'''style'''\n|Map style to use. Use\u00A0'''\"osm-intl\"'''\u00A0for map with labels,\u00A0'''\"osm\"'''\u00A0for map without labels.\n|-\n|'''z'''\n|Zoom level, 0\u201318\n|-\n|'''lat, lon'''\n|Latitude and longitude of the map center\n|-\n|'''width, height'''\n|Image size in pixels without scalling\n|-\n|'''scale'''\n|Optional scale for the high-resolution screens such as\u00A0[[:en:Retina Display|Retina]]. Supported scales are 1.3, 1.5, 2, 2.6, 3\n|}\n\n== See Also ==\n* [[Maps/Tile server implementation|Tile server implementation]] - technical details on how the server presenting and storing the map tiles is implemented\n";
            string html = nodeServices.InvokeAsync<string>("./NodeScripts/parsee", mediaWiki).Result;
            System.Console.WriteLine(html);

            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        } // End Sub TestOneInstance 


        static void Main(string[] args)
        {
            string mediaWiki = "== Getting started ==\n<code>maps.wikimedia.org</code>\u00A0serves standard\u00A0[[:en:Web Mercator|Web Mercator]]\u00A0raster tiles so it should be a drop-in replacement for other tileservers serving\u00A0[https://www.openstreetmap.org/ OpenStreetMap-based]\u00A0imagery. To point a tool to our mapserver, use the following URL schema:\n* '''<nowiki>https://maps.wikimedia.org/{style}/{z}/{x}/{y}.{format}</nowiki>'''\n* '''<nowiki>https://maps.wikimedia.org/{style}/{z}/{x}/{y}@{scale}x.</nowiki>''{format}'''''\u00A0- with the optional scaling factor\n{| class=\"wikitable\"\n|+URL parameters\n|'''style'''\n|Map style to use. Use\u00A0'''\"osm-intl\"'''\u00A0for map with labels,\u00A0'''\"osm\"'''\u00A0for map without labels.\n|-\n|'''z'''\n|zoom level, 0-18\n|-\n|'''x, y'''\n|Web Mercator grid coordinates\n|-\n|'''scale'''\n|Optional scale for the high-resolution screens such as\u00A0[[:en:Retina Display|Retina]]. Supported scales are 1.3, 1.5, 2, 2.6, 3\n|-\n|'''format'''\n|Use\u00A0'''\"png\"'''\u00A0for now, but you can also use\u00A0'''\"pbf\"'''\u00A0from the\u00A0'''/osm'''\u00A0style to get the raw vector tiles.\n|}\nAdding a maps within\u00A0[http://leafletjs.com/ Leaflet]\u00A0is as easy as<syntaxhighlight lang=\"javascript\">\nvar style = 'osm-intl';\nvar server = 'https://maps.wikimedia.org/';\n\n// Create a map\nvar map = L.map('map').setView([40.75, -73.96], 4);\n\n// Add a map layer\nL.tileLayer(server + style + '/{z}/{x}/{y}.png', {\n    maxZoom: 18,\n    id: 'wikipedia-map-01',\n    attribution: 'Wikimedia maps beta | Map data &copy; <a href=\"http://openstreetmap.org/copyright\">OpenStreetMap contributors</a>'\n}).addTo(map);\n</syntaxhighlight>An example of a map that uses our tiles is at\u00A0\u00A0[http://maps.beta.wmflabs.org/ maps.beta.wmflabs.org],\u00A0[https://github.com/MaxSem/maps-demo source].\n\n=== Static map images ===\nMaps are also capable of serving static images, such as\u00A0https://maps.wikimedia.org/img/osm-intl,7,43.66,4.719,800x600.png\n\nURL:\u00A0\u00A0'''<nowiki>https://maps.wikimedia.org/img/{style},{z},{lat},{lon},{width}x{height}@{scale}x.png</nowiki>'''\n{| class=\"wikitable\"\n|+URL parameters\n|'''style'''\n|Map style to use. Use\u00A0'''\"osm-intl\"'''\u00A0for map with labels,\u00A0'''\"osm\"'''\u00A0for map without labels.\n|-\n|'''z'''\n|Zoom level, 0\u201318\n|-\n|'''lat, lon'''\n|Latitude and longitude of the map center\n|-\n|'''width, height'''\n|Image size in pixels without scalling\n|-\n|'''scale'''\n|Optional scale for the high-resolution screens such as\u00A0[[:en:Retina Display|Retina]]. Supported scales are 1.3, 1.5, 2, 2.6, 3\n|}\n\n== See Also ==\n* [[Maps/Tile server implementation|Tile server implementation]] - technical details on how the server presenting and storing the map tiles is implemented\n";

            libParsoidSharp.MediaWikiConverter converter = new libParsoidSharp.MediaWikiConverter();
            string html = converter.ToHtml("./NodeScripts/parsee", mediaWiki);
            System.Console.WriteLine(html);

            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        } // End Sub Main 


    } // End Class Program 


} // End Namespace WikiRenderer 
