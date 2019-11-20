/*
* Copyright 2012 ZXing.Net authors
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
public class QrCodeCam : MonoBehaviour
{
    public Texture2D encoded;
    private WebCamTexture camTexture;
    private Thread qrThread;

    private Color32[] c;
    private int W, H;
    private bool isScannedQR = false;

    private Rect screenRect;

    private bool isQuit;
 
    public string LastResult;
    private bool shouldEncodeNow;

    public RenderTexture theRenderTexture;

    void OnGUI()
    {
        //GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
       
    }

    void OnEnable()
    {
        if (camTexture != null)
        {
            camTexture.Play();
            W = camTexture.width;
            H = camTexture.height;
        }
    }

    void OnDisable()
    {
        if (camTexture != null)
        {
            camTexture.Pause();
        }
    }

    void OnDestroy()
    {
        qrThread.Abort();
        camTexture.Stop();
    }

    // It's better to stop the thread by itself rather than abort it.
    void OnApplicationQuit()
    {
        isQuit = true;
    }

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log("Number of web cams connected: " + devices.Length);
        Renderer rend = this.GetComponentInChildren<Renderer>();

        encoded = new Texture2D(460, 640);
        LastResult = "http://www.google.com";
        shouldEncodeNow = true;

        screenRect = new Rect(0, 0, 460, 640);//Screen.width, Screen.height);

        camTexture = new WebCamTexture();

        camTexture.requestedHeight = 640;// Screen.height; // 480;
        camTexture.requestedWidth = 460;//  Screen.width; //640;
        rend.material.mainTexture = camTexture;
        OnEnable();
        // Sleep a little bit and set the signal to get the next frame
        Thread.Sleep(3000);
        qrThread = new Thread(DecodeQR);
        qrThread.Start();
    }

    void Update()
    {
        if (isScannedQR)
        {
            SceneManager.LoadScene("GameMain");
        }
        if (c == null)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            }
            
            c = camTexture.GetPixels32();// Getting a frame
        }

        // encode the last found
        var textForEncoding = LastResult;
        if (shouldEncodeNow &&
            textForEncoding != null)
        {
            var color32 = Encode(textForEncoding, encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
            shouldEncodeNow = false;
        }
    }

    void DecodeQR()
    {
        // create a reader with a custom luminance source
        var barcodeReader = new BarcodeReader { AutoRotate = false, TryHarder = false };

        while (true)
        {
            if (isQuit)
                break;

            try
            {
                // decode the current frame
                var result = barcodeReader.Decode(c, W, H);
                if (result != null)
                {
                    LastResult = result.Text;
                    shouldEncodeNow = true;
                    QRCodeState.qrScannedWrite = result.Text;
                    isScannedQR = true;
                    print(result.Text);
                    
                }

                // Sleep a little bit and set the signal to get the next frame
                Thread.Sleep(200);
                c = null;
            }
            catch
            {
            }
        }
    }

    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
}
