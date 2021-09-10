package server

import (
	"context"
	"errors"
	ty "food/common"
	pb "food/userProfile"

	"github.com/hashicorp/go-hclog"
)

type server struct {
	log hclog.Logger
}

func NewServer(l hclog.Logger) *server {
	return &server{l}
}

func (s *server) GetUser(ctx context.Context, in *pb.UserProfileRequest) (*pb.UserProfileResponse, error) {
	s.log.Info("Handle request for GetUser", "base", in)
	userid := in.Userid
	profile := ty.UserProfile{}

	if userid == "1" {
		profile.Username = "Geoffrey"
	} else {
		return nil, errors.New("empty name")
	}
	profile.UserId = userid
	return &pb.UserProfileResponse{Profile: &profile}, nil
}
