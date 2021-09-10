using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using FoodCommon;
using UserProfile;
using FoodStore;

namespace csharp.client
{
    internal class Program
    {
       static async Task Main(string[] args)
        {
            var channelUserProfile = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var clientUserProfile = new UserProfileService.UserProfileServiceClient(channelUserProfile);
            var channelFoodStore = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
            var clientFoodStore = new FoodStoreService.FoodStoreServiceClient(channelFoodStore);
            var Cuisine = new FoodCommon.Cuisine();

            var responseUserProfile = clientUserProfile.getUser(new UserProfileRequest
            {
                Userid = "2",
            });
            var responseFoodStore = clientFoodStore.getFoodStore(new FoodStoreRequest
            {
                Cuisine = Cuisine.Vietnamese
            });
            while (await responseFoodStore.ResponseStream.MoveNext())
            {
                Console.WriteLine("FoodStore: " + responseFoodStore.ResponseStream.Current.Food);
            }
            Console.WriteLine("UserProfile: " + responseUserProfile);
            channelUserProfile.ShutdownAsync().Wait();
            channelFoodStore.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}