using UnityEngine;
using System.Collections;
using CYTXGame.QRCodeTool;
using UnityEngine.UI;

public class QREncodeTest : MonoBehaviour {
    private QREncoder encoder;
    private Text content;

	// Use this for initialization
	void Start () {
        content = GameObject.Find("Content").GetComponent<Text>();
        encoder = GameObject.FindObjectOfType<QREncoder>();
        if (encoder)
        {
            encoder.QRCodeScheme = "MyGame";    // 二维码内容前缀，加在内容之前，用于扫描时与其他应用生成的二维码区别
            encoder.QRCodeTextureSize = 256;    // 二维码纹理大小
            string str = System.Guid.NewGuid().ToString();   // 二维码内容，如配对时房间号的Guid
            encoder.QRCodeContnet = str;
            content.text = str;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
