using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeBreaker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _code;
        private List<TextBlock> _outputCharLabels;
        private readonly BackgroundWorker worker1 = new BackgroundWorker();
        private readonly BackgroundWorker worker2 = new BackgroundWorker();
        private readonly BackgroundWorker worker3 = new BackgroundWorker();
        private readonly BackgroundWorker worker4 = new BackgroundWorker();
        private List<ProgressBar> _progressBars;
        private List<BackgroundWorker> _workers;

        public MainWindow()
        {
            InitializeComponent();
            worker1.DoWork += BakCodebreaker_DoWorkAsync;
            worker1.WorkerReportsProgress = true;
            worker1.ProgressChanged += BakCodebreaker_ProgressChanged;
            worker1.WorkerSupportsCancellation = true;
            worker1.RunWorkerCompleted += BakCodebreaker1_RunWorkerCompleted;

            worker2.DoWork += BakCodebreaker_DoWorkAsync;
            worker2.WorkerReportsProgress = true;
            worker2.ProgressChanged += BakCodebreaker_ProgressChanged;
            worker2.WorkerSupportsCancellation = true;
            worker2.RunWorkerCompleted += BakCodebreaker1_RunWorkerCompleted;

            worker3.DoWork += BakCodebreaker_DoWorkAsync;
            worker3.WorkerReportsProgress = true;
            worker3.ProgressChanged += BakCodebreaker_ProgressChanged;
            worker3.WorkerSupportsCancellation = true;
            worker3.RunWorkerCompleted += BakCodebreaker1_RunWorkerCompleted;

            worker4.DoWork += BakCodebreaker_DoWorkAsync;
            worker4.WorkerReportsProgress = true;
            worker4.ProgressChanged += BakCodebreaker_ProgressChanged;
            worker4.WorkerSupportsCancellation = true;
            worker4.RunWorkerCompleted += BakCodebreaker1_RunWorkerCompleted;

            _workers = new List<BackgroundWorker>();
            _workers.Add(worker1);
            _workers.Add(worker2);
            _workers.Add(worker3);
            _workers.Add(worker4);

            btnStop.IsEnabled = false;

            SimulateCodeGeneration();

            _outputCharLabels = new List<TextBlock>(4);
            _outputCharLabels.Add(txtOutput1);
            _outputCharLabels.Add(txtOutput2);
            _outputCharLabels.Add(txtOutput3);
            _outputCharLabels.Add(txtOutput4);

            _progressBars = new List<ProgressBar>(4);
            _progressBars.Add(progressBarChar1);
            _progressBars.Add(progressBarChar2);
            _progressBars.Add(progressBarChar3);
            _progressBars.Add(progressBarChar4);

            ShowCodeBreaker();
        }

        private void BakCodebreaker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompletedProcedure(sender, e);
        }

        private void BakCodebreaker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChangedProcedure(sender, e);
        }

        private void SimulateCodeGeneration()
        {
            var random = new Random();
            _code = string.Empty;

            for (int i = 0; i < 4; i++)
            {
                _code += (char)(random.Next(65535));
            }
        }

        private void SetFishesVisibility(Visibility visibility)
        {
            imgFish1.Visibility = visibility;
            imgFish2.Visibility = visibility;
            imgFish3.Visibility = visibility;
            txtFishGame.Visibility = visibility;
            btnGameOver.Visibility = visibility;
        }

        private void SetCodeBreakerVisibility(Visibility visibility)
        {
            imgSkull.Visibility = visibility;
            imgAgent.Visibility = visibility;
            txtCodeBreaker.Visibility = visibility;
            txtNumber1.Visibility = visibility;
            txtNumber2.Visibility = visibility;
            txtNumber3.Visibility = visibility;
            txtNumber4.Visibility = visibility;
            txtOutput1.Visibility = visibility;
            txtOutput2.Visibility = visibility;
            txtOutput3.Visibility = visibility;
            txtOutput4.Visibility = visibility;
            btnStart.Visibility = visibility;
            btnHide.Visibility = visibility;
            progressBarChar1.Visibility = visibility;
            progressBarChar2.Visibility = visibility;
            progressBarChar3.Visibility = visibility;
            progressBarChar4.Visibility = visibility;
            btnStop.Visibility = visibility;
        }

        private void ShowFishes()
        {
            SetCodeBreakerVisibility(Visibility.Hidden);
            this.Title = "Fishing game for Windows 1.0";
            SetFishesVisibility(Visibility.Visible);
        }

        private void ShowCodeBreaker()
        {
            SetFishesVisibility(Visibility.Hidden);
            this.Title = "CodeBreaker Application";
            SetCodeBreakerVisibility(Visibility.Visible);
        }

        private bool CheckCodeChar(char character, int characterPosition)
        {
            return (_code[characterPosition] == character);
        }

        private void BtnGameOver_Click(object sender, RoutedEventArgs e)
        {
            ShowCodeBreaker();
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            ShowFishes();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            CodeBreakerParameters parameters1 = new CodeBreakerParameters
            {
                MaxUnicodeCharCode = 32000,
                FirstCharNumber = 0,
                LastCharNumber = 0
            };

            CodeBreakerParameters parameters2 = new CodeBreakerParameters
            {
                MaxUnicodeCharCode = 32000,
                FirstCharNumber = 1,
                LastCharNumber = 1
            };

            CodeBreakerParameters parameters3 = new CodeBreakerParameters
            {
                MaxUnicodeCharCode = 32000,
                FirstCharNumber = 2,
                LastCharNumber = 2
            };

            CodeBreakerParameters parameters4 = new CodeBreakerParameters
            {
                MaxUnicodeCharCode = 32000,
                FirstCharNumber = 3,
                LastCharNumber = 3
            };

            worker1.RunWorkerAsync(parameters1);
            worker2.RunWorkerAsync(parameters2);
            worker3.RunWorkerAsync(parameters3);
            worker4.RunWorkerAsync(parameters4);
        }

        private void BakCodebreaker_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            DoWorkProcedure(sender, e);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            EnableBtnStart();

            worker1.CancelAsync();
            worker2.CancelAsync();
            worker3.CancelAsync();
            worker4.CancelAsync();
        }

        private void EnableBtnStart()
        {
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
        }

        private void DoWorkProcedure(object sender, DoWorkEventArgs e)
        {
            char character;
            TextBlock currentTextBlock;
            CodeBreakerParameters breakerParameters = (CodeBreakerParameters)e.Argument;
            int characterPosition = breakerParameters.FirstCharNumber;

            int maxCharCode = breakerParameters.MaxUnicodeCharCode;
            string brokenCode = "";

            var breakerProgress = new CodeBreakerProgress();
            int oldldPercentageCompleted = 0;
            currentTextBlock = _outputCharLabels[characterPosition];

            for (int i = 0; i <= 65535; i++)
            {
                Thread.SpinWait(40000);

                if (((BackgroundWorker)sender).CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                character = (char)(i);

                breakerProgress.PercentageCompleted = i * 100 / 65535;
                breakerProgress.CharNumber = characterPosition;
                breakerProgress.CharCode = i;

                if (breakerProgress.PercentageCompleted > oldldPercentageCompleted)
                {
                    ((BackgroundWorker)sender).ReportProgress(breakerProgress.PercentageCompleted, breakerProgress);
                    oldldPercentageCompleted = breakerProgress.PercentageCompleted;
                }

                if (CheckCodeChar(character, characterPosition))
                {
                    brokenCode += character.ToString();

                    breakerProgress.PercentageCompleted = 100;
                    ((BackgroundWorker)sender).ReportProgress(breakerProgress.PercentageCompleted, breakerProgress);
                    break;
                }
            }

            CodeBreakerResult breakerResult = new CodeBreakerResult
            {
                FirstCharNumber = breakerParameters.FirstCharNumber,
                LastCharNumber = breakerParameters.LastCharNumber,
                BrokenCode = brokenCode
            };

            e.Result = breakerResult; // it can be accessed in the completed event handler
        }

        private void RunWorkerCompletedProcedure(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var result = (CodeBreakerResult)e.Result;

                for (int i = result.FirstCharNumber; i < result.LastCharNumber; i++)
                {
                    _progressBars[i].Value = 100;
                    _outputCharLabels[i].Text = result.BrokenCode[i - result.FirstCharNumber].ToString();
                }
            }

            if (!_workers.Any(w => w.IsBusy))
            {
                EnableBtnStart();
            }
        }

        private void ProgressChangedProcedure(object sender, ProgressChangedEventArgs e)
        {
            var codeBreakerProgress = (CodeBreakerProgress)e.UserState;
            _progressBars[codeBreakerProgress.CharNumber].Value = codeBreakerProgress.PercentageCompleted;
            _outputCharLabels[codeBreakerProgress.CharNumber].Text = ((char)codeBreakerProgress.CharCode).ToString();
        }
    }
}
