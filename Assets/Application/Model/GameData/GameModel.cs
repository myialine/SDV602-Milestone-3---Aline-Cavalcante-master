using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public static class GameModel 
{
    private static string playerName;
    private static Player aplayer = new Player();
    private static Room startingRoom;
    private static Room _currentRoom;
    private static string varDescriprion;

    

    //All the rooms in order.
       
    public static Room Starting_Room
    {
        get{
            return startingRoom;
        }
        set{
            startingRoom = value;
        }
    }

    public static string Name{
        get{
            return playerName;
        }
        set{
            playerName = value;
        }
    }

     public static Player currentPlayer
    {
        get{
            return aplayer;
        }
        set{
            aplayer = value;
        }
    }

    public static Room currentRoom{
        get{
            return _currentRoom;
        }

        set{
            _currentRoom = value;
        }
    }


}
