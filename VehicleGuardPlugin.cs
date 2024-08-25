using System;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;

namespace SG.VehicleGuard;

public partial class VehicleGuardPlugin : RocketPlugin<VehicleGuardConfiguration>
{
    protected override void Load()
    {
        VehicleManager.onVehicleLockpicked += OnVehicleLockpicked;
        VehicleManager.onVehicleCarjacked += OnVehicleCarjacked;
        VehicleManager.onDamageTireRequested += OnDamageTireRequested;
        
        Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!", ConsoleColor.Yellow);
    }

    protected override void Unload()
    {
        VehicleManager.onVehicleLockpicked -= OnVehicleLockpicked;
        VehicleManager.onVehicleCarjacked -= OnVehicleCarjacked;
        VehicleManager.onDamageTireRequested -= OnDamageTireRequested;
        
        Logger.Log($"{Name} {Assembly.GetName().Version} has been unloaded.", ConsoleColor.Yellow);
    }

    public override TranslationList DefaultTranslations => new()
    {
        { "vehicle_lockpick_denied", "You cannot lockpick this vehicle." },
        { "vehicle_carjack_denied", "You cannot carjack this vehicle." },
        { "vehicle_tire_damage_denied", "You cannot damage this vehicle's tires." }
    };
}