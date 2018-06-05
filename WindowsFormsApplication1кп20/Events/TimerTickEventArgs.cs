using System;

namespace WindowsFormsApplication1кп20.Events
{
    public class TimerTickEventArgs : EventArgs
    {
        public string ElapsedTime { get; set; }

        public TimerTickEventArgs(string elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
    }
}
