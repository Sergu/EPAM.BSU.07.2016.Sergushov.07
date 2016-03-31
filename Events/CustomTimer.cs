using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Events
{
    public sealed class TimerEventArgs : EventArgs
    {
        private int elapsedTime;
        public TimerEventArgs(int time)
        {
            this.elapsedTime = time;
        }
        public TimerEventArgs DeepCopy()
        {
            return new TimerEventArgs(elapsedTime);
        }
        public int ElapsedTime { get { return elapsedTime; } }
    }
    public class CustomTimer
    {
        public event EventHandler<TimerEventArgs> timer;

        protected virtual void OnTimerFinish(TimerEventArgs e)
        {
            if (ReferenceEquals(e, null))
                throw new NullReferenceException();
            EventHandler<TimerEventArgs> temp = timer;
            if (temp != null)
                temp(this, e);
        }
        public void TimerStart(int secondsNumb)
        {
            if (secondsNumb < 0)
                throw new ArgumentOutOfRangeException("количество секунд меньше нуля");
            Thread.Sleep(secondsNumb * 1000);
            OnTimerFinish(new TimerEventArgs(secondsNumb));
        }
    }
    public sealed class TimerListener
    {
        private List<TimerEventArgs> notifications = new List<TimerEventArgs>();
        public TimerListener(CustomTimer timer)
        {
            if (ReferenceEquals(timer, null))
                throw new NullReferenceException();
            timer.timer += OnTimerFinished;
        }
        public void Register(CustomTimer timer)
        {
            if (ReferenceEquals(timer, null))
                throw new NullReferenceException();
            timer.timer += OnTimerFinished;
        }
        public void Unregister(CustomTimer timer)
        {
            if (ReferenceEquals(timer, null))
                throw new NullReferenceException();
            timer.timer -= OnTimerFinished;
        }
        public IEnumerable<TimerEventArgs> GetAllTimersNotifications()
        {
            List<TimerEventArgs> list = new List<TimerEventArgs>();
            foreach (TimerEventArgs argument in notifications)
            {
                list.Add(argument.DeepCopy());
            }
            return list;
        }

        private void OnTimerFinished(object sender, TimerEventArgs e)
        {
            notifications.Add(e);
        }

    }
}
