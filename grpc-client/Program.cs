using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using FoodCommon;
using FoodController;
using FoodStore;
using Recommender;
using UserPreferences;

namespace csharp.client
{
    internal class Program
    {
       static async Task Main(string[] args)
        {
            var channelFoodController = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var clientFoodController = new FoodControllerService.FoodControllerServiceClient(channelFoodController);
            var channelFoodStore = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
            var clientFoodStore = new FoodStoreService.FoodStoreServiceClient(channelFoodStore);
            var Cuisine = new FoodCommon.Cuisine();

            var responseFoodController = clientFoodController.getFood(new FoodRequest
            {
                Userid = "Geoffrey",
                Cuisine = Cuisine.Vietnamese
            });
            var responseFoodStore = clientFoodStore.getFoods(new FoodStoreRequest
            {
                Cuisine = Cuisine.Vietnamese
            });
            while (await responseFoodStore.ResponseStream.MoveNext())
            {
                Console.WriteLine("Greeting: " + responseFoodStore.ResponseStream.Current.Food);
            }
            channelFoodController.ShutdownAsync().Wait();
            channelFoodStore.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}