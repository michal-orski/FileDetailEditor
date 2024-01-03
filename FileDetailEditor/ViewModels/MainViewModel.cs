using Autofac;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FileDetailEditor.Base.ViewModels;
using FileDetailEditor.Views;

namespace FileDetailEditor.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SwitchCommand { get; set; }
        public FrameworkElement SelectedView { get; set; }

        private readonly IList<UserControl> _AvaiableViewModels;       

        public MainViewModel()
        {
            if (DependencyContainer.Container == null) throw new NullReferenceException("Dependency Container is null");
            _AvaiableViewModels = DependencyContainer.Container.Resolve<IList<UserControl>>();
            if (!_AvaiableViewModels.Any()) throw new NullReferenceException("no view registered in container");
            SelectedView = _AvaiableViewModels.First();


            SwitchCommand = new RelayCommand(SwitchView, SwitchViewActive);
        }
        private void SwitchView()
        {
            SelectedView = _AvaiableViewModels.First(p => !p.Equals(SelectedView));
        }
        private bool SwitchViewActive() => true;

    }
}
