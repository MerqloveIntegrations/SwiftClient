using Microsoft.Extensions.Options;
using System.Net.Http;

namespace SwiftClient.AspNetCore
{
    public class SwiftService : Client
    {
        private readonly SwiftServiceOptions _options;

        public SwiftService(IOptions<SwiftServiceOptions> options,
            ISwiftAuthManager authManager,
            IHttpClientFactory httpClientFactory,
            ISwiftLogger logger): base(authManager, logger)
        {
            _options = options.Value;
            SetRetryCount(_options.RetryCount);
            SetHttpClient(httpClientFactory, _options.NoHttpDispose);
            SetRetryPerEndpointCount(_options.RetryPerEndpointCount);
        }
    }
}
