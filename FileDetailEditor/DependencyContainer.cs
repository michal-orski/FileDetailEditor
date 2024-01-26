using Autofac;
using FileDetailEditor.Views;
using System.Windows.Controls;

namespace FileDetailEditor
{
    public static class DependencyContainer
    {
        public static IContainer? Container { get; private set; }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            // Register your dependencies here
            builder.RegisterType<ID3TagsView>().As<UserControl>();
            Container = builder.Build();
        }
    }
}
