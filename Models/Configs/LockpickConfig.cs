namespace SG.VehicleGuard.Models.Configs;

public class LockpickConfig
{
    public bool AllowLockpick { get; set; }
    
    public void LoadDefaults()
    {
        AllowLockpick = false;
    }
}