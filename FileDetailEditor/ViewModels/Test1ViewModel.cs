using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileDetailEditor.Base.ViewModels;

namespace FileDetailEditor.ViewModels
{
    public class Test1ViewModel : ViewModelBase
    {
        public string TestLabel { get; set; } = nameof(Test1ViewModel);
    }
}
