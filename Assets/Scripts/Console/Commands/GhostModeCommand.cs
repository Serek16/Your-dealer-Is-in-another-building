using UnityEngine;
namespace cmd.Console.Commands
{
    public static class GhostModeCommand
    {
        public static readonly string name = "ghostmode";
        public static readonly string description = "activate or deactivat ghost mode";
        public static readonly string usage = "/ghostmode [true/false]";

        public static string Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                return HelpCommand.Execute(GhostModeCommand.name);
            }
            else
            {
                return ToggleGhostMode(args[0]);
            }
        }

        static string ToggleGhostMode(string status)
        {
            
            if (status == "true")
            {
                GameObject.Find("Player").GetComponent<GhostMode>().ToggleStatus(true);                
                return "ghost mode enabled!";
            }

            else if(status == "false")
            {
                GameObject.Find("Player").GetComponent<GhostMode>().ToggleStatus(false);
                return "ghost mode disabled!";
            }

            else
            {
                return HelpCommand.Execute(GhostModeCommand.name);
            }

        }

    }
}