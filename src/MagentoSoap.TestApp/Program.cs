using System;
using System.ServiceModel;

namespace MagentoSoap.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // test data
            const string testProductId = "895";
            const string testProductSku = "msj006c-Royal Blue-L";
            
            // change following to yours according to your setup
            const string apiUrl = "http://localhost/api/v2_soap";
            //const string apiUrl = "http://local.magento/api/v2_soap";
            const string soapApiUserName = "soap-api-user";
            const string apiKey = "test123";

            
            // create binding and api address and connect
            var binding = new BasicHttpBinding()
            {
                // increase response size to 1MB, default 64kB is not enough to handle Magento response
                MaxReceivedMessageSize = 1048576
            };

            var address = new EndpointAddress(apiUrl);
            var client = new PortTypeClient(binding, address);

            // login api user
            var sessionId = client.login(soapApiUserName, apiKey);

            // fetch data from API
            Console.WriteLine();
            Console.WriteLine($" ===== Performing search by product ID = {testProductId} ===== ");
            var result1 = client.catalogProductInfo(sessionId, testProductId, null, new catalogProductRequestAttributes(),
                null);
            DumpProductData(result1);

            Console.WriteLine();
            Console.WriteLine($" ===== Performing search by product SKU = {testProductSku} ===== ");
            var result2 = client.catalogProductInfo(sessionId, testProductSku, null, new catalogProductRequestAttributes(),
                null);
            DumpProductData(result2);
        }

        private static void DumpProductData(catalogProductReturnEntity result)
        {
            Console.WriteLine($"Dumping data for product {result.product_id}:");
            Console.WriteLine($"\tSKU\t\t:\t{result.sku}");
            Console.WriteLine($"\tName\t\t:\t{result.name}");
            Console.WriteLine($"\tDescription\t:\t{result.description}");
            Console.WriteLine($"\tCategories\t:\t{string.Join(",", result.categories)}");
            Console.WriteLine($"\tPrice\t\t:\t{result.price}");
            Console.WriteLine($"\tStatus\t\t:\t{result.status}");
            Console.WriteLine($"\tURL\t\t:\t{result.url_path}");
        }
    }
}