using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using XStopwatch.ViewModels;

namespace XStopwatch.iOS.Views
{
    public partial class StopwatchView : MvxViewController<StopwatchViewModel>
    {
        public StopwatchView() : base("StopwatchView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<StopwatchView, StopwatchViewModel>();
            set.Bind(TimeElapsed).To(vm => vm.Elapsed).Apply();
            set.Bind(StartStop).For("Title").To(vm => vm.StartStopOption);
            
            StartStop.TouchUpInside += (sender, e) => ViewModel.StartStop.Execute();
            Clear.TouchUpInside += (sender, e) => ViewModel.Clear.Execute();

            set.Apply();
        }
    }
}
