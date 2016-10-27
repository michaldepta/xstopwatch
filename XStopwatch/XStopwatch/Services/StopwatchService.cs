using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace XStopwatch.Services
{
    public class StopwatchService : IStopwatch, IDisposable
    {
        private static readonly TimeSpan Interval = TimeSpan.FromMilliseconds(10);
        private readonly IObservable<TimeSpan> _currentTimer;
        private readonly BehaviorSubject<Unit> _clearSubject = new BehaviorSubject<Unit>(Unit.Default); 
        private readonly IDisposable _subscription;
        private TimeSpan _cumulativeElapsed = TimeSpan.Zero;
        private TimeSpan _lastValue = TimeSpan.Zero;
        private long _startTicks;
        private bool _isRunning;

        public StopwatchService()
        {
            _currentTimer = Observable.Interval(Interval)
                .Where(_ => _isRunning)
                .Select(_ => TimeSpan.FromMilliseconds(Environment.TickCount - _startTicks))
                .Merge(_clearSubject.Select(_ => TimeSpan.Zero));

            _subscription = Elapsed.Subscribe(val => _lastValue = val);
        }

        public void Start()
        {
            _startTicks = Environment.TickCount;
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
            _cumulativeElapsed = _lastValue;
        }

        public void Clear()
        {
            _cumulativeElapsed = TimeSpan.Zero;
            _clearSubject.OnNext(Unit.Default);
        }

        public IObservable<TimeSpan> Elapsed => _currentTimer.Select(elapsed => elapsed.Add(_cumulativeElapsed));

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}