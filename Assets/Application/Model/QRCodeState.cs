using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QRCodeState 
{
    private static string qrScanned = "";
    static public string qrScannedWrite{

        get{
            return qrScanned;
        }
        set{
            qrScanned = value;
        }
    }

   
    static QRCodeState(){
        Debug.Log("Rebuilt");
    }
}
