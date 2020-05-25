using System;
using System.IO;
using System.IO.Compression;
using Skarp.Version.Cli.Vcs.Git;

namespace Skarp.Version.Cli.Test
{
    public class GitVcsFixture : IDisposable
    {
        public readonly string GitTestDir;
        public readonly GitVcs Vcs;

        public GitVcsFixture()
        {
            GitTestDir = "./target-git-dir";
            DirectoryDelete(GitTestDir, recursive: true);

            ZipFile.ExtractToDirectory("./target-git.zip", "./");
            Vcs = new GitVcs();

            Directory.SetCurrentDirectory(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    GitTestDir
                )
            );
        }

        private void DirectoryDelete(string dir, bool recursive)
        {
            try
            {
                Directory.Delete(dir, recursive);
            }
            // we don't want to fail at all if deleting the dir fails
            catch (Exception ex)
            {
            }
        }

        public void Dispose()
        {
            Directory.SetCurrentDirectory(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "../"
                )
            );
            DirectoryDelete(GitTestDir, recursive: true);
        }
    }
}