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

func (s *server) GetFoods(in *pb.FoodStoreRequest, stream pb.FoodStoreService_GetFoodsServer) error {
	s.log.Info("Handle request for GetFoods", "base", in)
	Food := ty.Food{}
	Food.Cuisine = in.Cuisine
	Food.Name = "cuisin11e"
	Food.Rating = 3.4
	Food.Description = "userid"
	res := &pb.FoodStoreResponse{
		Food: &Food,
	}
	stream.Send(res)

	return nil
}
