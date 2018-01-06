using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using MahApps.Metro;
using System.IO;
using MahApps.Metro.Controls.Dialogs;
using System.ComponentModel;
using System.Diagnostics;

namespace RBXLegacyLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        HelperStructs.DiscordRpc.EventHandlers handlers;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        //launcher crap

        public void ReadyCallback()
        {
            ConsolePrint("Discord RPC: Ready");
        }

        public void DisconnectedCallback(int errorCode, string message)
        {
            ConsolePrint("Discord RPC: Disconnected. Reason " + errorCode + ": " + message);
        }

        public void ErrorCallback(int errorCode, string message)
        {
            ConsolePrint("Discord RPC: Error. Reason " + errorCode + ": " + message);
        }

        public void JoinCallback(string secret)
        {
        }

        public void SpectateCallback(string secret)
        {
        }

        public void RequestCallback(HelperStructs.DiscordRpc.JoinRequest request)
        {
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HelperStructs.LauncherFuncs.ReadInfoValues(HelperStructs.GlobalVars.LauncherInfoFile);

            ConsolePrint("RBXLegacy version " + HelperStructs.GlobalVars.LauncherInfo.Version + " loaded.");

            if (!Directory.Exists(HelperStructs.GlobalVars.ClientFolder))
            {
                Directory.CreateDirectory(HelperStructs.GlobalVars.ClientFolder);
            }

            if (!Directory.Exists(HelperStructs.GlobalVars.MapFolder))
            {
                Directory.CreateDirectory(HelperStructs.GlobalVars.MapFolder);
            }

            if (!Directory.Exists(HelperStructs.GlobalVars.DataFolder))
            {
                Directory.CreateDirectory(HelperStructs.GlobalVars.DataFolder);
            }

            if (File.Exists(HelperStructs.GlobalVars.ChangelogFile))
            {
                Changelog.AppendText(File.ReadAllText(HelperStructs.GlobalVars.ChangelogFile), "White");
            }
            else
            {
                ConsolePrint("Error - " + HelperStructs.GlobalVars.ChangelogFile + " not found.");
            }

            if (!File.Exists(HelperStructs.GlobalVars.LauncherConfigFile))
            {
                ConsolePrint("Warning - " + HelperStructs.GlobalVars.LauncherConfigFile + " not found. Creating one with default values.");
                HelperStructs.LauncherFuncs.ResetConfigValues();
                WriteConfigValues();
                ReadConfigValues();
            }
            else
            {
                ReadConfigValues();
            }

            if (!File.Exists(HelperStructs.GlobalVars.ServerListFile))
            {
                ConsolePrint("Warning - " + HelperStructs.GlobalVars.ServerListFile + " not found. Creating empty file.");
                File.Create(HelperStructs.GlobalVars.ServerListFile).Dispose();
            }

            //init discord rpc

            handlers = new HelperStructs.DiscordRpc.EventHandlers();
            handlers.readyCallback = ReadyCallback;
            handlers.disconnectedCallback += DisconnectedCallback;
            handlers.errorCallback += ErrorCallback;
            handlers.joinCallback += JoinCallback;
            handlers.spectateCallback += SpectateCallback;
            handlers.requestCallback += RequestCallback;
            HelperStructs.DiscordRpc.Initialize(HelperStructs.GlobalVars.appid, ref handlers, true, "");

            try
            {
                await Task.Run(() =>
                {
                    for (;;)
                    {
                        HelperStructs.DiscordRpc.RunCallbacks();
                    }
                });
            }
            catch (Exception)
            {
            }

            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In Launcher";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            WriteConfigValues();
            HelperStructs.DiscordRpc.Shutdown();
        }

        void ReadConfigValues()
        {
            HelperStructs.LauncherFuncs.ReadConfigValues(HelperStructs.GlobalVars.LauncherConfigFile);

            if (HelperStructs.GlobalVars.LauncherConfig.Theme == true)
            {
                DarkTheme.IsChecked = true;
            }
            else if (HelperStructs.GlobalVars.LauncherConfig.Theme == false)
            {
                DarkTheme.IsChecked = false;
            }

            if (HelperStructs.GlobalVars.LauncherConfig.PlayerID <= 0)
            {
                HelperStructs.GlobalVars.LauncherConfig.PlayerID = HelperStructs.LauncherFuncs.GeneratePlayerID();
                IDBox.Text = HelperStructs.GlobalVars.LauncherConfig.PlayerID.ToString();
                WriteConfigValues();
            }
            else
            {
                IDBox.Text = HelperStructs.GlobalVars.LauncherConfig.PlayerID.ToString();
            }

            NameBox.AppendText(HelperStructs.GlobalVars.LauncherConfig.PlayerName);
            CurrentClient.Content = HelperStructs.GlobalVars.LauncherConfig.SelectedClient;
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(HelperStructs.GlobalVars.LauncherConfig.Scheme), ThemeManager.GetAppTheme(HelperStructs.GlobalVars.LauncherConfig.Theme ? "basedark" : "baselight"));
            ConsolePrint("Configuration has been loaded.");
            LoadClients();
        }

        void WriteConfigValues()
        {
            HelperStructs.LauncherFuncs.WriteConfigValues(HelperStructs.GlobalVars.LauncherConfigFile);
            ConsolePrint("Configuration has been saved successfully.");
        }

        void LoadClients()
        {
            HelperStructs.LauncherFuncs.ReadClientNames();
            ClientBox.Items.Clear();
            HelperStructs.ClientDef[] Dirs = HelperStructs.GlobalVars.AvailableClients.ToArray();

            foreach (HelperStructs.ClientDef dir in Dirs)
            {
                ClientBox.Items.Add(dir.Name);
            }

            ClientBox.SelectedItem = HelperStructs.GlobalVars.LauncherConfig.SelectedClient;
            LoadMaps();
        }

        void LoadMaps()
        {
            MapList.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(HelperStructs.GlobalVars.MapFolder);
            FileInfo[] Files = dinfo.GetFiles("*.rbxl");
            foreach (FileInfo file in Files)
            {
                MapList.Items.Add(file.Name);
            }

            MapList.SelectedItem = HelperStructs.GlobalVars.SelectedMap;
        }

        async void ReadClientValues(string ClientName)
        {
            try
            {
                string clientpath = HelperStructs.GlobalVars.ClientFolder + "/" + ClientName + '/' + HelperStructs.GlobalVars.ClientInfoFile;

                if (!File.Exists(clientpath))
                {
                    ConsolePrint("Error - " + clientpath + " not detected with '" + ClientBox.SelectedItem + "'. '" + ClientBox.SelectedItem + "' either cannot be loaded, or it is not available.");
                    await this.ShowMessageAsync("Error", "No clientinfo file detected with '" + ClientBox.SelectedItem + "'. '" + ClientBox.SelectedItem + "' either cannot be loaded, or it is not available.");
                    HelperStructs.GlobalVars.LauncherConfig.SelectedClient = HelperStructs.GlobalVars.LauncherInfo.DefaultSelectedClient;
                }

                HelperStructs.LauncherFuncs.ReadClientValues(clientpath);
                ClientDescription.Document.Blocks.Clear();
                ClientDescription.AppendText(HelperStructs.GlobalVars.SelectedClient.Desc, "White");
                HelperStructs.GlobalVars.LauncherConfig.SelectedClient = ClientBox.SelectedItem.ToString();
                CurrentClient.Content = HelperStructs.GlobalVars.LauncherConfig.SelectedClient;
                ConsolePrint("Client '" + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + "' successfully loaded.");
            }
            catch(Exception)
            {
                ConsolePrint("Error - '" + ClientBox.SelectedItem + "' cannot be loaded.");
                await this.ShowMessageAsync("Error", "'" + ClientBox.SelectedItem + "' cannot be loaded.");
                HelperStructs.GlobalVars.LauncherConfig.SelectedClient = HelperStructs.GlobalVars.LauncherInfo.DefaultSelectedClient;
            }
        }

        //flyout events

        void OpenConsole(object sender, RoutedEventArgs e)
        {
            if (ConsoleFlyout.IsOpen == true)
            {
                ConsoleFlyout.IsOpen = false;
            }
            else
            {
                ConsoleFlyout.IsOpen = true;
                JoinServerFlyout.IsOpen = false;
                PlaySoloFlyout.IsOpen = false;
                ClientsFlyout.IsOpen = false;
                OptionsFlyout.IsOpen = false;
                ChangelogFlyout.IsOpen = false;
            }
        }

        void OpenJoinServer(object sender, RoutedEventArgs e)
        {
            if (JoinServerFlyout.IsOpen == true)
            {
                JoinServerFlyout.IsOpen = false;
            }
            else
            {
                JoinServerFlyout.IsOpen = true;
                ConsoleFlyout.IsOpen = false;
                PlaySoloFlyout.IsOpen = false;
                ClientsFlyout.IsOpen = false;
                OptionsFlyout.IsOpen = false;
                ChangelogFlyout.IsOpen = false;
            }
        }

        void OpenPlaySolo(object sender, RoutedEventArgs e)
        {
            if (PlaySoloFlyout.IsOpen == true)
            {
                PlaySoloFlyout.IsOpen = false;
            }
            else
            {
                PlaySoloFlyout.IsOpen = true;
                JoinServerFlyout.IsOpen = false;
                ConsoleFlyout.IsOpen = false;
                ClientsFlyout.IsOpen = false;
                OptionsFlyout.IsOpen = false;
                ChangelogFlyout.IsOpen = false;
            }
        }

        void OpenClients(object sender, RoutedEventArgs e)
        {
            if (ClientsFlyout.IsOpen == true)
            {
                ClientsFlyout.IsOpen = false;
            }
            else
            {
                ClientsFlyout.IsOpen = true;
                PlaySoloFlyout.IsOpen = false;
                JoinServerFlyout.IsOpen = false;
                ConsoleFlyout.IsOpen = false;
                OptionsFlyout.IsOpen = false;
                ChangelogFlyout.IsOpen = false;
            }
        }

        void OpenOptions(object sender, RoutedEventArgs e)
        {
            if (OptionsFlyout.IsOpen == true)
            {
                OptionsFlyout.IsOpen = false;
            }
            else
            {
                OptionsFlyout.IsOpen = true;
                ClientsFlyout.IsOpen = false;
                PlaySoloFlyout.IsOpen = false;
                JoinServerFlyout.IsOpen = false;
                ConsoleFlyout.IsOpen = false;
                ChangelogFlyout.IsOpen = false;
            }
        }

        void OpenChangelog(object sender, RoutedEventArgs e)
        {
            if (ChangelogFlyout.IsOpen == true)
            {
                ChangelogFlyout.IsOpen = false;
            }
            else
            {
                ChangelogFlyout.IsOpen = true;
                OptionsFlyout.IsOpen = false;
                ClientsFlyout.IsOpen = false;
                PlaySoloFlyout.IsOpen = false;
                JoinServerFlyout.IsOpen = false;
                ConsoleFlyout.IsOpen = false;
            }
        }

        //element events

        void Color_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }

            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(ColorBox.SelectedValue.ToString()), ThemeManager.GetAppTheme(HelperStructs.GlobalVars.LauncherConfig.Theme ? "basedark" : "baselight"));
            HelperStructs.GlobalVars.LauncherConfig.Scheme = ColorBox.SelectedValue.ToString();
        }

        void RandomizeID_Click(object sender, RoutedEventArgs e)
        {
            HelperStructs.GlobalVars.LauncherConfig.PlayerID = HelperStructs.LauncherFuncs.GeneratePlayerID();
            IDBox.Text = HelperStructs.GlobalVars.LauncherConfig.PlayerID.ToString();
        }

        async void SaveConfig_Click(object sender, RoutedEventArgs e)
        {
            WriteConfigValues();
            await this.ShowMessageAsync("Information", "Configuration Saved");
        }

        async void ResetConfig_Click(object sender, RoutedEventArgs e)
        {
            HelperStructs.LauncherFuncs.ResetConfigValues();
            WriteConfigValues();
            ReadConfigValues();
            ConsolePrint("Configuration has been reset.");
            await this.ShowMessageAsync("Information", "Configuration Reset");
        }

        async void JoinServer_Click(object sender, RoutedEventArgs e)
        {
            string[] result = ServerBox.Text.Split('|');

            if (result == null)
            {
                await this.ShowMessageAsync("Error", "Please place in a valid IP address i.e. 192.168.1.1|53640");
                return;
            }

            string IP = result[0];
            string Port = result[1];
            HelperStructs.JoinSettings joinServer = new HelperStructs.JoinSettings(IP, Convert.ToInt32(Port));
            HelperStructs.GlobalVars.ServerToJoin = joinServer;

            HelperStructs.ScriptType type = HelperStructs.ScriptType.Join;
            HelperStructs.ScriptGenerator.GenerateScriptForClient(type);

            string rbxexe = "";
            if (HelperStructs.GlobalVars.SelectedClient.LegacyMode)
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxLegacyExeFile;
            }
            else
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxClientExeFile;
            }
            string quote = "\"";
            string args = "-script " + quote + HelperStructs.ScriptGenerator.GetScriptNameForType(type) + quote;

            string argsConverted = args.Replace("/", "//");

            try
            {
                ConsolePrint("Client Loaded.");
                if (HelperStructs.SecurityFuncs.checkfileMD5(rbxexe, HelperStructs.GlobalVars.SelectedClient.MD5))
                {
                    Process client = new Process();
                    client.StartInfo.FileName = rbxexe;
                    client.StartInfo.Arguments = argsConverted;
                    client.EnableRaisingEvents = true;
                    client.Exited += new EventHandler(ClientExited);
                    client.Start();
                }
            }
            catch (Exception)
            {
                ConsolePrint("Error - Failed to launch RBXLegacy. (The client has been detected as modified.)");
                await this.ShowMessageAsync("Error", "Failed to launch RBXLegacy. (The client has been detected as modified.)");
            }

            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In " + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + " Game";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void ClientExited(object sender, EventArgs e)
        {
            if (HelperStructs.GlobalVars.SelectedClient.HasRocky)
            {
                Process[] sudp = Process.GetProcessesByName(HelperStructs.GlobalVars.RockyPatchExeFilename);
                if (sudp != null)
                {
                    foreach (var process in sudp)
                    {
                        process.Kill();
                    }
                }
            }

            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In Launcher";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void PlaySolo_Click(object sender, RoutedEventArgs e)
        {
            HelperStructs.ScriptType type = HelperStructs.ScriptType.Solo;
            HelperStructs.ScriptGenerator.GenerateScriptForClient(type);

            string rbxexe = "";
            if (HelperStructs.GlobalVars.SelectedClient.LegacyMode)
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxLegacyExeFile;
            }
            else
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxStudioExeFile;
            }
            string quote = "\"";
            string args = "-script " + quote + HelperStructs.ScriptGenerator.GetScriptNameForType(type) + quote + " " + quote + HelperStructs.GlobalVars.MapFolder + HelperStructs.GlobalVars.SelectedMap + quote;

            string argsConverted = args.Replace("/", "//");

            ConsolePrint("Play Solo Loaded.");
            Process client = new Process();
            client.StartInfo.FileName = rbxexe;
            client.StartInfo.Arguments = argsConverted;
            client.EnableRaisingEvents = true;
            client.Exited += new EventHandler(SoloExited);
            client.Start();

            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In " + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + " Solo Game";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void SoloExited(object sender, EventArgs e)
        {
            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In Launcher";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void Studio_Click(object sender, RoutedEventArgs e)
        {
            HelperStructs.ScriptType type = HelperStructs.ScriptType.Studio;
            HelperStructs.ScriptGenerator.GenerateScriptForClient(type);

            string rbxexe = "";
            if (HelperStructs.GlobalVars.SelectedClient.LegacyMode)
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxLegacyExeFile;
            }
            else
            {
                rbxexe = HelperStructs.GlobalVars.ClientFolder + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + HelperStructs.GlobalVars.RobloxStudioExeFile;
            }

            string quote = "\"";
            string args = "-script " + quote + HelperStructs.ScriptGenerator.GetScriptNameForType(type) + quote + " " + quote + HelperStructs.GlobalVars.MapFolder + HelperStructs.GlobalVars.SelectedMap + quote;

            string argsConverted = args.Replace("/", "//");

            ConsolePrint("Studio Loaded.");
            Process client = new Process();
            client.StartInfo.FileName = rbxexe;
            client.StartInfo.Arguments = argsConverted;
            client.EnableRaisingEvents = true;
            client.Exited += new EventHandler(StudioExited);
            client.Start();

            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In " + HelperStructs.GlobalVars.LauncherConfig.SelectedClient + " Studio";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        void StudioExited(object sender, EventArgs e)
        {
            HelperStructs.GlobalVars.presence.largeImageKey = HelperStructs.GlobalVars.imagekey_large;
            HelperStructs.GlobalVars.presence.state = "In Launcher";
            HelperStructs.GlobalVars.presence.largeImageText = "RBXLegacy | " + HelperStructs.GlobalVars.presence.state;
            HelperStructs.DiscordRpc.UpdatePresence(ref HelperStructs.GlobalVars.presence);
        }

        private void DarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            HelperStructs.GlobalVars.LauncherConfig.Theme = true;
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(HelperStructs.GlobalVars.LauncherConfig.Scheme), ThemeManager.GetAppTheme("basedark"));
        }

        private void DarkTheme_Unchecked(object sender, RoutedEventArgs e)
        {
            HelperStructs.GlobalVars.LauncherConfig.Theme = false;
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(HelperStructs.GlobalVars.LauncherConfig.Scheme), ThemeManager.GetAppTheme("baselight"));
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelperStructs.GlobalVars.LauncherConfig.PlayerName = NameBox.Text;
        }

        private void IDBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            HelperStructs.GlobalVars.LauncherConfig.PlayerID = Convert.ToInt32(IDBox.Text);
        }

        private void ClientBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReadClientValues(ClientBox.SelectedItem.ToString());
            e.Handled = true;
        }

        private void MapList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HelperStructs.GlobalVars.SelectedMap = MapList.SelectedItem.ToString();
            e.Handled = true;
        }

        //Console

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
              // TextPointer to the start of content in the RichTextBox.
              rtb.Document.ContentStart,
              // TextPointer to the end of content in the RichTextBox.
              rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string 
            // representing the plain text content of the TextRange. 
            return textRange.Text;
        }

        void ProcessConsole(object sender, KeyEventArgs e)
        {
            string[] lines = StringFromRichTextBox(Console).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int totalLines = lines.Length;
            if (totalLines > 0)
            {
                string lastLine = lines[totalLines - 1];

                if (e.Key.Equals(Key.Return))
                {
                    ConsoleProcessCommands(lastLine);
                    e.Handled = true;
                }
            }
        }

        void ConsoleProcessCommands(string command)
        {
            if (command.Equals("config"))
            {
                ConsoleRBXLegacyHelp(1);
            }
            else if (command.Equals("help"))
            {
                ConsoleRBXLegacyHelp(0);
            }
            else if (command.Equals("config save"))
            {
                WriteConfigValues();
            }
            else if (command.Equals("config load"))
            {
                ReadConfigValues();
            }
            else if (command.Equals("config reset"))
            {
                HelperStructs.LauncherFuncs.ResetConfigValues();
                WriteConfigValues();
                ReadConfigValues();
                ConsolePrint("Configuration has been reset.");
            }
            else
            {
                ConsolePrint("ERROR 3 - Command is invalid");
            }

        }

        void ConsoleRBXLegacyHelp(int page)
        {
            if (page == 1)
            {
                ConsolePrint("RBXLegacy Config Command List");
                ConsolePrint("config save | Saves the config file");
                ConsolePrint("config load | Reloads the config file");
                ConsolePrint("config reset | Resets the config file");
            }
            else
            {
                ConsolePrint("RBXLegacy Console Command List");
                ConsolePrint("client | Loads client with launcher settings");
                ConsolePrint("solo | Loads client in Play Solo mode with launcher settings");
                ConsolePrint("studio | Loads Roblox Studio with launcher settings");
                ConsolePrint("custom | Loads the RBXLegacy Player Customizer");
                ConsolePrint("sdk | Loads the RBXLegacy SDK (If installed)");
                ConsolePrint("server | Loads the RBXLegacy Dedicated Server (If installed)");
                ConsolePrint("uri | Installs the RBXLegacy URI (If installed)");
                ConsolePrint("config save | Saves the config file");
                ConsolePrint("config load | Reloads the config file");
                ConsolePrint("config reset | Resets the config file");
            }
        }

        void ConsolePrint(string text)
        {
            Console.AppendText("[" + DateTime.Now.ToShortTimeString() + "] - " + text, "Lime");
            Console.AppendText(Environment.NewLine);
            Console.CaretPosition = Console.Document.ContentEnd;
            Console.ScrollToEnd();
        }
    }

    //colored console text

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, string color)
        {
            BrushConverter bc = new BrushConverter();
            TextRange tr = new TextRange(box.Document.ContentEnd, box.Document.ContentEnd);
            tr.Text = text;
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString(color));
            }
            catch (FormatException) { }
        }
    }
}
