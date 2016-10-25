using System;

namespace XStopwatch.Services
{
    public interface IStopwatch
    {
        void Start();

        void Stop();

        void Clear();

        IObservable<TimeSpan> Elapsed { get; }
    }
}