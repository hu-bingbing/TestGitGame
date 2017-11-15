QRCodeTool二维码生成及扫描插件使用说明

QRCodeTool使用zxing.unity.dll库来进行二维码的编解码。
插件的命名空间为CYTXGame.QRCodeTool
插件包含三个类：

QRCode类提供了两个静态方法来进行二维码的编码和解码，是对zxing.unity.dll二维码功能的简单封装
public static Texture2D Encode(string content, int size)
public static string Decode(Color32[] data, int width, int height)

QREncoder类配合QREncoder prefab使用，进行二维码编码和在屏幕上显示二维码
有三个属性用来设置二维码内容及显示
public string QRCodeScheme		// 二维码编码内容前缀，用来区分不同应用生成的二维码，完整的编码内容为 "<QRCodeScheme>:<QRCodeContnet>"格式
public string QRCodeContnet		// 二维码编码实际内容
public int QRCodeTextureSize	// 二维码纹理大小，默认值为256

QRDecoder类配合QRDecoder prefab使用，捕获摄像头画面并扫描二维码
有三个属性和一个方法来实现扫描逻辑
public string QRCodeScheme						// 二维码前缀，用来区分不同应用生成的二维码
public Camera FitCamera							// 摄像头捕获的画面需要全屏显示在屏幕上，所以需要对显示WebCameraTexture的Quad进行缩放，FitCamera属性设置为显示Quad的正交投影相机以计算缩放值，默认值为Camera.main
public Rect ScanWindowRect						// 设置扫描区域（Screen Coordination），用于设置屏幕上的一块区域作为扫描区域，扫描区域之外的图像会显示mask
public void StartScan(Action<string> callback)	// 开始扫描，传入参数为扫描成功的回调函数，回调函数以string为参数，对应QRCodeContent的内容

Sample目录下有两个示例场景，分别演示了QREncoder和QRDecoder的使用