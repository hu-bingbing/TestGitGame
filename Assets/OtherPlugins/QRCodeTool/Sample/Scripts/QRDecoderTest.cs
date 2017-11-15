using UnityEngine;
using System.Collections;
using CYTXGame.QRCodeTool;
using UnityEngine.UI;

public class QRDecoderTest : MonoBehaviour {
    private QRDecoder decoder;
    private Text content; 

	// Use this for initialization
	void Start () {
        content = GameObject.Find("Content").GetComponent<Text>();
        decoder = GameObject.FindObjectOfType<QRDecoder>();
        if (decoder)
        {
            decoder.QRCodeScheme = "MyGame";    // 二维码内容前缀，加在内容之前，用于扫描时与其他应用生成的二维码区别
            decoder.FitCamera = Camera.main;    // 摄像头捕获的图像全屏显示，camera必须是正交投影
            int size = System.Math.Min(Screen.width, Screen.height);
            size /= 2;
            decoder.ScanWindowRect = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - size / 2, size, size);       // 扫描区域
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnScanResult(string result)
    {
        if (content != null)
        {
            content.text = result;
        }
    }

    public void OnScanButtonClick()
    {
        if (decoder != null)
        {
            decoder.StartScan(OnScanResult);
        }
    }
}
