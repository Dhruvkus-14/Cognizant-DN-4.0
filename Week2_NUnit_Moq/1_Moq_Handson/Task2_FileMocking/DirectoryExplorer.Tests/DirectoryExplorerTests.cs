using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";
        private Mock<IDirectoryExplorer> _mockExplorer;

        [OneTimeSetUp]
        public void Init()
        {
            _mockExplorer = new Mock<IDirectoryExplorer>();

            var fakeFiles = new List<string> { _file1, _file2 };

            _mockExplorer
                .Setup(m => m.GetFiles(It.IsAny<string>()))
                .Returns(fakeFiles);
        }

        [Test]
        public void GetFiles_ShouldReturnExpectedFileList()
        {
            var files = _mockExplorer.Object.GetFiles("dummy/path");

            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files, Does.Contain(_file1));
        }
    }
}
