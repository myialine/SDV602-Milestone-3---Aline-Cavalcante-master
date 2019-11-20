using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandInput : MonoBehaviour
{
    private InputField inputField;
    private InputField.SubmitEvent submitEvent;
    private InputField.OnChangeEvent changeEvent;
    [SerializeField] private Text output;

    void Start ()
    {
        inputField = this.GetComponent<InputField>();
        if(inputField != null) {
            submitEvent = new InputField.SubmitEvent();
            submitEvent.AddListener(Submit);
            inputField.onEndEdit = submitEvent;
        }
    }

    // Submit and parse text
    private void Submit (string _input)
    {
        string current = output.text;

        InputManager words = new InputManager();

        if(_input.ToLower().StartsWith("go ")) {
            words.commandParse(_input);
            Send("[" + GameManager.instance.PlayerUsername + "]: " + _input.Replace("go ", string.Empty).Replace("go ", string.Empty));
        
        }else if(_input.ToLower().StartsWith("kill ")){
            words.commandParse(_input);
            Send("[" + GameManager.instance.PlayerUsername + "]: "+ _input.Replace("kill ", string.Empty).Replace("kill ", string.Empty));
        
        }else {
            string result = words.commandParse(_input);
            if(!string.IsNullOrEmpty(result))
                output.text += '\n' + result;
        }

        inputField.text = string.Empty;
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN
            inputField.ActivateInputField();
        #endif
        
    }

    //Unprocessed messages
    public void Send (string _input) {
        output.text += '\n' + _input;
    }
}
