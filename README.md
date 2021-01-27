# RepositoryScanner

## Description
This simple console application was written in C# using .NET 5.
It's task is to retrieve commits for a specified user and user's repository.
Next it prints and saves the commits summaries to the SQLite DB.


## Usage

Open a terminal of your choice and go to the path where *RepositoryScanner.csproj* is located.

### Build
```
$ dotnet build 
```
### Run

#### :arrow_forward: using optional command line arguments

```
$ ./bin/Debug/net5.0/RepositoryScanner [gitHubUserName] [gitHubRepositoryName] 
```
example:
```
$ ./bin/Debug/net5.0/RepositoryScanner mmrauta csharp-playground 
```

#### :arrow_forward: without command line arguments

```
$ ./bin/Debug/net5.0/RepositoryScanner
```

OR

```
$ dotnet run 
```
You can also simply start the `RepositoryScanner` Application that can be found in the build folder.

In each case, you will be prompted to enter user name and repository name.

## Tech stack
- Entity Framework Core
- Dependency Injection
- SQLite
- Simple Error Handling
- GitHub API

## Improvement ideas
- Logging
- Configuration files
