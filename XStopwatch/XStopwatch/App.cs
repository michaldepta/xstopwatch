using MvvmCross.Platform.IoC;

namespace XStopwatch
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            var x = CreatableTypes()
                .EndingWith("Service");
            x.AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.StopwatchViewModel>();
        }
    }
}