﻿using System;
using Shiny.Locations;


namespace Shiny
{
    public sealed class Distance : IEquatable<Distance>
    {
        public const double MILES_TO_KM = 1.60934;
        public const double KM_TO_MILES = 0.621371;
        public const int KM_TO_METERS = 1000;


        Distance() { }
        public Distance(double totalKilometers)
        {
            this.TotalKilometers = totalKilometers;
        }

        public double TotalMiles => this.TotalKilometers * KM_TO_MILES;
        public double TotalMeters => this.TotalKilometers * KM_TO_METERS;
        public double TotalKilometers { get; set; }


        public static Distance Between(Position one, Position two)
        {
            var d1 = one.Latitude * (Math.PI / 180.0);
            var num1 = one.Longitude * (Math.PI / 180.0);
            var d2 = two.Latitude * (Math.PI / 180.0);
            var num2 = two.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            var meters = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
            return Distance.FromMeters(meters);
        }


        public override string ToString() => $"[Distance: {this.TotalKilometers} km]";
        public bool Equals(Distance other) => (this.TotalKilometers) == (other?.TotalKilometers);
        public override bool Equals(object obj) => obj is Distance distance && this.Equals(distance);
        public override int GetHashCode() => (this.TotalKilometers).GetHashCode();

        public static bool operator ==(Distance left, Distance right) => Equals(left, right);
        public static bool operator !=(Distance left, Distance right) => !Equals(left, right);
        public static bool operator >(Distance x, Distance y) => x.TotalKilometers > y.TotalKilometers;
        public static bool operator <(Distance x, Distance y) => x.TotalKilometers < y.TotalKilometers;
        public static bool operator >=(Distance x, Distance y) => x.TotalKilometers >= y.TotalKilometers;
        public static bool operator <=(Distance x, Distance y) => x.TotalKilometers <= y.TotalKilometers;


        public static Distance FromMiles(int miles) => new Distance
        {
            TotalKilometers = miles * MILES_TO_KM
        };
        public static Distance FromMiles(double miles) => new Distance
        {
            TotalKilometers = miles * MILES_TO_KM
        };
        public static Distance FromMeters(double meters) => new Distance
        {
            TotalKilometers = meters / KM_TO_METERS
        };
        public static Distance FromKilometers(double km) => new Distance
        {
            TotalKilometers = km
        };
    }
}
