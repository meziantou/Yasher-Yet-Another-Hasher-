using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yasher
{
    public partial class MainForm : Form
    {
        private BackgroundWorker myBackgroundWorker;

        public MainForm()
        {
            InitializeComponent();
            
            InitializeBackgroundWorker();

            CheckBox[] algoChoices = new[]
            {
                MD5_checkbox,
                SHA1_checkbox,
                SHA256_checkbox,
                SHA384_checkbox,
                SHA512_checkbox,
                RIPEMD160_checkbox
            };

            foreach (var algoChoice in algoChoices)
            {
                if ((bool)Properties.Settings.Default[algoChoice.Tag.ToString()] == true)
                {
                    algoChoice.CheckState = CheckState.Checked;
                }
                else
                {
                    algoChoice.CheckState = CheckState.Unchecked;
                }
            }

            
        }

        private string GetPreviousHash(string hash, string[] previousResults)
        {
            if (hash == null) throw new ArgumentNullException("hash");
            if (previousResults == null) throw new ArgumentNullException("previousResults");

            foreach (var previousResult in previousResults)
            {
                if (previousResult.StartsWith(hash))
                {
                    return previousResult;
                }
            }
            return null;
        }

        private string previousPrefix = "Previous ";

        private void SaveAlgorithmOptions()
        {
            CheckBox[] algoChoices = new[]
            {
                MD5_checkbox,
                SHA1_checkbox,
                SHA256_checkbox,
                SHA384_checkbox,
                SHA512_checkbox,
                RIPEMD160_checkbox
            };

            foreach (var algoChoice in algoChoices)
            {
                if (algoChoice.CheckState == CheckState.Checked)
                {
                    Properties.Settings.Default[algoChoice.Tag.ToString()] = true;
                }
                else
                {
                    Properties.Settings.Default[algoChoice.Tag.ToString()] = false;
                }
            }

            Properties.Settings.Default.Save();
        }

        private void UpdateGUIBusy()
        {
            percentProgressLabel.Visible = true;
            progressBar1.Visible = true;
            cancelButton.Visible = true;
            
        }

        private void UpdateGuiIdle()
        {
            percentProgressLabel.Visible = false;
            percentProgressLabel.BackColor = Color.Transparent;
            cancelButton.Visible = false;
            progressBar1.Visible = false;
        }

        private void InitializeBackgroundWorker()
        {
            myBackgroundWorker = new BackgroundWorker();
            myBackgroundWorker.WorkerSupportsCancellation = true;
            myBackgroundWorker.WorkerReportsProgress = true;
            myBackgroundWorker.DoWork += new DoWorkEventHandler(myBackgroundWorker_DoWork);
            myBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(myBackgroundWorker_ProgressChanged);
            myBackgroundWorker.RunWorkerCompleted += myBackgroundWorker_RunWorkerCompleted;
        }

        private void myBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                UpdateGuiIdle();
            }
            else
            {
                UpdateGuiIdle();
                UpdateTextBlock(_algorithms, _hashes);    
            }
            
        }

        private void myBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            percentProgressLabel.Text = e.ProgressPercentage + @"%";

            UpdateGUIBusy();
        }

        
        private List<HashAlgorithm> _hashes;
        private List<string> _algorithms;

        //private async void ComputeHash()
        private void myBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            #region

            var bg = (BackgroundWorker) sender;

            CheckBox[] algoChoices = new[]
                {
                    MD5_checkbox,
                    SHA1_checkbox,
                    SHA256_checkbox,
                    SHA384_checkbox,
                    SHA512_checkbox,
                    RIPEMD160_checkbox
                };

            SaveAlgorithmOptions();

            _algorithms = algoChoices.Where(_ => _.CheckState == CheckState.Checked).Select(_ => _.Tag.ToString()).ToList();

            #endregion


            Stream mystream;
            if (string.IsNullOrEmpty(fileTextBox.Text))
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(messageTextBox.Text);
                mystream = new MemoryStream(inputBytes);
            }
            else
            {
                try
                {
                    mystream = File.OpenRead(fileTextBox.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            

            byte[] buffer = new byte[4096];
            byte[] oldBuffer;
            int bytesRead;
            int oldBytesRead;
            long size;
            long totalBytesRead = 0;


            _hashes = new List<HashAlgorithm>();

            foreach (var algo in _algorithms)
            {
                _hashes.Add(HashAlgorithm.Create(algo));
            }


            size = mystream.Length;

            using (mystream)
            {
                bytesRead = mystream.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;

                int oldPercentProgress = 0;
                int percentProgress = 0;
                do
                {
                    if (bg.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    oldBytesRead = bytesRead;
                    oldBuffer = buffer;
                    const int a = 4096 * 1024 * 5;
                    buffer = new byte[a];
                    bytesRead = mystream.Read(buffer, 0, buffer.Length);

                    totalBytesRead += bytesRead;

                    var tabTask = new Task[_hashes.Count];

                    if (bytesRead == 0)
                    {
                        for (int index = 0; index < _hashes.Count; index++)
                        {
                            var hash = _hashes[index];
                            byte[] buffer1 = oldBuffer;
                            int read = oldBytesRead;
                            tabTask[index] = Task.Run(() => hash.TransformFinalBlock(buffer1, 0, read));
                        }
                        Task.WaitAll(tabTask.ToArray());
                    }
                    else
                    {
                        for (int index = 0; index < _hashes.Count; index++)
                        {
                            var hash = _hashes[index];
                            byte[] buffer1 = oldBuffer;
                            int read = oldBytesRead;
                            tabTask[index] = Task.Run(() => hash.TransformBlock(buffer1, 0, read, buffer1, 0));
                        }
                        Task.WaitAll(tabTask.ToArray());
                    }

                    oldPercentProgress = percentProgress;
                    if (size == 0)
                    {
                        percentProgress = 0;
                    }
                    else
                    {
                        percentProgress = (int)((double)totalBytesRead / size * 100);
                    }
                    
                    if (oldPercentProgress != percentProgress)
                    {
                        myBackgroundWorker.ReportProgress(percentProgress);    
                    }
                    
                } while (bytesRead != 0);
            }
        }
        
        private void UpdateTextBlock(List<string> algorithms, List<HashAlgorithm> hashes)
        {
            var previousResult = resultTextBox.Text.Split(Environment.NewLine.ToCharArray(),
                                                          StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < algorithms.Count; i++)
            {
                byte[] hash = hashes[i].Hash;
                if (hash == null)
                    continue;

                sb.AppendLine(algorithms[i] + " (hex): " + ToHex(hash));
                var previousHashHex = GetPreviousHash(algorithms[i] + " (hex):", previousResult);
                if (!string.IsNullOrEmpty(previousHashHex))
                {
                    sb.AppendLine(previousPrefix + previousHashHex);
                }
                sb.AppendLine(algorithms[i] + " (base64): " + Convert.ToBase64String(hash));
                var previousHashBase64 = GetPreviousHash(algorithms[i] + " (base64):", previousResult);
                if (!string.IsNullOrEmpty(previousHashBase64))
                {
                    sb.AppendLine(previousPrefix + previousHashBase64);
                }

            }

            this.SuspendLayout();
            resultTextBox.Clear();
            resultTextBox.Text = sb.ToString();
            foreach (var algorithm in algorithms)
            {
                var types = new[] { " (hex):", " (base64):" };
                foreach (var type in types)
                {
                    string str = algorithm + type;
                    int find = resultTextBox.Find(str);
                    changeResultTextBoxFont(find, str.Length, FontStyle.Bold);
                    

                    string previousStr = "Previous " + algorithm + type;
                    int findPrevious = resultTextBox.Find(previousStr);
                    if (findPrevious >= 0)
                    {
                        changeResultTextBoxFont(findPrevious, previousStr.Length, FontStyle.Bold);

                        #region color result in green or red depending on the current and previous hashes comparison
                        if (resultTextBox.Text.Substring(find, findPrevious - find) ==
                            resultTextBox.Text.Substring(findPrevious + previousPrefix.Length, findPrevious - find))
                        {
                            changeResultTextBoxColor(find, str.Length, Color.Green);
                            changeResultTextBoxColor(findPrevious, previousStr.Length, Color.Green);
                        }
                        else
                        {
                            changeResultTextBoxColor(find, str.Length, Color.Red);
                            changeResultTextBoxColor(findPrevious, previousStr.Length, Color.Red);
                        }
                        #endregion
                    }
                }
            }
            
            
            this.ResumeLayout(false);
            this.PerformLayout();

            
        }

        private void changeResultTextBoxColor(int start, int end, Color c)
        {
            resultTextBox.SelectionStart = start;
            resultTextBox.SelectionLength = end;
            resultTextBox.SelectionColor = c;
        }

        private void changeResultTextBoxFont(int start, int end, FontStyle f)
        {
            resultTextBox.SelectionStart = start;
            resultTextBox.SelectionLength = end;
            resultTextBox.SelectionFont = new Font(resultTextBox.Font, f); ;
        }

        private static string ToHex(IEnumerable<byte> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in array)
            {
                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult showDialog = dialog.ShowDialog();
            if (showDialog == DialogResult.OK || showDialog == DialogResult.Yes)
            {
                fileTextBox.Text = dialog.FileName;
                myBackgroundWorker.RunWorkerAsync();
                //await Task.Run(new Action(ComputeHash));
                //ComputeHash();
            }
        }


        private void computeButton_Click(object sender, EventArgs e)
        {
            string path = fileTextBox.Text;
            fileTextBox.Text = "";
            myBackgroundWorker.RunWorkerAsync();
            
            //await Task.Run(new Action(ComputeHash));
            //ComputeHash();
            fileTextBox.Text = path;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                fileTextBox.Text = files[0];
                //await Task.Run(new Action(ComputeHash));
                //ComputeHash();
                myBackgroundWorker.RunWorkerAsync();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            myBackgroundWorker.CancelAsync();
        }

    }
}
