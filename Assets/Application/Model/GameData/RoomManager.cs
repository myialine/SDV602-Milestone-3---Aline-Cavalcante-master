using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : Room
{
    public static void SaveRooms()
    {  
    //    DatabaseManager.AddOrUpdate<Room>(Room currentRoom);
    }

    public static void LoadRooms(){
        
        Rooms.Clear();
        
        //DatabaseManager.SQLiteConnection.
        //Rooms = ds.LoadRooms();
    }
}
