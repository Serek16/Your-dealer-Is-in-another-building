using UnityEngine;
namespace cmd.Console.Commands
{
    public static class TakeDrugsCommand
    {
        public static readonly string name = "takedrugs";
        public static readonly string description = "";
        public static readonly string usage = "/takedrugs [(0,5)]";

        public static string Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                return HelpCommand.Execute(TakeDrugsCommand.name);
            }
            else
            {
                return TakeDrugs(args[0]);
            }
        }

        static string TakeDrugs(string drugCount)
        {

            int _drugCount = int.Parse(drugCount);
            GameObject.Find("Main Camera").GetComponent<Drug_system>().TakeDrugs(_drugCount);
            return "Drug count = " + _drugCount;
        }

    }
}