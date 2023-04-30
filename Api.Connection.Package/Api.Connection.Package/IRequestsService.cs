using RestSharp;

namespace Api.Connection.Package
{
    public interface IRequestsService
    {
        Task<RestResponse> ExecutRequestAsync(string domain, string path, string body = "", Dictionary<string, string>? headers = null, Dictionary<string, string>? parameters = null, RequestsService.BodyType bodyType = RequestsService.BodyType.None, Method method = Method.Get);
    }
}