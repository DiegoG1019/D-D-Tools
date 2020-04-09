using System;
using System.Collections.Generic;
using Serilog;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace DnDTDesktop
{
    public sealed class Configurations
    {

        private options opt = options.Instance;
        private system sys = system.Instance;
        private lang lng = lang.Instance;

        public options Options
        {
            get
            {
                return opt;
            }
            set
            {
                opt = value;
            }
        }
        public system System
        {
            get
            {
                return sys;
            }
            set
            {
                sys = value;
            }
        }
        public lang Lang
        {
            get
            {
                return lng;
            }
            set
            {
                lng = value;
            }
        }

        private bool SystemLoaded = false;
        private bool OptionsLoaded = false;
        private bool LangLoaded = false;
        private string systemfile;
        private string optionsfile;
        private string langfile;

        /*------------Class declaration-----------*/
        public class options
        {
            public Dictionary<string, int> EntityValues { get; set; }
            public Dictionary<string, decimal> OtherValues { get; set; }
            public Dictionary<string, string> General { get; set; }

            [IgnoreDataMember]
            private static options instance = null; private static readonly object padlock = new object();
            public options() {}

            [IgnoreDataMember]
            [JsonIgnore]
            public static options Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new options();
                            Log.Verbose("Creating a new instance of {0}", typeof(options));
                        }
                        Log.Verbose("Returning instace of {0}", typeof(options));
                        return instance;
                    }
                }
            }
        }

        public class system
        {
            public Dictionary<string, bool> Flags { get; set; }

            [IgnoreDataMember]
            private static system instance = null; private static readonly object padlock = new object();
            public system() { }

            [IgnoreDataMember]
            [JsonIgnore]
            public static system Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new system(); 
                            Log.Verbose("Creating a new instance of {0}",typeof(system));
                        }
                        Log.Verbose("Returning instace of {0}",typeof(system));
                        return instance;
                    }
                }
            }
        }

        public class lang
        {
            public Dictionary<string, string> Util { get; set; }
            public Dictionary<string, string> Gui { get; set; }
            public Dictionary<string, string> Ent { get; set; }
            public Dictionary<string, string> Items { get; set; }


            [IgnoreDataMember]
            private static lang instance = null; private static readonly object padlock = new object();
            public lang() { }

            [IgnoreDataMember]
            [JsonIgnore]
            public static lang Instance { 
                get 
                { 
                    lock (padlock) 
                    { 
                        if (instance == null) 
                        { 
                            instance = new lang();
                            Log.Verbose("Creating a new instance of {0}", typeof(lang));
                        }
                        Log.Verbose("Returning instace of {0}", typeof(lang));
                        return instance;
                    } 
                } 
            }
        }

        public void LoadSystemOptions()
        {
            systemfile = "System.config";

            System.Flags = new Dictionary<string, bool>();

            if (File.Exists(Path.Combine(App.Directories.Settings, systemfile + SerializeToFile.JsonFileExtension)))
            {
                try
                {
                    Log.Information("Loading System configurations");
                    System = DeserializeFromFile.Json<system>(App.Directories.Settings, systemfile);
                    System.Flags["verbose"] = (System.Flags["debug"] && (System.Flags["verbose"])); //Both need to be true
                }
                catch (JsonException)
                {
                    Log.Information("System configurations file is corrupted");
                    CreateSystemOptions();
                }
            }
            else
            {
                Log.Information("System configurations file does not exist");
                CreateSystemOptions();
            }
            SystemLoaded = true;
            Log.Information("Loaded System configurations");
        }
        private void CreateSystemOptions()
        {
            Log.Information("Creating a new System configurations file with default values");
            System.Flags.Add("console", false);
            System.Flags.Add("debug", false);
            System.Flags.Add("verbose", System.Flags["debug"] && (false)); //Both need to be true
        }

        public void SaveSystemOptions()
        {
            if (!SystemLoaded)
            {
                throw new InvalidOperationException("Attempted to save System Configurations to a file before loading them");
            }
            Log.Information("Saving System configurations to file");
            SerializeToFile.Json<system>(System, App.Directories.Settings, systemfile);
        }

        public void LoadLang()
        {
            langfile = Options.General["language"] + ".lang";

            Lang.Util = new Dictionary<string, string>();
            Lang.Gui = new Dictionary<string, string>();
            Lang.Ent = new Dictionary<string, string>();
            Lang.Items = new Dictionary<string, string>();

            if (File.Exists(Path.Combine(App.Directories.Settings, langfile + SerializeToFile.JsonFileExtension)))
            {
                try
                {
                    Log.Information("Loading Set Language");
                    Lang = DeserializeFromFile.Json<lang>(App.Directories.Settings, langfile);
                }
                catch (JsonException)
                {
                    Log.Information("Set Language file is corrupted");
                    CreateLang();
                }
            }
            else
            {
                Log.Information("Set Language file does not exist");
                CreateLang();
            }

            LangLoaded = true;
            Log.Information("Loaded Language Data");
        }

        private void CreateLang()
        {
            Log.Information("Using default language settings");
            Lang.Util.Add("currency", "P.");
            Lang.Ent.Add("noRequirements", "Nothing");
            SerializeToFile.Json<lang>(Lang, App.Directories.Settings, langfile);
        }

        public void LoadOptions()
        {
            optionsfile = "Configurations.config";

            Options.EntityValues = new Dictionary<string, int>();
            Options.General = new Dictionary<string, string>();

            if (File.Exists(Path.Combine(App.Directories.Settings, optionsfile + SerializeToFile.JsonFileExtension)))
            {
                try
                {
                    Log.Information("Loading Configurations");
                    Options = DeserializeFromFile.Json<options>(App.Directories.Settings, optionsfile);
                }
                catch (JsonException)
                {
                    Log.Information("Configurations file is corrupted");
                    CreateOptions();
                }
            }
            else
            {
                Log.Information("Configurations file does not exist");
                CreateOptions();
            }

            OptionsLoaded = true;
            Log.Information("Loaded Configurations");
        }

        private void CreateOptions()
        {
            Log.Information("Creating new Configurations file with default values");
            Options.EntityValues.Add("dead", -10);
            Options.EntityValues.Add("bleedingOut", -1);
            Options.EntityValues.Add("down", 0);
            Options.EntityValues.Add("maxSpellLevel", 9);
            Options.General.Add("language", "eng");
            Options.OtherValues.Add("coinWeight", 0.02M);
            Options.OtherValues.Add("squareSize", 5M);
        }

        public void SaveOptions()
        {
            if (!OptionsLoaded)
            {
                throw new InvalidOperationException("Attempted to save configurations to a file before loading them");
            }
            Log.Information("Saving configurations to file");
            SerializeToFile.Json<options>(Options, App.Directories.Settings, optionsfile);
        }

        /*------------Singleton class stuff-----------*/
        private static Configurations instance = null;
        private static readonly object padlock = new object();

        Configurations()
        {
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public static Configurations Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configurations();
                        Log.Debug("Creating a new instance of Configurations");
                    }
                    Log.Debug("Returning instace of Configurations");
                    return instance;
                }
            }
        }
    }
}
