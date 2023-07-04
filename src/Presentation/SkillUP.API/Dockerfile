FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ARG dbhost
ARG dbport
ARG dbname
ARG dbuser
ARG dbpassword

ARG runenv

ENV DBHOST=$dbhost
ENV DBPORT=$dbport
ENV DBNAME=$dbname
ENV DBUSER=$dbuser
ENV DBPASSWORD=$dbpassword

ENV ASPNETCORE_ENVIRONMENT=$runenv

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /project
COPY ["src/", "src"]

RUN dotnet restore "src/Presentation/SkillUP.API/SkillUP.API.csproj"

COPY . .

WORKDIR "/project/src/Presentation/SkillUP.API"

RUN dotnet build "SkillUP.API.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "SkillUP.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SkillUP.API.dll"]
