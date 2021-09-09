using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using FoodCommon;
using FoodController;
using FoodStore;
using Recommender;
using UserPreferences;
namespace client
{
  public class Food
  {
  public static async Task<Array> getFood(String Userid) 
    {
      var channelFoodController = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
      var clientFoodController = new FoodControllerService.FoodControllerServiceClient(channelFoodController);
      var channelFoodStore = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
      var clientFoodStore = new FoodStoreService.FoodStoreServiceClient(channelFoodStore);
      var Cuisine = new FoodCommon.Cuisine();
      FoodCommon.Food [] res = new  FoodCommon.Food[2];
      var responseFoodController = clientFoodController.getFood(new FoodRequest
      {
        Userid = Userid,
        Cuisine = Cuisine.Vietnamese
      });
      var responseFoodStore = clientFoodStore.getFoods(new FoodStoreRequest
      {
        Cuisine = Cuisine.Vietnamese
      });
      while (await responseFoodStore.ResponseStream.MoveNext())
      {
        Console.WriteLine("Greeting: " + responseFoodStore.ResponseStream.Current.Food);
        res[1] = responseFoodStore.ResponseStream.Current.Food;
      }
      res[0] = responseFoodController.Food;
      return res;
    }
  }
}
