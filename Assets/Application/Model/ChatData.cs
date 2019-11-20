using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class ChatData 
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string nameOfPlayer { get; set; }
    public string conversation { get; set; }

    public override string ToString(){
        return string.Format("[ID: {0}, nameOfPlayer: {1}, coversation: {2}]", ID, nameOfPlayer, conversation);
    }
}
