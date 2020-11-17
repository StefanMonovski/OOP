using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StreamProgressInfo
{
    class StreamProgressInfo
    {
        private IStreamable stream;

        public StreamProgressInfo(IStreamable stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return stream.BytesSent * 100 / stream.Length;
        }
    }
}
