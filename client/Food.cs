using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Grpc.Core;
using FoodCommon;
using UserProfile;
using FoodStore;
namespace client
{
  public class Response
  {
    public object UserProfile { get; set; }
    public object Store { get; set; }
  }
  public class Food
  {
    public static async Task<string> getFood(String Userid)
    {
      var channelUserProfile = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

      var clientUserProfile = new UserProfileService.UserProfileServiceClient(channelUserProfile);
      var channelFoodStore = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
      var clientFoodStore = new FoodStoreService.FoodStoreServiceClient(channelFoodStore);
      var Cuisine = new FoodCommon.Cuisine();
      Response res = new Response();
      try {
        var responseUserProfile = clientUserProfile.getUser(new UserProfileRequest
        {
          Userid = Userid,
        });
        res.UserProfile = responseUserProfile;
      }
      catch { }
      try {
        var responseFoodStore = clientFoodStore.getFoodStore(new FoodStoreRequest
        {
          Cuisine = Cuisine.Vietnamese
        });
        while (await responseFoodStore.ResponseStream.MoveNext())
        {
          res.Store = responseFoodStore.ResponseStream.Current.Food;
        }
      }
      catch { }
      Console.WriteLine("UserProfile: " + res.UserProfile);
      Console.WriteLine("Store: " + res.Store);
      var options = new JsonSerializerOptions { WriteIndented = true };
      string jsonString = JsonSerializer.Serialize(res, options);
      return jsonString;
    }
  }
}
`