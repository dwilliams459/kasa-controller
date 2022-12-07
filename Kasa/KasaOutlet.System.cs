using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Kasa;

public partial class KasaOutlet {

    /// <inheritdoc />
    public IKasaOutlet.ISystemCommands System => this;

    /// <inheritdoc />
    async Task<bool> IKasaOutlet.ISystemCommands.IsOutletOn() {
        SystemInfo systemInfo = await ((IKasaOutlet.ISystemCommands) this).GetInfo().ConfigureAwait(false);
        return systemInfo.IsOutletOn;
    }

    /// <inheritdoc />
    Task IKasaOutlet.ISystemCommands.SetOutletOn(bool turnOn) {
        return _client.Send<JObject>(CommandFamily.System, "set_relay_state", new { state = Convert.ToInt32(turnOn) });
    }

    /// <inheritdoc />
    Task IKasaOutlet.ISystemCommands.SetChildOutletOn(bool turnOn, string child_id) {
        // https://community.home-assistant.io/t/tp-link-kasa-kp400-2-outlet-support/113135/9
        // In order to support multiple outlets, a context must be added:

        // {"system":{"set_relay_state":{"state":0}},"context":{"child_ids":["000000000000000000000000"]}}
        // The child_id can be found by looking at the results of the get_sysinfo command. Multiple child_ids can be sent, so for the HS300 with 6 outlets you could turn on up to all 6 at once.

        // return _client.Send<JObject>(CommandFamily.System, 
        //     "set_relay_state", new { state = Convert.ToInt32(turnOn) },
        //     "context", new { child_ids = new string[] {"asdf", "asdf"}}
        // );
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    Task<SystemInfo> IKasaOutlet.ISystemCommands.GetInfo() {
        return _client.Send<SystemInfo>(CommandFamily.System, "get_sysinfo");
    }

    /// <inheritdoc />
    async Task<bool> IKasaOutlet.ISystemCommands.IsIndicatorLightOn() {
        SystemInfo systemInfo = await ((IKasaOutlet.ISystemCommands) this).GetInfo().ConfigureAwait(false);
        return !systemInfo.IndicatorLightDisabled;
    }

    /// <inheritdoc />
    Task IKasaOutlet.ISystemCommands.SetIndicatorLightOn(bool turnOn) {
        return _client.Send<JObject>(CommandFamily.System, "set_led_off", new { off = Convert.ToInt32(!turnOn) });
    }

    /// <inheritdoc />
    Task IKasaOutlet.ISystemCommands.Reboot(TimeSpan afterDelay) {
        return _client.Send<JObject>(CommandFamily.System, "reboot", new { delay = (int) afterDelay.TotalSeconds });
    }

    /// <inheritdoc />
    async Task<string> IKasaOutlet.ISystemCommands.GetName() {
        SystemInfo systemInfo = await ((IKasaOutlet.ISystemCommands) this).GetInfo().ConfigureAwait(false);
        return systemInfo.Name;
    }

    /// <inheritdoc />
    Task IKasaOutlet.ISystemCommands.SetName(string name) {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 31) {
            throw new ArgumentOutOfRangeException(nameof(name), name, "name must be between 1 and 31 characters long (inclusive), and cannot be only whitespace");
        }

        return _client.Send<JObject>(CommandFamily.System, "set_dev_alias", new { alias = name });
    }

}