using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StreamProgressInfo
{
    interface IStreamable
    {
        int Length { get; set; }
        int BytesSent { get; set; }
    }
}
