
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{   
    [HideInInspector]public string userName;
    [HideInInspector]public string userEmail;
     [HideInInspector] public string userPassword;
     [HideInInspector] public string repeatPassword;
     [HideInInspector] Room currentRoom;
    public InputField userNameField;
    public InputField userEmailField;
    public InputField userPasswordField;
    public InputField repeatPasswordField;
    public GameObject loginBtn;
    public GameObject registerBtn;
    [HideInInspector] public bool isLoggedIn = false;

    public void LoginBtn(){
        
        userName = userNameField.GetComponent<InputField>().text;
        userPassword = userPasswordField.GetComponent<InputField>().text;
        
        if(loginBtn != null && userName !=null && userPassword !=null){
            
            GameModel.PlayerManager.Login(userName, userPassword);
       
        }else{
            Debug.LogWarning("You need to put email and password");
        }

    }

    public void RegisterBtn(){
        userName = userNameField.GetComponent<InputField>().text;
        userEmail = userEmailField.GetComponent<InputField>().text;
        userPassword = userPasswordField.GetComponent<InputField>().text;
        repeatPassword = repeatPasswordField.GetComponent<InputField>().text;

        if(registerBtn !=null && userName !=null  && userEmail !=null && userPassword != null && repeatPassword !=null){
            
            if(userPassword == repeatPassword){
                GameModel.PlayerManager.Register(userName, userEmail, userPassword, GameModel.currentRoom.bedroom.description);                
                
            }else{
                Debug.LogWarning("Passwords don't match.");
            }
            

        }else{
            Debug.LogWarning("Fill in all the details");
        }
    }

    





}
