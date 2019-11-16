using Autofac;

namespace WPFValidationINotifyDataErrorInfo.Startup
{
    public static class ContrainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MatDesWindow>().AsSelf();

            return builder.Build();
        }
    }
}
