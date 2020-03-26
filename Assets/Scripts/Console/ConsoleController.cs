using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace cmd.Console
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ConsoleController))]
    public class ConsoleController : MonoBehaviour
    {
        public string prefix = "/";

        public GameObject consoleUI;
        public InputField commandInput;

        [HideInInspector] public bool isConsoleActive;

        private void Start()
        {
            isConsoleActive = false;
            consoleUI.gameObject.SetActive(isConsoleActive);
        }

        private void Update()
        {
            // Open/Close console
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                ToggleStatus(isConsoleActive ? false : true);
                FocusOnConsole("");
            }

            // Open console
            if (Input.GetKeyDown(KeyCode.T) && !isConsoleActive)
            {
                ToggleStatus(true);
                FocusOnConsole("");
            }

            // Close console
            if (Input.GetKeyDown(KeyCode.Escape) && isConsoleActive)
            {
                ToggleStatus(false);
            }

            // Open console with "/" at the beggining
            if (Input.GetKeyDown(KeyCode.Slash) && !isConsoleActive)
            {
                ToggleStatus(true);
                FocusOnConsole(prefix);
            }                      
            

            // Process command
            if (Input.GetKeyDown(KeyCode.Return) && isConsoleActive)
            {
                ExecuteCommand(commandInput.text);
                commandInput.text = "";
                commandInput.Select();
                commandInput.ActivateInputField();
            }
        }

        void ToggleStatus(bool isActive)
        {
            isConsoleActive = isActive;
            consoleUI.gameObject.SetActive(isActive);
            GameObject.Find("Main Camera").GetComponent<Game_data>().canMove = !isActive;
        }

        #region focusOnConsole
        // Focus on input field and set caret
        void FocusOnConsole(string initValue)
        {
            commandInput.text = initValue;
            commandInput.Select();
            commandInput.ActivateInputField();
            StartCoroutine(MoveTextEnd_NextFrame());
        }
        IEnumerator MoveTextEnd_NextFrame()
        {
            yield return 0;
            commandInput.MoveTextEnd(false);
        }
        //====
        #endregion

        void ExecuteCommand(string input)
        {
            if (!input.StartsWith(prefix)) { return; }

            input = input.Remove(0, prefix.Length);
            string[] inputSplit = input.Split(' ');
            string command = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();

            Console.Log(ConsoleCommandsDatabase.ExecuteCommand(command, args));
        }
    }
}