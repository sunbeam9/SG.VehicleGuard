namespace SG.VehicleGuard.Models.Configs;

public class TireConfig
{
    public bool AllowTireDamage { get; set; }
    public bool AllowTireDamageWhileDriving { get; set; }
    
    public void LoadDefaults()
    {
        AllowTireDamage = false;
        AllowTireDamageWhileDriving = false;
    }
}