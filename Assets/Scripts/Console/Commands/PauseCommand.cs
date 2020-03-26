
using UnityEngine;
namespace cmd.Console.Commands
{
    public static class PauseCommand
    {
        public static readonly string name = "pause";
        public static readonly string description = "pause the game";
        public static readonly string usage = "/pause [true/false]";

        public static string Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                return HelpCommand.Execute(PauseCommand.name);
            }
            else
            {
                return PauseGame(args[0]);
            }
        }

        static string PauseGame(string status)
        {

            if (status == "true")
            {
                Time.timeScale = 0f;
                return "Game paused!";
            }

            else if (status == "false")
            {
                Time.timeScale = 1f;
                return "Game unpaused!";
            }

            else
            {
                return HelpCommand.Execute(PauseCommand.name);
            }

        }

    }
}