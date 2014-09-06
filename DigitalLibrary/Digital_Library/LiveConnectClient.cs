using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digital_Library
{
    class LiveConnectClient
    {
        private object p;

        public LiveConnectClient(object p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        internal System.Threading.Tasks.Task<LiveOperationResult> GetAsync(string p)
        {
            throw new NotImplementedException();
        }
    }
}
