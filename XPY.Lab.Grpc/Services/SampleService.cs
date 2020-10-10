using Grpc.Core;

using System.Threading.Tasks;

using XPY.Lab.Grpc.Protos;

namespace XPY.Lab.Grpc.Services
{
    public class SampleService : Sample.SampleBase
    {
        public override async Task<SampleResponse> Login(SampleRequest request, ServerCallContext context)
        {
            return new SampleResponse()
            {
                Verified = request.Account == "user" && request.Password == "1234"
            };
        }
    }
}