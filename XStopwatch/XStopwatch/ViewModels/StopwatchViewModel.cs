using MvvmCross.Core.ViewModels;
using XStopwatch.Services;

namespace XStopwatch.ViewModels
{
    public class StopwatchViewModel : MvxViewModel
    {
        private const string StartText = "Start";
        private const string StopText = "Stop";
        private readonly IStopwatch _stopwatch;
        private string _elapsed;
        private string _startStopOption;

        public StopwatchViewModel(IStopwatch stopwatch)
        {
            _stopwatch = stopwatch;
            StartStopOption = StartText;
        }

        public string Elapsed
        {
            get { return _elapsed; }
            set { _elapsed = value; RaisePropertyChanged(); }
        }

        public string StartStopOption
        {
            get { return _startStopOption; }
            set { _startStopOption = value; RaisePropertyChanged(); }
        }

        public IMvxCommand StartStop => new MvxCommand(OnStartStop);

        private void OnStartStop()
        {
            Elapsed= "ABCDE";
        }
    }
}
