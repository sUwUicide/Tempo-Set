using System;
using System.IO;
using MelonLoader;
using UnityEngine;
using System.Collections;
using RumbleModUI;

namespace Tempo_Set
{
    public static class BuildInfo
    {
        public const string ModName = "TempoSet";
        public const string ModVersion = "1.0.0";
        public const string Description = "Slows Things";
        public const string Author = "sUwUicide";
        public const string Company = "FartsMGee";
    }
    public class Main : MelonMod
    {
        private string currentScene = "Loader";
        private bool sceneChanged = false;
        private bool newFile = false;
        private string FILEPATH = @"UserData\TempoSet";
        private string FILENAME = "Settings.txt";
        private string[] fileContents = new string[1];

        RumbleModUI.UI UI = RumbleModUIClass.UI_Obj;
        Mod Fartsmgee = new Mod();
        ModSetting<float> GameSpeed;
        public override void OnLateInitializeMelon()
        {
        //    MelonCoroutines.Start(CheckIfFileExists(FILEPATH, FILENAME));
            base.OnLateInitializeMelon();
            Fartsmgee.ModName = BuildInfo.ModName;
            Fartsmgee.ModVersion = BuildInfo.ModVersion;
            Fartsmgee.SetFolder("TempoSetUI");
            Fartsmgee.AddToList("Description", ModSetting.AvailableTypes.Description, "", BuildInfo.Description);
           
            GameSpeed = Fartsmgee.AddToList("Game Speed", 1.0f, "Changes the game engine speed where 1 is 100% gamespeed and 0.5 is 50% game speed." + Environment.NewLine +
                "To apply values type the number in the box, press enter then save. WARNING DO NOT set your value as 0, you will have to restart your game if you do.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            currentScene = sceneName;
            sceneChanged = true;
        }

        public override void OnFixedUpdate()
        {
            if(Fartsmgee.GetSaveStatus())
            {
                Fartsmgee.ConfirmSave();
                Time.timeScale = (float)GameSpeed.SavedValue;
            }
            if (UI.GetInit() && !Fartsmgee.GetUIStatus())
                {
                UI.AddMod(Fartsmgee);
                MelonLogger.Msg("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
         if (currentScene != "Gym")
         {
             Time.timeScale = 1f;
         }
        }
    }
}