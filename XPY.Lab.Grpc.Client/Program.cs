using Grpc.Core;
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
            await Task.Delay(1000 * 5); // waiting web service startup

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Sample.SampleClient(channel);

            // this metadata object will send to grpc server(USE HTTP HEADERS)
            var meta = new Metadata();
            meta.Add("Authorization", $"FAKE TOKEN");

            // send user login info and metatdata
            var reply = client.Login(
                new SampleRequest
                {
                    Account = "user",
                    Password = "1234"
                },
                meta);

            // show login status
            Console.WriteLine("Login Result: " + reply.Verified);

            // keep console app running
            Console.ReadKey();
        }
    }
}
