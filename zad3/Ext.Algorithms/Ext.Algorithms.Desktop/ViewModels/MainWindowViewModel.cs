﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Ext.Algorithms.Core.Enums;
using Ext.Algorithms.Implementation;
using Microsoft.Win32;

namespace Ext.Algorithms.Desktop.ViewModels
{
    public sealed class MainWindowViewModel : Conductor<Screen>.Collection.OneActive
    {
        public MainWindowViewModel()
        {
            Algorithms = AlgorithmFactory.Algorithms.Keys;

            DisplayName = "Algorytmy";
        }

        private string _filePath;
        private string _resultText;
        private string _fileContent;
        private string _selectedAlgorithm;

        public string SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                if (value != null)
                {
                    _selectedAlgorithm = value;
                    AlgorithmFactory.Algorithms.TryGetValue(_selectedAlgorithm, out _algorithm);
                }

                NotifyOfPropertyChange(() => SelectedAlgorithm);
                NotifyOfPropertyChange(() => CanProcessAlgorithm);
            }
        }

        public IEnumerable<string> Algorithms { get; set; }
        private IAlgorithm _algorithm;

        private IEnumerable<string> _listOfFileContent;
        private bool _canDownloadResult;

        public String FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                NotifyOfPropertyChange(() => FilePath);
                NotifyOfPropertyChange(() => CanReadFile);
                NotifyOfPropertyChange(() => CanProcessAlgorithm);
            }
        }

        public String ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                NotifyOfPropertyChange(() => ResultText);
            }
        }

        public String FileContent
        {
            get { return _fileContent; }
            set
            {
                _fileContent = value;
                NotifyOfPropertyChange(() => FileContent);
                NotifyOfPropertyChange(() => CanProcessAlgorithm);
            }
        }

        public bool CanProcessAlgorithm 
        {
            get
            {
                return 
                    !String.IsNullOrWhiteSpace(FilePath) &&
                    !String.IsNullOrWhiteSpace(FileContent) &&
                    !String.IsNullOrWhiteSpace(SelectedAlgorithm);
            }
        }

        

        public void ProcessAlgorithm()
        {
            try
            {
                var result = _algorithm.Process(_listOfFileContent);

                if (!String.IsNullOrWhiteSpace(result.Result))
                {
                    ResultText = "Wynik: " + Environment.NewLine + Environment.NewLine + result.Result;
                }

                CanDownloadResult = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wystąpił błąd. Spróbuj ponownie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                CanDownloadResult = false;
                FileContent = String.Empty;
            }
        }

        public void Browse()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "(*.txt)|*.txt"
            };

            if (openDialog.ShowDialog() == true)
            {
                FilePath = openDialog.FileName;
            }
        }

        public bool CanDownloadResult
        {
            get { return _canDownloadResult; }
            set
            {
                _canDownloadResult = value;
                NotifyOfPropertyChange(() => CanDownloadResult);
            }
        }

        public void DownloadResult()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "(*.txt)|*.txt"
            };

            var result = saveFileDialog.ShowDialog();

            if (result.HasValue)
            {
                File.WriteAllText(saveFileDialog.FileName, ResultText);
            }
        }

        public bool CanReadFile
        {
            get { return !String.IsNullOrWhiteSpace(FilePath); }
        }

        public void ReadFile()
        {
            if (String.IsNullOrWhiteSpace(FilePath)) return;

            _listOfFileContent = File.ReadAllLines(FilePath);
            
            if (!_listOfFileContent.Any()) return;

            FileContent = String.Join(Environment.NewLine, _listOfFileContent);
            ResultText = LoadedFileFormat(FileContent);

            CanDownloadResult = false;
        }

        private static string LoadedFileFormat(string fileContent)
        {
            return "Załadowany plik:" + Environment.NewLine + Environment.NewLine + fileContent;
        }
    }
}
