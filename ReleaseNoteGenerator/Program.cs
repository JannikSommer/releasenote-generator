using ReleaseNoteGenerator;
using System.CommandLine;
using Newtonsoft.Json;

// Setup arguments and options
var repositoryArgument = new Argument<string>("repository", "Name of milestone repository.");
var milestoneArgument = new Argument<string>("milestone", "Milestone name to generate release notes for.");
var tokenOption = new Option<string?>("--token", getDefaultValue: () => null,
    "Personal Access Token with repository:read permissions for private repositories.");
tokenOption.AddAlias("-t");
var outputPathOption = new Option<string?>("--output", getDefaultValue: () => null, "Full path for output markdown file.");
outputPathOption.AddAlias("-o");
var organizationOption = new Option<string>("--organization", getDefaultValue: () => "opentap", "Alternative owner of repositories.");

var rootCommand = new RootCommand("Release note generator for OpenTAP.io docs.");
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
    try
    {
        Generator generator = new Generator(LoadConfiguration(), repository, milestone, token, outputPath, organization);
        generator.Generate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return;
    }
}

Configuration LoadConfiguration()
{
    try
    {
        return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"))!;
    }
    catch (FileNotFoundException)
    {
        throw new Exception("Configuration file not found. Did you rename or delete ./config.json?"); 
    }
    catch (JsonException e)
    {
        throw e;
    }
}

