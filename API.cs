using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class API
    {
        /// <summary>
        /// Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the application is running.
        /// </summary>
        [DllImport("kernel32")]
        public static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [Flags]
        public enum ExecutionState : uint
        {
            /// <summary>
            /// Forces the system to be in the working state by resetting the system idle timer.
            /// </summary>
            SystemRequired = 0x01,

            /// <summary>
            /// Forces the display to be on by resetting the display idle timer.
            /// </summary>
            DisplayRequired = 0x02,

            /// <summary>
            /// This value is not supported. If <see cref="UserPresent"/> is combined with other esFlags values, the call will fail and none of the specified states will be set.
            /// </summary>
            [Obsolete("This value is not supported.")]
            UserPresent = 0x04,

            /// <summary>
            /// Enables away mode. This value must be specified with <see cref="Continuous"/>.
            /// <para />
            /// Away mode should be used only by media-recording and media-distribution applications that must perform critical background processing on desktop computers while the computer appears to be sleeping.
            /// </summary>
            AwaymodeRequired = 0x40,

            /// <summary>
            /// Informs the system that the state being set should remain in effect until the next call that uses <see cref="Continuous"/> and one of the other state flags is cleared.
            /// </summary>
            Continuous = 0x80000000,
        }
    }
}
