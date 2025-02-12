﻿using Android.Gms.Location;


namespace Shiny.Locations
{
    static class PlatformExtensions
    {
        public static LocationRequest ToNative(this GpsRequest request)
        {
            var nativeRequest = LocationRequest.Create();
                //.SetInterval(request.Interval.ToMillis());

            switch (request.Accuracy)
            {
                case GpsAccuracy.Lowest:
                    nativeRequest
                        .SetPriority(LocationRequest.PriorityLowPower)
                        .SetSmallestDisplacement(3000);
                    break;

                case GpsAccuracy.Low:
                    nativeRequest
                        .SetPriority(LocationRequest.PriorityLowPower)
                        .SetSmallestDisplacement(1000);
                    break;

                case GpsAccuracy.Normal:
                    nativeRequest
                        .SetPriority(LocationRequest.PriorityBalancedPowerAccuracy)
                        .SetSmallestDisplacement(100);
                    break;

                case GpsAccuracy.High:
                    nativeRequest
                        .SetPriority(LocationRequest.PriorityHighAccuracy)
                        .SetSmallestDisplacement(10);
                    break;

                case GpsAccuracy.Highest:
                    nativeRequest.SetPriority(LocationRequest.PriorityHighAccuracy);

                    break;
            }

            //if (request.ThrottledInterval != null)
            //    nativeRequest.SetFastestInterval(request.ThrottledInterval.Value.ToMillis());

            //if (request.MinimumDistance != null)
            //    nativeRequest.SetSmallestDisplacement((float)request.MinimumDistance.TotalMeters);

            return nativeRequest;
        }


        //internal static long ToMillis(this TimeSpan ts)
        //    => Convert.ToInt64(ts.TotalMilliseconds);


        //internal static long ToMillis(this TimeSpan? ts, long defaultValue)
        //    => Convert.ToInt64(ts?.TotalMilliseconds ?? defaultValue);
    }
}
