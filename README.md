# Releasenote generator
 Releasenote generator for [OpenTAP docs](https://doc.opentap.io/), which pulls information from GitHub and generating a MarkDown file with structured data. 

## Table of contents

1. [Quickstart](#quickstart)
2. [GitHub permissions](#github-permissions)
3. [Command line arguments](#command-line-arguments)

## Quickstart

Build and run then run the console application with PowerShell using the following command from the applcation directory. 

``` sh
.\ReleaseNoteGenerator.exe opentap 9.18
```

A markdown file is not generated in the application directory with the name `ReleaseNotes_opentap-9.18.md`


## GitHub permissions 

The console application is created with the purpose of generating release notes for [opentap](https://github.com/opentap/opentap) which is a public repository. Therefore, there is no need to use any authentication for that purpose specifically. However, if you want to use this application for anything else than public repositories on GitHub, you will need to use a Personal Access Token. See [command-line-arguments](#command-line-arguments) on how to add your token to the request. 


## Command line arguments 

To run the Release note generator use the following command

``` sh
ReleaseNoteGenerator <repository> <milestone> [options]
```

where `<repository>` is the name of the repository and `<milestone>` is the milestone title from the specified repository. 

### Options 

Use the following options to tweek the application. 

| Command           | Alias | Description                                                   | Default              | 
|-------------------|-------|-------------------------------------------------------------- |----------------------|
|  --token          | -t    | Specify a Personal Access Token (see [github-permissions](#github-permissions)).   | `null`               | 
|  --output         | -o    | Specify a path for the generated markdown file to be placed.  | Application directory|
|  --organization   | N/A   | Specify an alternative owner (organization, user, etc.).      | `"opentap"`          |
|  --version        | N/A   | Shows version information                                     | N/A                  |


