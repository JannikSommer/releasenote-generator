# Releasenote generator
 Release note generator for [OpenTAP docs](https://doc.opentap.io/), which pulls information from GitHub and generating a MarkDown file with structured data. 
 
Release notes are generated from a repository and a specific milestone, which then lists all the issues closed for that milestone sorted into sections based on issue labels.

## Table of contents

1. [Quickstart](#quickstart)
2. [GitHub permissions](#github-permissions)
3. [Command line arguments](#command-line-arguments)
4. [Configuration](#configuration)

## Quickstart

Build the console application, and then run it using the following command from the applcation directory. 

``` sh
dotnet build
dotnet run opentap 9.18
```

A markdown file is then generated in the application directory with the name `ReleaseNotes_opentap-9.18.md`


## GitHub permissions 

The console application is created with the purpose of generating release notes for [opentap](https://github.com/opentap/opentap) which is a public repository. Therefore, there is no need to use any authentication for that purpose specifically. However, if you want to use this application for anything else than public repositories on GitHub, you will need to use a Personal Access Token. See [command-line-arguments](#command-line-arguments) on how to add your token to the request. 


## Command line arguments 

To run the Release note generator use the following command

``` sh
ReleaseNoteGenerator <repository> <milestone> [options]
```

where `<repository>` is the name of the repository and `<milestone>` is the milestone title from the specified repository. 

### Options 

Use the following options to tweak the application. 

| Command           | Alias | Description                                                   | Default              | 
|-------------------|-------|-------------------------------------------------------------- |----------------------|
|  --token          | -t    | Specify a Personal Access Token (see [github-permissions](#github-permissions)).   | `null` | 
|  --output         | -o    | Specify a path for the generated markdown file to be placed.  | Application dir      |
|  --organization   | N/A   | Specify an alternative owner (organization, user, etc.).      | `"opentap"`          |
|  --version        | N/A   | Shows version information.                                    | N/A                  |


## Configuration 

Change the values in the `config.json` file to change the behavior of the generator. The program is currently dependant on the following configurations.

### Sections 
The `Sections` value is used to split labels into different header for the output. The list of sections are used as a priority list such that the issues are written in the order of labels. Furthermore, issues are only written in one section following the priority from the Sections (an issues with labels "feature" and "usability" will only be written under "New Features" header). You can use the `Header` value to change header in the output. 

**The `Label` value is NOT case sensitive!**

``` json
{
  "Sections": [
    {"Label": "feature", "Header": "New Features"},
    {"Label": "bug", "Header": "Bug Fixes"},
    {"Label": "usability", "Header": "Usability Improvements"},
    {"Label": "documentation", "Header": "Documentation"}
  ]
}
```

The exmaple json above will have the priority feature > bug > usabiltiy > documentation > other. **The other section will always be generated from the issues which could not be mapped to any of the labels specified**. 


