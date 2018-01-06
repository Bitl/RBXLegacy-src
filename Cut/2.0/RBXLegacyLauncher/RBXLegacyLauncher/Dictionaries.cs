using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBXLegacyLauncher
{
    internal class Dictionaries
    {
        public static Dictionary<string, string> GetColor() =>
          new Dictionary<string, string>
          {
              ["Blue"] = "blue",
              ["Red"] = "red",
              ["Green"] = "green",
              ["Purple"] = "purple",
              ["Orange"] = "orange",
              ["Lime"] = "lime",
              ["Emerald"] = "emerald",
              ["Teal"] = "teal",
              ["Cyan"] = "cyan",
              ["Cobalt"] = "cobalt",
              ["Indigo"] = "indigo",
              ["Violet"] = "violet",
              ["Pink"] = "pink",
              ["Magenta"] = "magenta",
              ["Crimson"] = "crimson",
              ["Amber"] = "amber",
              ["Yellow"] = "yellow",
              ["Brown"] = "brown",
              ["Olive"] = "olive",
              ["Steel"] = "steel",
              ["Mauve"] = "mauve",
              ["Taupe"] = "taupe",
              ["Sienna"] = "sienna"
          };
    }
}