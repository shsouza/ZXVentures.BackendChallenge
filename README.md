# Pré Requisitos:

Instalação (baseado na versão Ubuntu 18.04)

1. Instalar o .NET Core SDK:

wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo add-apt-repository universe
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-2.2

referencia [https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-2.2.300](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-2.2.300)

2. Mongo DB

sudo apt update
sudo apt install -y mongodb

# Deploy

dotnet ZXVentures.BackendChallenge/ZXVenture.BackendChallenge.Api/bin/Debug/netcoreapp2.1/ZXVenture.BackendChallenge.Api.dll

# Testes

dotnet test

# Api

GET http://localhost:5000/api/pdv?id=9c6ebc6f-307c-4cb4-b272-dee0ed4e8b27

GET http://localhost:5000/api/pdv/search?x=-46.65893554687499&y=-23.54384513650583

POST http://localhost:5000/api/pdv

{
	
	"code" : "123",
	"tradingName" : "Important Company",
	"document" : "123444/5550",
	"owner": "my-self",
	"coverageArea": {
        "type": "MultiPolygon",
        "coordinates": [
            [
                [
                    [
                        -46.944580078125,
                        -23.51362636346272
                    ],
                    [
                        -46.8841552734375,
                        -23.74009762440226
                    ],
                    [
                        -46.4996337890625,
                        -23.810475327766568
                    ],
                    [
                        -46.219482421875,
                        -23.553916518321611
                    ],
                    [
                        -46.593017578124993,
                        -23.301901124188877
                    ],
                    [
                        -46.944580078125,
                        -23.51362636346272
                    ]
                ]
            ]
        ]
    },
    "address": {
        "type": "Point",
        "coordinates": [
            0,
            0
        ]
    }
}

