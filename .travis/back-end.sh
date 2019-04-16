#!/bin/bash

dotnet --info
dotnet restore
dotnet build
dotnet test uit.hotel.test