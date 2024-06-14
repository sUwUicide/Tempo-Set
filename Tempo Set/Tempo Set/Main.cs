using System;
using MelonLoader;
using UnityEngine;
using RumbleModUI;
using RUMBLE.Environment;
using RumbleModdingAPI;

namespace Tempo_Set
{
    public static class BuildInfo
    {
        // Mod information constants
        public const string ModName = "TempoSet";
        public const string ModVersion = "1.2.0";
        public const string Description = "Slows Things";
        public const string Author = "sUwUicide";
        public const string Company = "FartsMGee";
    }
    public class Main : MelonMod
    {
        // Variables for scene and file management
        private string currentScene = "Loader";
        

        // UI and mod objects
        Mod Fartsmgee = new Mod();
        ModSetting<float> GameSpeed;
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Update current scene
            currentScene = sceneName;
            Time.timeScale = 1f;
        }
        public void onnut()
        {
            // Initialize mod information
            Fartsmgee.ModName = BuildInfo.ModName;
            Fartsmgee.ModVersion = BuildInfo.ModVersion;
            Fartsmgee.SetFolder("TempoSetUI");
            // Add game speed setting to mod UI

            GameSpeed = Fartsmgee.AddToList("Game Speed", 1.0f, "Changes the game engine speed where 1 is 100% gamespeed and 0.5 is 50% game speed." + Environment.NewLine +
                "To apply values type the number in the box, press enter then save. WARNING DO NOT set your value as 0, you will have to restart your game if you do.",new Tags());
            Fartsmgee.ModSaved += hasnut;
            UI.instance.AddMod(Fartsmgee);
            MelonLogger.Msg("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
        public void hasnut()
        {
            // Checks if in scene or park or else it returns
            if ((currentScene != "Gym") && (currentScene != "Park"))
            {
                return;
            }
            // Apply saved game speed if available
            if ((currentScene == "Park") && (Calls.GameObjects.Park.Logic.HeinhouserProducts.Parkboard.GetGameObject().GetComponent<ParkBoardParkVariant>().currentParkDoorPolicyImage.sprite.name != "Closed_Park_Icon"))
            {
                return;
            }
            Time.timeScale = (float)GameSpeed.SavedValue;
        }
        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
            UI.instance.UI_Initialized += onnut;
        }
    }
}