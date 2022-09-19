using ReleaseNoteGenerator;
using System.CommandLine;

// Setup arguments and options
var repositoryArgument = new Argument<string>("repository", "Name of milestone repository.");
var milestoneArgument = new Argument<string>("milestone", "Milestone name to generate release notes for.");
var tokenOption = new Option<string?>("--token", getDefaultValue: () => null,
    "Personal Access Token with repository:read permissions for private repositories.");
tokenOption.AddAlias("-t");
var outputPathOption = new Option<string?>("--output", getDefaultValue: () => null, "Full path for output markdown file.");
outputPathOption.AddAlias("-o");
var organizationOption = new Option<string>("--organization", getDefaultValue: () => "opentap", "Alternative owner of repositories.");


var rootCommand = new RootCommand("Realease note generator for OpenTAP.io docs.");
rootCommand.AddArgument(repositoryArgument);
rootCommand.AddArgument(milestoneArgument);
rootCommand.AddOption(tokenOption);
rootCommand.AddOption(outputPathOption);    
rootCommand.AddOption(organizationOption);

rootCommand.SetHandler((repo, milestone, token, outputPath, organization) =>
{
        Run(repo, milestone, token, outputPath, organization);
    }, 
    repositoryArgument, milestoneArgument, tokenOption, outputPathOption, organizationOption);

return await rootCommand.InvokeAsync(args);


void Run(string repository, string milestone, string? token, string? outputPath, string organization)
{
    Generator generator = new Generator(repository, milestone, token, outputPath, organization);
    try
    {
        generator.Generate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return;
    }
}

