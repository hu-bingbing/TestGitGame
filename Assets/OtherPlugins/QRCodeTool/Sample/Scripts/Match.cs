using UnityEngine;
using System.Collections;
using CYTXGame.QRCodeTool;

public class Match : MonoBehaviour {
    private QREncoder encoder;
    private QRDecoder decoder;
    private GameObject EncodePanel;
    private GameObject DecodePanel;
    private GameObject ScanWindow;

    // Use this for initialization
    void Start () {
        encoder = GameObject.Find("QREncoder").GetComponent<QREncoder>();
        decoder = GameObject.Find("QRDecoder").GetComponent<QRDecoder>();
        EncodePanel = GameObject.Find("EncodePanel");
        DecodePanel = GameObject.Find("DecodePanel");
        ScanWindow = GameObject.Find("ScanWindow");

        encoder.QRCodeScheme = "MyGame";    // 二维码内容前缀，加在内容之前，用于扫描时与其他应用生成的二维码区别
        encoder.QRCodeTextureSize = 256;    // 二维码纹理大小
        string str = System.Guid.NewGuid().ToString();   // 二维码内容，如配对时房间号的Guid
        encoder.QRCodeContnet = str;

        decoder.QRCodeScheme = "MyGame";
        decoder.FitCamera = Camera.main;
        RectTransform rectTrans = ScanWindow.GetComponent<RectTransform>();
        Vector3 centerPos = Camera.main.WorldToScreenPoint(rectTrans.position);
        Rect scanWindowRect = new Rect();
        Canvas canvasCom = GameObject.FindObjectOfType<Canvas>();
        scanWindowRect.x = centerPos.x + rectTrans.rect.x * canvasCom.scaleFactor;
        scanWindowRect.y = centerPos.y + rectTrans.rect.y * canvasCom.scaleFactor;
        scanWindowRect.width = rectTrans.rect.width * canvasCom.scaleFactor;
        scanWindowRect.height = rectTrans.rect.height * canvasCom.scaleFactor;
        decoder.ScanWindowRect = scanWindowRect;

        SwitchToEncode();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnScanClick()
    {
        SwitchToDecode();
    }

    public void OnCodeClick()
    {
        SwitchToEncode();
    }

    void SwitchToEncode()
    {
        EncodePanel.SetActive(true);
        DecodePanel.SetActive(false);
        decoder.StopScan();
    }

    void SwitchToDecode()
    {
        DecodePanel.SetActive(true);
        EncodePanel.SetActive(false);
        decoder.StartScan(OnScanResult);
    }

    public void OnScanResult(string result)
    {
        Debug.Log(result);
    }
}
