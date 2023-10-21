# MemoryCache Labs

## Overview

Learn Time: Experiments with cache in-Memory.

## Features

 - C#
 - XUnit
 - GitHub Actions
 - [Cache in-memory in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory)

## Requirements

The project requires [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Compatible IDEs

Tested on:

- Visual Studio Code (1.83.11)
- Rider 2023.2.2

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

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
