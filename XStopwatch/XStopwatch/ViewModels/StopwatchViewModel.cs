using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using MvvmCross.Core.ViewModels;
using XStopwatch.Services;

namespace XStopwatch.ViewModels
{
    public class StopwatchViewModel : MvxViewModel, IDisposable
    {
        public enum State
        {
            Stopped,
            Running
        }

        private readonly Dictionary<State, string> _commandOptions = new Dictionary<State, string>
        {
            [State.Stopped] = "Start",
            [State.Running] = "Stop"
        };

        private readonly IStopwatch _stopwatch;
        private IDisposable _subscription;
        private string _elapsed;
        private string _startStopOption;
        private State _currentState;

        public StopwatchViewModel(IStopwatch stopwatch)
        {
            _stopwatch = stopwatch;
            _subscription = _stopwatch.Elapsed
                .Select(ts => ts.ToString(@"m\:ss\.fff"))
                .Subscribe(s => Elapsed = s);

            CurrentState = State.Stopped;
        }

        public string Elapsed
        {
            get { return _elapsed; }
            set
            {
                _elapsed = value;
                RaisePropertyChanged();
            }
        }

        public string StartStopOption
        {
            get { return _startStopOption; }
            set
            {
                _startStopOption = value;
                RaisePropertyChanged();
            }
        }

        public State CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                StartStopOption = _commandOptions[value];
                RaisePropertyChanged();
            }
        }

        public IMvxCommand StartStop => new MvxCommand(OnStartStop);

        public IMvxCommand Clear => new MvxCommand(() => _stopwatch.Clear());

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void OnStartStop()
        {
            switch (CurrentState)
            {
                case State.Stopped:
                    _stopwatch.Start();
                    CurrentState = State.Running;
                    break;
                case State.Running:
                    _stopwatch.Stop();
                    CurrentState = State.Stopped;
                    break;
            }
        }
    }
}