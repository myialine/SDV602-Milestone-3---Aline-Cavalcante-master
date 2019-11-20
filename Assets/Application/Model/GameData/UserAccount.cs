using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class UserAccount 
{
   [PrimaryKey, AutoIncrement]
   public int ID { get; set; }

   [Unique]
   public string playerUsername { get; set; }
   public string password { get; set; }

   public override string ToString(){
       return string.Format("[ID: {0}, playerUsername: {2}, password: {3}]", ID, playerUsername, password);
   }
}
