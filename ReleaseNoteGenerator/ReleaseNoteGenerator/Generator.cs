﻿using Octokit;

namespace ReleaseNoteGenerator
{
    public class Generator
    {
        private const string APP_NAME = "ReleaseNoteGenerator";

        public Generator(string repo, string milestone, string? token, string? outputPath, string organization)
        {
            _repository = repo;
            _milestone = milestone;
            _client = new GitHubClient(new ProductHeaderValue(APP_NAME));

            if (token is not null)
                _client.Credentials = new Credentials(token);

            if (outputPath is not null)
                _outputPath = outputPath;

            _organization = organization;
        }

        private GitHubClient _client;
        private string _repository;
        private string _milestone;
        private string? _outputPath;
        private string _organization;

        /// <summary>
        /// Generates markdown file of specified milestone.
        /// </summary>
        public void Generate()
        {
            // Get milestone info 
            int milestoneNumber = GetAllMilestonesForRepository()
                                    .Where(m => m.Title == _milestone)
                                    .First().Number;

            // Get issues
            var issues = GetAllIssuesForRepository(milestoneNumber);

            // Generate file
            GenerateMarkdownFile(issues);
        }

        private IReadOnlyList<Milestone> GetAllMilestonesForRepository()
        {
            try
            {
                var milestoneRequest = new MilestoneRequest
                {
                    State = ItemStateFilter.All
                };

                var milestones = _client.Issue.Milestone.GetAllForRepository(_organization, _repository, milestoneRequest).Result;
                if (milestones.Count == 0)
                {
                    throw new Exception("Specified milestone is not a milestone for specified repository.");
                }
                return milestones;
            }
            catch (Octokit.AuthorizationException)
            {
                if (_client.Credentials.AuthenticationType == AuthenticationType.Anonymous)
                {
                    throw new Exception("Unauthorized access - try again with -t (--token) option.");
                }
                else
                {
                    throw new Exception("Access token not authorized. Make sure it has the correct permissions.");
                }
            }
            catch (Octokit.ApiException e)
            {
                throw e;
            }
        }

        private IReadOnlyList<Issue> GetAllIssuesForRepository(int milestoneNumber)
        {
            var request = new RepositoryIssueRequest
            {
                Filter = IssueFilter.All,
                State = ItemStateFilter.All,
                Milestone = milestoneNumber.ToString()
            };
            try
            {
                var issues = _client.Issue.GetAllForRepository(_organization, _repository, request).Result;
                if (issues.Count == 0)
                {
                    throw new Exception("Milestone was found for repository but no issues were found.");
                }
                return issues;
            }
            catch (Octokit.AuthorizationException)
            {
                if (_client.Credentials.AuthenticationType == AuthenticationType.Anonymous)
                {
                    throw new Exception("Unauthorized access - try again with -t (--token) option.");
                }
                else
                {
                    throw new Exception("Access token not authorized. Make sure it has the correct permissions.");
                }
            }
            catch (Octokit.ApiException e)
            {
                throw e;
            }
        }

        private void GenerateMarkdownFile(IReadOnlyList<Issue> issues)
        {
            
            string path = CreateOutputPath();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine($"Release Notes - {_repository} {_milestone} \n ============= \n");

                // New Features section
                tw.WriteLine($"New Features \n ------- \n");
                WriteSection(tw, issues, "feature");

                // Usability Improvements section
                tw.WriteLine($"Usability Improvements \n ------- \n");
                WriteSection(tw, issues, "usability");

                // Bug Fixes section
                tw.WriteLine($"Bug Fixes \n ------- \n");
                WriteSection(tw, issues, "bug");

                // Documentation section
                tw.WriteLine($"Documentation \n ------- \n");
                WriteSection(tw, issues, "documentation");

                // Other section
                tw.WriteLine($"Other \n ------- \n");
                foreach (var issue in issues
                    .Where(i => i.Labels.All(l => !l.Name.ToLower().Contains("feature") 
                                               && !l.Name.ToLower().Contains("usability")
                                               && !l.Name.ToLower().Contains("bug")
                                               && !l.Name.ToLower().Contains("documentation")))
                    .OrderBy(i => i.Id))
                {
                    tw.WriteLine(IssueAsMarkdownItem(issue));
                }

                Console.WriteLine($"Release notes for {_repository} {_milestone} saved to {path}");
            }
        }

        private void WriteSection(TextWriter tw, IReadOnlyList<Issue> issues, string label)
        {
            foreach (var issue in issues
                .Where(i => i.Labels.Any(l => l.Name.ToLower().Contains(label) 
                                          && !l.Name.ToLower().Contains("regression")))
                .OrderBy(i => i.Id))
            {
                tw.WriteLine(IssueAsMarkdownItem(issue));
            }
            tw.WriteLine("\n");
        }

        private string IssueAsMarkdownItem(Issue issue)
        {
            return $"- {issue.Title} [#{issue.Number}]({issue.HtmlUrl})";
        }

        private string CreateOutputPath()
        {
            string fileName = $"ReleaseNotes_{_repository}-{_milestone}.md";
            if (_outputPath is null)
            {
                return fileName;
            }
            else
            {
                if (!Directory.Exists(_outputPath))
                {
                    Directory.CreateDirectory(_outputPath);
                }
                return Path.Join(_outputPath, fileName);
            }
        }
    }
}
