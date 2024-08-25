using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace SG.VehicleGuard;

public partial class VehicleGuardPlugin
{
    private void OnVehicleLockpicked(InteractableVehicle vehicle, Player player, ref bool allow)
    {
        if (Configuration.Instance.LockpickConfig.AllowLockpick ||
            (player.channel.owner.isAdmin && Configuration.Instance.IgnoreAdmins)) return;

        allow = false;
        Say(player, "vehicle_lockpick_denied");
    }

    private void OnVehicleCarjacked(InteractableVehicle vehicle, Player player, ref bool allow, ref Vector3 force,
        ref Vector3 torque)
    {
        if (Configuration.Instance.CarjackConfig.AllowAnyoneCarjack ||
            (player.channel.owner.isAdmin && Configuration.Instance.IgnoreAdmins) ||
            !vehicle.isLocked) return;

        if (Configuration.Instance.CarjackConfig.AllowOwnerCarjack &&
            vehicle.lockedOwner == player.channel.owner.playerID.steamID) return;
        
        if (Configuration.Instance.CarjackConfig.AllowGroupCarjack &&
            vehicle.lockedGroup == player.quests.groupID) return;

        allow = false;
        Say(player, "vehicle_carjack_denied");
    }

    private void OnDamageTireRequested(CSteamID steamId, InteractableVehicle vehicle, int tireIndex,
        ref bool shouldAllow, EDamageOrigin damageOrigin)
    {
        var player = PlayerTool.getPlayer(steamId);
        
        if (Configuration.Instance.TireConfig.AllowTireDamage ||
            (player.channel.owner.isAdmin && Configuration.Instance.IgnoreAdmins) ||
            !vehicle.isLocked) return;
        
        if (Configuration.Instance.TireConfig.AllowTireDamageWhileDriving && vehicle.isDriven) return;

        shouldAllow = false;
        Say(player, "vehicle_tire_damage_denied");
    }

    private void Say(Player player, string translationKey)
    {
        var text = Translate(translationKey);
        var toPlayer = player.channel.owner;
        ChatManager.serverSendMessage(text, Color.red, null, toPlayer, EChatMode.SAY, null, true);
    }
}