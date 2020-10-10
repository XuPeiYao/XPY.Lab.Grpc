using Grpc.Net.Client;

using System;
using System.Threading.Tasks;

using XPY.Lab.Grpc.Client.Protos;

using static XPY.Lab.Grpc.Client.Protos.Sample;

namespace XPY.Lab.Grpc.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(1000 * 5); // wait service boot
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Sample.SampleClient(channel);

            var reply = client.Login(
                              new SampleRequest
                              {
                                  Account = "user",
                                  Password = "1234"
                              });
            Console.WriteLine("Login Result: " + reply.Verified);
            Console.ReadKey();
        }
    }
}
