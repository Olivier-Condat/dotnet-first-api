// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace dotnetfirstapi.Function.Models
{
    /// <summary> The Sensordata. </summary>
    public partial class Sensordata
    {
        /// <summary> Initializes a new instance of Sensordata. </summary>
        /// <param name="temperature"> . </param>
        /// <param name="humidity"> . </param>
        public Sensordata(float temperature, float humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }

        public float Temperature { get; }
        public float Humidity { get; }
    }
}