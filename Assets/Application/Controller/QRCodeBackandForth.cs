using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QRCodeBackandForth : MonoBehaviour
{
   public GameObject QrCodeButton;
   public GameObject BackButton;

   public void QrCodeChangeScene(){
       if(QrCodeButton != null){
           SceneManager.LoadScene("QRLogin");
       }
   }

   public void QrCodeGoBack(){
       if(BackButton != null){
           SceneManager.LoadScene("LoginScene");
       }
   }

}
