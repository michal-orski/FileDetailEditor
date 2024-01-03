using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FileDetailEditor.Base.ViewModels
{
    public abstract class ViewModelBase : UserControl, INotifyPropertyChanged
    {
        // no CS0067 though the event is left unused  
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
