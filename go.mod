module food.com

go 1.16

require (
	food v1.2.3
	github.com/hashicorp/go-hclog v0.16.2
	golang.org/x/net v0.0.0-20210907225631-ff17edfbf26d // indirect
	golang.org/x/sys v0.0.0-20210906170528-6f6e22806c34 // indirect
	golang.org/x/text v0.3.7 // indirect
	google.golang.org/genproto v0.0.0-20210903162649-d08c68adba83 // indirect
	google.golang.org/grpc v1.40.0
	serverFoodStore v1.2.3
	serverUserProfile v1.2.3
)

replace (
	food v1.2.3 => ./proto/food/
	serverFoodStore v1.2.3 => ./grpc-server/foodStore/server
	serverUserProfile v1.2.3 => ./grpc-server/userProfile/server
)
