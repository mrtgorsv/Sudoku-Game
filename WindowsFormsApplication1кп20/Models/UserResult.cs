using System;

namespace WindowsFormsApplication1кп20.Models
{
    public class UserResult
    {
        public string UserName { get; set; }
        public TimeSpan ElapsedTime { get; set; }

        public override string ToString()
        {
            return $"{UserName} {ElapsedTime:T}";
        }
    }
}
