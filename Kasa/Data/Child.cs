using System;
using Newtonsoft.Json;

namespace Kasa;

// /// <summary>
// /// A capability of a Kasa device. These will vary by model, for example the EP10 has a timer but no energy meter, while the KP115 has both.
// /// </summary>
// public enum Feature {

//     /// <summary>
//     /// <para>The ability to perform scheduled actions, like turning off the outlet after 10 minutes.</para>
//     /// <para>All outlets have this feature.</para>
//     /// </summary>
//     Timer,

//     /// <summary>
//     /// <para>The ability to measure how much electricity has been used by whatever is plugged into the Kasa outlet.</para>
//     /// <para>Only certain outlets have this feature, such as KP125, KP115, HS300, and HS110.</para>
//     /// </summary>
//     EnergyMeter

// }

public struct Child {
    [JsonProperty("id")] public string id { get; set; }  //  "800671BEB946D3C691ECBD2940991375202E165600",
    [JsonProperty("state")] public string state { get; set; }  //  1,
    [JsonProperty("alias")] public string alias { get; set; }  //  "Outside Plug 1",
    [JsonProperty("on_time")] public string on_time { get; set; }  //  1882,

    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Feature FromJsonString(string jsonString) => jsonString.ToUpperInvariant() switch {
        "TIM" => Feature.Timer,
        "ENE" => Feature.EnergyMeter,
        _     => throw new ArgumentOutOfRangeException(nameof(jsonString), jsonString, "Unknown feature")
    };

}