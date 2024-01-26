using System.ComponentModel;
using System.Windows.Controls;

namespace FileDetailEditor.Base.ViewModels
{
    public abstract class ViewModelBase : UserControl, INotifyPropertyChanged
    {
        // no CS0067 though the event is left unused  
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
