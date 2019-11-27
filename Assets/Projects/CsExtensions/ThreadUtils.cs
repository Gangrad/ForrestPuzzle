using System.Threading;

namespace CsExtensions {
    public static class ThreadUtils {
        public static void SafeStartThread(ref Thread thread, ThreadStart action) {
            if (thread == null)
                thread = new Thread(action);
            thread.Start();
        }
        
        public static void SafeAbortAndRemove(ref Thread thread) {
            if (thread == null)
                return;
            
            thread.Abort();
            thread = null;
        }
    }
}