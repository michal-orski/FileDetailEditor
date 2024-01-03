using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FileDetailEditor.Views;

namespace FileDetailEditor
{
    public static class DependencyContainer
    {
        public static IContainer? Container { get; private set; }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            // Register your dependencies here
            builder.RegisterType<Test1View>().As<UserControl>();
            builder.RegisterType<Test2View>().As<UserControl>();
            Container = builder.Build();
        }
    }
}
