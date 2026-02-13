using MelonLoader;
using UnityEngine;

namespace ExampleMod
{
    public class ExampleMod : MelonMod
    {
        internal static ExampleMod instance;

#if DEBUG
        internal static bool DEBUG { get { return Settings.debug.Value; } }
#else
        internal const bool DEBUG = false;
#endif

        internal static MelonLogger.Instance Log => instance.LoggerInstance;

        public override void OnInitializeMelon()
        {
            instance = this;

            // Register the settings
            Settings.Register();

#if DEBUG
            NeonLite.Modules.Anticheat.Register(MelonAssembly);
#endif
            // Load all modules tagged with the IModule interface
            NeonLite.NeonLite.LoadModules(MelonAssembly);
        }

        // Some mods will need a GameObject to rely on: configure it here.
        internal static GameObject holder;
        public override void OnLateInitializeMelon()
        {

            holder = new GameObject("ExampleMod");
            GameObject.DontDestroyOnLoad(holder);
        }


        internal static class Settings
        {
            public const string h = "ExampleMod";

            // Put all your global settings here
#if DEBUG
            public static MelonPreferences_Entry<bool> debug;
#endif

            public static void Register()
            {
                NeonLite.Settings.AddHolder(h);

#if DEBUG
                debug = NeonLite.Settings.Add(h, "", "debug", "Debug Mode", null, false, true);
#endif
            }
        }
    }
}
