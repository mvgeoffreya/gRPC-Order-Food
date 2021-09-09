package server

import (
	"context"
	pb "food/foodController"
	ty "food/common"

	"github.com/hashicorp/go-hclog"
)

type server struct {
	log hclog.Logger
}

func NewServer(l hclog.Logger) *server {
	return &server{l}
}

func (s *server) GetFood(ctx context.Context, in *pb.FoodRequest) (*pb.FoodResponse, error) {
	s.log.Info("Handle request for GetRate", "base", in.Cuisine)
	userid := in.Userid
	cuisine := in.Cuisine
	Food := ty.Food{}
	Food.Cuisine = cuisine
	Food.Name = "cuisine"
	Food.Rating = 3.4
	Food.Description = userid
	return &pb.FoodResponse{Food: &Food}, nil
}
