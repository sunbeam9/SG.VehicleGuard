using Rocket.API;
using SDG.Unturned;
using SG.VehicleGuard.Models.Configs;

namespace SG.VehicleGuard;

public class VehicleGuardConfiguration : IRocketPluginConfiguration
{
    public bool IgnoreAdmins { get; set; }
    public LockpickConfig LockpickConfig { get; set; }
    public CarjackConfig CarjackConfig { get; set; }
    public TireConfig TireConfig { get; set; }

    public void LoadDefaults()
    {
        IgnoreAdmins = true;
        LockpickConfig = new LockpickConfig();
        CarjackConfig = new CarjackConfig();
        TireConfig = new TireConfig();

        LockpickConfig.LoadDefaults();
        CarjackConfig.LoadDefaults();
        TireConfig.LoadDefaults();
    }
}