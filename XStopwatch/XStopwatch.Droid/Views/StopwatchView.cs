using Android.App;
using MvvmCross.Droid.Views;
using XStopwatch.ViewModels;

namespace XStopwatch.Droid.Views
{
    [Activity(Label = "XStopwatch")]
    public class StopwatchView : MvxActivity<StopwatchViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.StopwatchView);
        }
    }
}
