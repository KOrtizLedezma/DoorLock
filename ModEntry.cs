using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System.Collections.Generic;
using System.Linq;

namespace DoorLock
{
    public class ModEntry : Mod
    {
        private Dictionary<string, long> ResolvedAssignments = new();

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
            helper.Events.Player.Warped += OnWarped;
        }

        private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
        {
            ResolvedAssignments.Clear();

            foreach (var location in Game1.locations)
            {
                if (location is StardewValley.Locations.Cabin cabin)
                {
                    var owner = Game1.getAllFarmers().FirstOrDefault(farmer =>
                        farmer != Game1.MasterPlayer && farmer.homeLocation.Value == cabin.NameOrUniqueName);

                    if (owner != null)
                    {
                        ResolvedAssignments[cabin.NameOrUniqueName] = owner.UniqueMultiplayerID;
                        Monitor.Log($"[Auto] Assigned {cabin.NameOrUniqueName} to {owner.Name} (ID: {owner.UniqueMultiplayerID})", LogLevel.Info);
                    }
                    else
                    {
                        Monitor.Log($"[Auto] No player assigned to cabin {cabin.NameOrUniqueName} yet", LogLevel.Debug);
                    }
                }
            }

            ResolvedAssignments["FarmHouse"] = Game1.MasterPlayer.UniqueMultiplayerID;
            Monitor.Log($"[Auto] Assigned FarmHouse to {Game1.MasterPlayer.Name} (ID: {Game1.MasterPlayer.UniqueMultiplayerID})", LogLevel.Info);
        }

        private void OnWarped(object? sender, WarpedEventArgs e)
        {
            string locationName = e.NewLocation.Name;
            if (ResolvedAssignments.TryGetValue(locationName, out var allowedId))
            {
                if (e.Player.UniqueMultiplayerID != allowedId)
                {
                    Game1.showRedMessage("You're not allowed in this house!");
                    int farmX = 48;
                    int farmY = 7;

                    Game1.warpFarmer("Farm", farmX, farmY, false);

                    Monitor.Log($"[Block] {e.Player.Name} was denied access to {locationName} and sent to the Farm.", LogLevel.Info);
                }
            }
        }
    }
}