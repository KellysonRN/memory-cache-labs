# MemoryCache Labs

## Overview

Learn Time: Experiments with cache in-Memory.

## Context 

<div style="text-align: justify">
The main goal of this experiment is to demonstrate how using in-memory caching 
can improve performance and efficiency when loading a list of board games. The experiment 
will fetch data from an external data source consisting of a list of board games, 
including information such as game id, name and Ludopedia link. By implementing an in-memory 
caching system, my intention is to speed up access to this data, minimizing query time and 
increasing API responsiveness.
</div>
  
## Key Features

 - C#
 - XUnit
 - Integration with an external data source
 - [Cache in-memory in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory)
 - [User-Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows)
 - [HttpClient Factory](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-7.0)
 - [Ludopedia API Docs] (https://ludopedia.com.br/api/documentacao.html)

## Next steps

 - Increase test code coverage

## Requirements

The project requires [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Compatible IDEs

Tested on:

- Rider 2023.2.2

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

- Enable User-Secrets

```shell

# From the MemoryCache.Labs.API root

dotnet user-secrets init

# To generate a secret read the ludopedia API docs above.
dotnet user-secrets set "LUDOPEDIA_SECRET" "xyz@123#456"

```

- ### Build the project

```shell
dotnet build
```

- ### Run the tests

```shell
# Note: During my experiments ( March, 2023 ) the .NET7 had issues to execute this command.
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

### Code Coverage report

```shell
# Install the ReportGenerator
dotnet tool install -g dotnet-reportgenerator-globaltool
```

```shell
# Generate reports
reportgenerator -reports:"**/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```
