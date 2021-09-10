# gRPC-Order-Food
Create Simple gRPC Application to Order Food

Status: on Development

## Install

1. When Create Proto for Go
```bash
export GO_PATH=~/go   

export PATH=$PATH:/$GO_PATH/bin

protoc --proto_path=./proto --go_out=plugins=grpc:proto ./proto/common.proto

protoc --proto_path=./proto --go_out=plugins=grpc:proto ./proto/userProfile.proto 

protoc --proto_path=./proto --go_out=plugins=grpc:proto ./proto/foodStore.proto       

```

2. Get Go dependency 
```bash
go mod tidy
```


