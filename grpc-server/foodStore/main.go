package main

import (
	pb "food/foodStore"
	"log"
	"net"

	server "serverFoodStore"

	"github.com/hashicorp/go-hclog"

	"google.golang.org/grpc"
	"google.golang.org/grpc/reflection"
)

const (
	port = ":50052"
)

func main() {
	logs := hclog.Default()
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	c := server.NewServer(logs)
	pb.RegisterFoodStoreServiceServer(s, c)
	reflection.Register(s)

	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to server: %v", err)
	}
}
