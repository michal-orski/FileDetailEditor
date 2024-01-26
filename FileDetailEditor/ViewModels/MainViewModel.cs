using Autofac;
using CommunityToolkit.Mvvm.Input;
using FileDetailEditor.Base.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FileDetailEditor.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
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
