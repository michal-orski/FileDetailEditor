using CommunityToolkit.Mvvm.Input;
using FileDetailEditor.Base.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace FileDetailEditor.ViewModels
{
    public class ID3TagsViewModel : ViewModelBase
    {
        public ObservableCollection<FileInfo> FileCollection { get; set; } = [];
        private FileInfo? _selectedFileInfo = null;
        public FileInfo? SelectedFileInfo
        {
            get { return _selectedFileInfo; }
            set
            {
                _selectedFileInfo = value;
                LoadId3DataFromSelectedFileInfoToFileAttributeCollection();
            }
        }

        public ObservableCollection<object> FileAttributeCollection { get; set; } = [];


        private string _selectedDirectoryPath = string.Empty;
        public string SelectedDirectoryPath
        {
            get { return _selectedDirectoryPath; }
            set
            {
                _selectedDirectoryPath = value;
                LoadFilesFromSelectedDirectoryPathToFileCollection();
            }
        }

        private bool _canSearchSubdirectories = false;
        public bool CanSearchSubdirectories
        {
            get { return _canSearchSubdirectories; }
            set
            {
                _canSearchSubdirectories = value;
                LoadFilesFromSelectedDirectoryPathToFileCollection();
            }
        }

        public ICommand SelectFileCommand { get; private set; }

        public ID3TagsViewModel()
        {
            SelectFileCommand = new RelayCommand(SelectFile, CanSelectFile);


        }

        private bool CanSelectFile()
        {
            return true;
        }

        private void SelectFile()
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            var result = folderBrowserDialog.ShowDialog();

            if (result != DialogResult.OK) return;
            if (!Directory.Exists(folderBrowserDialog.SelectedPath)) return;

            SelectedDirectoryPath = folderBrowserDialog.SelectedPath;


            LoadFilesFromSelectedDirectoryPathToFileCollection();
        }


        private void LoadFilesFromSelectedDirectoryPathToFileCollection()
        {
            if (!Directory.Exists(SelectedDirectoryPath))
            {
                if (FileCollection.Any())
                    FileCollection = [];
                return;
            }

            FileCollection = new ObservableCollection<FileInfo>(GetAllFileInfoFromPath(SelectedDirectoryPath));
        }

        private List<FileInfo> GetAllFileInfoFromPath(string path)
        {
            var files = new List<FileInfo>();
            var filePathList = new List<string>();

            try
            {

                if (CanSearchSubdirectories)
                    filePathList.AddRange(Directory.GetFiles(path, "*", SearchOption.AllDirectories));
                else
                    filePathList.AddRange(Directory.GetFiles(path));

            }
            catch
            {
                return files;
            }

            foreach (var filePath in filePathList)
            {
                try
                {
                    var fileInfo = new FileInfo(filePath);
                    files.Add(fileInfo);
                }
                catch
                {
                    continue;
                }
            }

            return files;
        }

        private void LoadId3DataFromSelectedFileInfoToFileAttributeCollection()
        {
            if (SelectedFileInfo == null)
            {
                if (FileAttributeCollection.Any())
                    FileAttributeCollection = [];
                return;
            }

            FileAttributeCollection = new ObservableCollection<object>(GetAllId3DataFromSelectedFileInfo());
        }


        private List<object> GetAllId3DataFromSelectedFileInfo()
        {
            var Id3Data = new List<object>();

            if (SelectedFileInfo == null)
                return Id3Data;


            return Id3Data;
        }


    }
}
