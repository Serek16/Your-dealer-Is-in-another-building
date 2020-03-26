using UnityEngine;
using cmd.Console.Commands;

namespace cmd.Console
{
    public class CommandList : MonoBehaviour
    {
        void Start()
        {
            //ConsoleCommandsDatabase.RegisterCommand(name.name, name.description, name.usage, name.Execute);
            ConsoleCommandsDatabase.RegisterCommand(HelpCommand.name, HelpCommand.description, HelpCommand.usage, HelpCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(QuitCommand.name, QuitCommand.description, QuitCommand.usage, QuitCommand.Execute);            
            ConsoleCommandsDatabase.RegisterCommand(GhostModeCommand.name, GhostModeCommand.description, GhostModeCommand.usage, GhostModeCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(TakeDrugsCommand.name, TakeDrugsCommand.description, TakeDrugsCommand.usage, TakeDrugsCommand.Execute);
            ConsoleCommandsDatabase.RegisterCommand(PauseCommand.name, PauseCommand.description, PauseCommand.usage, PauseCommand.Execute);
        }
    }
}
