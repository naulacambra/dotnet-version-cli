using Skarp.Version.Cli.Vcs.Git;
using Xunit;

namespace Skarp.Version.Cli.Test
{
    public class GitVcsTest : IClassFixture<GitVcsFixture>
    {
        private readonly GitVcsFixture _fixture;


        public GitVcsTest(GitVcsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DetectingGitOnMachineWorks()
        {
            Assert.True(_fixture.Vcs.IsVcsToolPresent());
        }

        [Fact]
        public void IsRepositoryCleanWorks()
        {
            Assert.True(_fixture.Vcs.IsRepositoryClean());
        }
    }
}