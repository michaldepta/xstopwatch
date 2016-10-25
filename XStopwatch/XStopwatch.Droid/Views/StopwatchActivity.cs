using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using XStopwatch.ViewModels;

namespace XStopwatch.Droid.Views
{
    [Activity(Label = "XStopwatch")]
    public class StopwatchActivity : MvxActivity<StopwatchViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StopwatchView);
        }
    }
}
