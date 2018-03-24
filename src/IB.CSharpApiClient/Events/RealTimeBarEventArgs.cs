﻿using System;
using IBApi;

namespace IB.CSharpApiClient.Events
{
    public class RealTimeBarEventArgs : HistoricalDataEventArgs
    {
        public long LongVolume { get; private set; }

        public long Timestamp { get; private set; }

        public RealTimeBarEventArgs(int reqId, long date, double open, double high, double low, double close, long volume, double WAP, int count)
            : base(reqId, new Bar(UnixTimestampToDateTime(date).ToString("yyyyMMdd hh:mm:ss"), open, high, low, close, -1, count, WAP))
        {
            Timestamp = date;
            LongVolume = volume;
        }

        static DateTime UnixTimestampToDateTime(long unixTimestamp)
        {
            DateTime unixBaseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return unixBaseTime.AddSeconds(unixTimestamp);
        }
    }
}