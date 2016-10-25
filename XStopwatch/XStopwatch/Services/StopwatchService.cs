using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace XStopwatch.Services
{
    public class StopwatchService : IStopwatch, IDisposable
    {
        private static readonly TimeSpan Interval = TimeSpan.FromMilliseconds(10);
        private readonly IObservable<TimeSpan> _currentTimer;
        private readonly IDisposable _subscription;
        private TimeSpan _cumulativeElapsed = TimeSpan.Zero;
        private TimeSpan _lastValue = TimeSpan.Zero;
        private long _startTicks;
        private bool _isRunning;

        public StopwatchService()
        {
            _currentTimer = Observable.Interval(Interval)
                .Select(_ => _isRunning
                        ? TimeSpan.FromMilliseconds(Environment.TickCount - _startTicks)
                        : TimeSpan.Zero);

            _subscription = Elapsed.Subscribe(val => _lastValue = val);
        }

        public void Start()
        {
            _startTicks = Environment.TickCount;
            _isRunning = true;
        }

        public void Stop()
        {
            var last = _lastValue;
            _isRunning = false;
            _cumulativeElapsed = last;
        }

        public void Clear()
        {
            _cumulativeElapsed = TimeSpan.Zero;
        }

        public IObservable<TimeSpan> Elapsed => _currentTimer.Select(elapsed => elapsed.Add(_cumulativeElapsed));

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}