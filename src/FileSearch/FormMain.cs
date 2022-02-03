using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Search
{
    public partial class FormMain : Form
    {

        private string BUTTON_SEARCH_CANCEL = "Cancel";
        private string BUTTON_SEARCH_SEARCH = "Search";

        private class SearchParameters
        {
            public string FileName { get; set; }
            public string FileContent { get; set; }
            public string Directory { get; set; }
            public int DirectoriesDeep { get; set; }
            public bool CaseSensitive { get; set; }
        }

        private class SearchProgress
        {
            public bool StatusOnly { get; set; }
            public string Status { get; set; }
            public string FileName { get; set; }
            public string MatchingLine { get; set; }
            public int? MatchingLineNumber { get; set; }
        }

        private BackgroundWorker worker;

        public FormMain()
        {
            InitializeComponent();

            // ToDo: should remember last directory.
            string lastDirectory = GetLastDirectory();

            if (lastDirectory != null && Directory.Exists(lastDirectory))
            {
                textBoxStartingDirectory.Text = lastDirectory;
            }
            else
            {
                textBoxStartingDirectory.Text = Directory.GetCurrentDirectory();
            }
            Icon = SystemIcons.Question;
        }

        private void buttonFindStartingDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the directory to begin searching in";
                folderBrowserDialog.ShowNewFolderButton = false; // New folders are outside the scope of this app
                if (!string.IsNullOrWhiteSpace(textBoxStartingDirectory.Text) && System.IO.Directory.Exists(textBoxStartingDirectory.Text))
                    folderBrowserDialog.SelectedPath = textBoxStartingDirectory.Text;
                if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxStartingDirectory.Text = folderBrowserDialog.SelectedPath;
                    SetLastDirectory(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // This button says "CANCEL" when actively searching, "SEARCH" when not actively searching.
            if (buttonSearch.Text == BUTTON_SEARCH_CANCEL)
            {
                worker.CancelAsync();
                buttonSearch.Enabled = false;
            }
            else
            {
                buttonSearch.Text = BUTTON_SEARCH_CANCEL;
                SearchParameters parameters = new SearchParameters
                {
                    FileContent = textBoxFileContent.Text,
                    FileName = textBoxFileName.Text,
                    Directory = textBoxStartingDirectory.Text,
                    DirectoriesDeep = Convert.ToInt32(numericUpDownFoldersDeep.Value),
                    CaseSensitive = checkBoxCaseSensitive.Checked
                };
                grid.Rows.Clear();
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += new DoWorkEventHandler(workStart);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workComplete);
                worker.ProgressChanged += new ProgressChangedEventHandler(workProgress);
                worker.RunWorkerAsync(parameters);
            }
        }

        private void ReportProgress(BackgroundWorker workerBee, string fileName, string matchingLine, int? matchingLineNumber = null)
        {
            SearchProgress progress = new SearchProgress()
            {
                StatusOnly = false,
                Status = "Match Found: " + fileName,
                FileName = fileName,
                MatchingLine = matchingLine,
                MatchingLineNumber = matchingLineNumber
            };
            workerBee.ReportProgress(0, progress);
        }

        private void ReportProgress(BackgroundWorker workerBee, string status)
        {
            SearchProgress progress = new SearchProgress()
            {
                StatusOnly = true,
                Status = status
            };
            workerBee.ReportProgress(0, progress);
        }

        // Processed in the main thread, called by workStart
        public void workProgress(Object sender, ProgressChangedEventArgs e)
        {
            SearchProgress progress = ((SearchProgress)e.UserState);
            labelStatus.Text = progress.Status;
            if (!progress.StatusOnly)
            {
                grid.Rows.Add(progress.FileName, progress.MatchingLineNumber, progress.MatchingLine);
            }
        }

        // Processed in the main thread, called by workStart
        public void workComplete(Object sender, RunWorkerCompletedEventArgs e)
        {
            buttonSearch.Text = BUTTON_SEARCH_SEARCH;
            buttonSearch.Enabled = true;
            labelStatus.Text = (string)e.Result;
        }

        // Processed in a separate thread, called by worker.RunWorkerAsync(parameters)
        private void workStart(object sender, DoWorkEventArgs args)
        {
            // Grab the instance of this background worker (used to report progress)
            BackgroundWorker workerBee = sender as BackgroundWorker;
            // Extract parameters
            SearchParameters parameters = (SearchParameters)args.Argument;
            if (string.IsNullOrWhiteSpace(parameters.Directory))
            {
                args.Result = "Root Folder is blank";
                return;
            }
            else if (!System.IO.Directory.Exists(parameters.Directory))
            {
                args.Result = "Root Folder does not exist";
                return;
            }
            // Define list of directories to process
            Dictionary<string, int> directories = new Dictionary<string, int>();
            // Initialize root directory
            directories.Add(parameters.Directory, 0);
            // Create Regex for FileName and FileContent
            Regex regexFileName = null;
            RegexOptions options = RegexOptions.Compiled;
            if (!parameters.CaseSensitive) options = options | RegexOptions.IgnoreCase;
            if (!string.IsNullOrEmpty(parameters.FileName))
            {
                regexFileName = new Regex(parameters.FileName, options);
            }
            Regex regexFileContent = null;
            if (!string.IsNullOrEmpty(parameters.FileContent))
            {
                regexFileContent = new Regex(parameters.FileContent, options);
            }
            // Keep track of files processed
            int fileCount = 0;
            do
            {
                if (workerBee.CancellationPending) break;
                KeyValuePair<string, int> directory = directories.First();
                directories.Remove(directory.Key);
                ReportProgress(workerBee, string.Format("Searching {0}", directory.Key));
                // Add sub-directories
                if (parameters.DirectoriesDeep > directory.Value)
                {
                    try
                    {
                        string[] subDirectories = Directory.GetDirectories(directory.Key);
                        foreach (string subDirectory in subDirectories)
                        {
                            directories.Add(subDirectory, (directory.Value + 1));
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine(exception);
                        ReportProgress(workerBee, $"Exception: {exception.Message}");
                    }
                }
                // Grab files
                List<string> files = new List<string>();
                try
                {
                    files.AddRange(Directory.GetFiles(directory.Key));
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine(exception);
                    ReportProgress(workerBee, $"Exception: {exception.Message}");
                }
                if (files.Count > 0)
                {
                    fileCount += files.Count;
                    if (regexFileName == null && regexFileContent == null)
                    {
                        // Report all files
                        foreach (string file in files)
                        {
                            ReportProgress(workerBee, file, null);
                        }
                    }
                    else
                    {
                        // Remove files from array that do not match
                        if (regexFileName != null)
                        {
                            for (int i = (files.Count - 1); i >= 0; i--)
                            {

                                if (workerBee.CancellationPending) break;

                                if (!regexFileName.Match(files[i]).Success)
                                {
                                    files.RemoveAt(i);
                                }
                            }
                        }
                        // Check that we have files to process
                        if (files.Count > 0)
                        {
                            if (regexFileContent == null)
                            {
                                // Report all files
                                foreach (string file in files)
                                {
                                    if (workerBee.CancellationPending) break;
                                    ReportProgress(workerBee, file, null);
                                }
                            }
                            else
                            {
                                // Dig through the contents of each file
                                foreach (string file in files)
                                {
                                    if (workerBee.CancellationPending) break;
                                    ReportProgress(workerBee, $"Searching '{file}' for expression '{parameters.FileContent}'");
                                    try
                                    {
                                        using (StreamReader stream = new StreamReader(file))
                                        {
                                            string line;
                                            int lineNumber = 0;
                                            while ((line = stream.ReadLine()) != null)
                                            {
                                                if (workerBee.CancellationPending) break;
                                                if (regexFileContent.Match(line).Success)
                                                {
                                                    // Report success
                                                    ReportProgress(workerBee, file, line, lineNumber);
                                                    break;
                                                }
                                                lineNumber++;
                                            }
                                        }
                                    }
                                    catch (System.IO.IOException exception)
                                    {
                                        Console.Error.WriteLine(exception);
                                        ReportProgress(workerBee, $"Exception: {exception.Message}");
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.Error.WriteLine(exception);
                                        ReportProgress(workerBee, $"Exception: {exception.Message}");
                                    }
                                }
                            }
                        }
                    }
                }

            } while (directories.Count > 0);
            args.Result = string.Format("Processed {0} files", fileCount);
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridFileName.HeaderCell.ColumnIndex) // FileName
            {
                string fileName = grid.Rows[e.RowIndex].Cells[gridFileName.HeaderCell.ColumnIndex].Value as string;
                // Open the file in Notepad++. If Notepad++ is not installed, open with notepad.
                // See: http://stackoverflow.com/a/13755363/772086
                string exePath = "notepad.exe";
                
                var nppDir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Notepad++", null, null);
                if (string.IsNullOrEmpty(nppDir))
                {
                    nppDir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Notepad++", null, null);
                }
                if (!string.IsNullOrEmpty(nppDir))
                {
                    exePath = Path.Combine(nppDir, "Notepad++.exe");
                    int? line = grid.Rows[e.RowIndex].Cells[gridLineNumber.HeaderCell.ColumnIndex].Value as int?;
                    if (line.HasValue)
                    {
                        // Pass in the line number as an argument to have Notepad++ jump to the pertinent line.
                        fileName = string.Format("\"{0}\" -n{1}", fileName, line.Value + 1);
                    }
                }
                
                Process.Start(exePath, fileName);
            }
        }
        private static readonly RegistryKey SoftwareKey = RegistryKey
            .OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
            .OpenSubKey("Software", true);
        private readonly string LastDirectoryKeyName = "LastDirectory";

        private string GetLastDirectory()
        {
            return SoftwareKey.OpenSubKey("FileSearch")?.GetValue(LastDirectoryKeyName) as string;
        }

        private void SetLastDirectory(string value)
        {
            SoftwareKey.CreateSubKey("FileSearch").SetValue(LastDirectoryKeyName, value);
        }
    }
}
