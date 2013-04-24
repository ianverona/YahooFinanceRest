using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using System.Linq;

namespace YahooFinanceTest
{
    /// <summary>
    /// Not really a test, but a program to cleanup csv files
    /// </summary>
    [TestFixture]
    public class CleanupFilesTest
    {
        [Test, Ignore("Will actually do work on files")]
        public void DoCleanup()
        {
            var files = GetFileList();

            foreach (var filePath in files)
            {
                var lines = File.ReadAllLines(filePath).ToList();
                Console.WriteLine("Before {0}", lines.Count);
                var origLinesToRemove = (from line in lines where !string.IsNullOrEmpty(line) 
                                let origLine = line.Substring(line.IndexOf(';') + 1) 
                                where lines.Count(x => x.Contains(origLine)) >= 2 
                                select origLine).ToList();

                foreach (var removeLine in origLinesToRemove)
                {
                    var occuranceCount = lines.Count(x => x.Contains(removeLine));
                    for (var i = 0; i < occuranceCount-1; i++) // Leave one line
                    {
                        lines.Remove(lines.First(x => x.Contains(removeLine)));
                    }
                }
                
                File.WriteAllLines(filePath, lines);
            }
        }

        private static List<string> GetFileList()
        {
            const string relativePath = "..\\..\\..\\XMethodsStockService\\bin\\Debug\\csv";
            var files = Directory
                .EnumerateFiles(relativePath)
                .Where(x => x.Contains(".csv"))
                .ToList();
            if (!files.Any())
                Assert.Fail("No csv found in {0}", relativePath);
            return files;
        }
    }
}