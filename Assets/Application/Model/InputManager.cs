using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   public InputManager(){

   }

   public string commandParse(string command){
       string result = "Invalid command";
       string[] inputWords = command.Split(' ');

       if(command.ToLower().StartsWith("go")){
           inputWords = new string[]{
               "go", command.Replace("go ", string.Empty).Replace("go ", string.Empty)};
       }else if(command.ToLower().StartsWith("kill")){
           inputWords = new string[]{
               "kill", command.Replace("kill ", string.Empty).Replace("kill ", string.Empty)};
       }else{
           inputWords = command.Split(' ');

       }
       if(inputWords.Length >= 2){
           string cmd = inputWords[0] + "" + inputWords[1];
           
       }
       return result;
   }
       
   
}
