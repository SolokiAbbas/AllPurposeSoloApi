using AllPurpose.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AllPurpose.Logic
{
    public class GraphQLClient: Models.IGraphQLClient
    {
        private GraphQLHttpClient Client { get; }
        private AllPurpOptions Options { get; }
        public GraphQLClient(IOptions<AllPurpOptions> options)
        {
            Options = options.Value;
            Client = new GraphQLHttpClient(Options.AnimeListGQL, new NewtonsoftJsonSerializer());
        }

        public async Task<string> SendRequest(string reqQuery, string variables)
        {
            var queryBuilder = new GraphQLRequest
            {
                Query = reqQuery,
                Variables = variables
            };
            var resp = await Client.SendQueryAsync<object>(queryBuilder);        
            return resp.Data.ToString();
        }

    }
}
