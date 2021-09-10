package server

import (
	ty "food/common"
	pb "food/foodStore"

	"github.com/hashicorp/go-hclog"
)

type server struct {
	log hclog.Logger
}

func NewServer(l hclog.Logger) *server {
	return &server{l}
}

func (s *server) GetFoodStore(in *pb.FoodStoreRequest, stream pb.FoodStoreService_GetFoodStoreServer) error {
	s.log.Info("Handle request for GetFoodStore", "base", in)
	Food := ty.Food{}
	Food.Cuisine = in.Cuisine
	Food.Name = "capcay"
	Food.Rating = 3.4
	Food.Description = in.Cuisine.String()
	res := &pb.FoodStoreResponse{
		Food: &Food,
	}
	stream.Send(res)

	return nil
}
