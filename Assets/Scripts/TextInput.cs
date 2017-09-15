using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField InputField;
    GameController gameController;

    void Awake()
    {
        gameController = GetComponent<GameController>();
        InputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        gameController.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimiterCharacters,System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < gameController.InputActions.Length; i++)
        {
            InputAction inputAction = gameController.InputActions[i];
            if(inputAction.KeyWord == separatedInputWords[0])
            {
                inputAction.RespondToInput(gameController, separatedInputWords);
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        gameController.DisplayLoggedText();
        InputField.ActivateInputField();
        InputField.text = null;
    }
}
