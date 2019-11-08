### Testing in this solution

1. Solution contains
    1. MagentoSoap.Client - client for non WS-I compliant Magento SOAP API
    1. MagentoSoap.Client.WSICompliant - client for WS-I compliant Magento SOAP API
    1. MagentoSoap.TestApp - console app tp test API clients
1. Add reference to test app according to your API - either to (i) or (ii) from above. By default 
(i) is referenced, assuming non WS-I compliant API. Generated clients code left untouched which 
means that all data types are declared in global namespace, thus you can reference only one of above
at a time. Although namespace declaration (or renaming) can be done manually), I'm leaving this out 
of scope as further refactoring depends heavily on exact usage and is not clear for now.
1. Open Program.cs and edit connection data:
    1. ``apiUrl`` - URL to your Magento SOAP API. Basically this is the same URL used to get WSDL, but 
    with any "wsdl" removed. F.e. if WSDL URL is ``http://local.magento/api/v2_soap?wsdl=1``, then 
    API URL is  ``http://magentohost/api/v2_soap``.
    1. ``soapApiUserName`` - name of yours SOAP API user.
    1. ``apiKey`` - API key for the user from above.
1. Build and run program, it will perform search of products by ID and SKU (set by ``testProductId``
and ``testProductSku`` accordingly) and dump some data from the response.


### Set up on a new project  
1. Install following packages from nuget to the target project (whichever is required depending on your case):
    1. System.ServiceModel.Primitives - contains common types
    1. System.ServiceModel.Http, System.ServiceModel.NetTcp - choose for whatever transport you want
    1. System.ServiceModel.Duplex, System.ServiceModel.Security - for duplex connection and additional auth features accordingly.
    1. Primitives package is not needed in target project, as it's used to declare client (it's referenced in
    client projects).
    1. Packages from (ii) and (iii) define how your binding is set up. For basic usage (like with provided 
    solution) Http package is enough (to build HTTP binding and connect).  
1. Add reference to client project/compiled assembly:
    1. MagentoSoap.Client - client for non WS-I compliant Magento SOAP API
    1. MagentoSoap.Client.WSICompliant - client for WS-I compliant Magento SOAP API
