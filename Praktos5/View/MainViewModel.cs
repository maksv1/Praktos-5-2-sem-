using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Documents;

namespace Praktos5
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _filePath; 
        private string _savePath; 
        private ObservableCollection<Figure> _figures; 
        private FileManager _fileManager; 

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        public string SavePath
        {
            get { return _savePath; }
            set
            {
                _savePath = value;
                OnPropertyChanged(nameof(SavePath));
            }
        }

        public ObservableCollection<Figure> Figures
        {
            get { return _figures; }
            set
            {
                _figures = value;
                OnPropertyChanged(nameof(Figures));
            }
        }

        public ICommand LoadFileCommand { get; }

        public ICommand SaveFileCommand { get; }

        public MainViewModel()
        {
            _fileManager = new FileManager();
            Figures = new ObservableCollection<Figure>();

            LoadFileCommand = new Praktos5.RelayCommand(LoadFile);
            SaveFileCommand = new Praktos5.RelayCommand(SaveFile);
        }

        private void LoadFile(object obj)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                var figuresList = _fileManager.LoadFromFile(FilePath);
                if (figuresList != null)
                {
                    Figures.Clear();
                    foreach (var figure in figuresList)
                    {
                        Figures.Add(figure);
                    }
                }
            }
        }

        private void SaveFile(object obj)
        {
            if (!string.IsNullOrEmpty(SavePath))
            {
                _fileManager.SaveToFile(SavePath, Figures.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
