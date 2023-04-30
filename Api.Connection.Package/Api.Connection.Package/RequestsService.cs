using RestSharp;

namespace Api.Connection.Package
{
    public class RequestsService : IRequestsService
    {
        public enum BodyType
        {
            None = 0,
            Json = 1,
            Xml = 2
        };

        public async Task<RestResponse> ExecutRequestAsync(
            string domain,
            string path,
            string body = "",
            Dictionary<string, string>? headers = null,
            Dictionary<string, string>? parameters = null,
            BodyType bodyType = BodyType.None,
            Method method = Method.Get)
        {
            var client = new RestClient(domain);
            var request = new RestRequest(path, method);
            if (headers != null)
                client.AddDefaultHeaders(headers);

            AddParameters(parameters, ref request);

            if (!string.IsNullOrEmpty(body))
                AddBody(bodyType, body, request);

            var response = await client.ExecuteAsync(request);
            return response;
        }

        private void AddParameters(Dictionary<string, string>? parameters, ref RestRequest request)
        {
            if (parameters != null && parameters.Count() > 0)
            {
                foreach (var parameter in parameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
        }

        private void AddBody(BodyType bodyType, string body, RestRequest request)
        {
            if (bodyType == BodyType.Json)
                request.AddStringBody(body, DataFormat.Json);

            else if (bodyType == BodyType.Xml)
                request.AddStringBody(body, DataFormat.Xml);
        }
    }
}