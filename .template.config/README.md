# ScreamingCqrs

An architecture based on Screaming principles associated to CQRS, hexagonal and Vertical Slice principles.

# Template management

## By CLI

### Install

See: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-install

```
dotnet new install <PATH|NUGET_ID>  [--interactive] [--add-source|--nuget-source <SOURCE>] [--force] 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

For example:

```
dotnet new install . --force
```

### Use

See: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new

```
dotnet new <TEMPLATE> [--dry-run] [--force] [-lang|--language {"C#"|"F#"|VB}]
    [-n|--name <OUTPUT_NAME>] [-f|--framework <FRAMEWORK>] [--no-update-check]
    [-o|--output <OUTPUT_DIRECTORY>] [--project <PROJECT_PATH>]
    [-d|--diagnostics] [--verbosity <LEVEL>] [Template options]
```

```
dotnet new -h|--help
```

For example:

```
dotnet new scqrs -n MyFeature -c MyCompany
```

### Uninstall

See: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-uninstall

```
dotnet new uninstall <PATH|NUGET_ID> 
    [-d|--diagnostics] [--verbosity <LEVEL>] [-h|--help]
```

For example:

```
dotnet new uninstall .
```
