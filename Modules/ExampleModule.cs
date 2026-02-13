namespace ExampleMod.Modules
{
    // This is an example template module that does nothing but print things to log every few seconds.
    // Check NeonLite/Modules/IModule.cs for more information.
    // Make sure to remove the wrapped #if false when you copy this!
#if false
    internal class ExampleModule : MonoBehaviour, IModule
    {
        // A "true" priority means it'll start before the low priority mods (before the main menu loads.)
        // This uses a holder, so Activate gets called later.
        const bool priority = false;
        static bool active = false;

        // This will be called once at the start of the game.
        // All mods will be setup at the same time, no matter their priority.
        static void Setup()
        {
            ExampleMod.Log.Msg("ExampleModule Setup!");
            // This is how you would create a toggle setting using the Settings framework.
            // An empty string as the first argument means it goes into the main category.
            var setting = Settings.Add(ExampleMod.Settings.h, "", "exampleMod", "Example Module Toggle", "This is a hidden toggle for the example module.", true);
            setting.IsHidden = true; //! REMOVE ME!
            active = setting.SetupForModule(Activate, static (_, after) => after);
        }

        static ExampleModule instance;

        // Activate will be called either at the start of the game or on mod menu setup depending on the priority.
        // It may be called because of a setting, passed with a bool that says whether or not to activate it.
        // Here is where you should handle (un)patching using Patching.TogglePatch and component addition and destruction.
        static void Activate(bool activate)
        {
            ExampleMod.Log.Msg($"ExampleModule Activate {activate}!");
            if (activate)
                instance = ExampleMod.holder.AddComponent<ExampleModule>();
            else if (!instance)
                ExampleMod.Log.Warning("ExampleModule was told to deactivate but it hasn't been activated!");
            else
                Destroy(instance);

            active = activate;
        }

        // This will print the level when the level finishes loading, but not before the staging screen finishes.
        static void OnLevelLoad(LevelData level)
        {
            // level will be null if we're loading the menu!
            const string m = "Menu";
            ExampleMod.Log.Msg($"ExampleModule OnLevelLoad {level?.levelID ?? m}!");
        }

        float printTimer = 0;
        void Update()
        {
            printTimer -= Time.unscaledDeltaTime;
            if (printTimer <= 0)
            {
                ExampleMod.Log.Msg("ExampleModule tick!");
                printTimer = 10;
            }
        }
    }
#endif
}
