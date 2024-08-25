namespace SG.VehicleGuard.Models.Configs;

public class CarjackConfig
{
    public bool AllowAnyoneCarjack { get; set; }
    public bool AllowOwnerCarjack { get; set; }
    public bool AllowGroupCarjack { get; set; }
    
    public void LoadDefaults()
    {
        AllowAnyoneCarjack = false;
        AllowOwnerCarjack = true;
        AllowGroupCarjack = true;
    }
}