QRCodeTool��ά�����ɼ�ɨ����ʹ��˵��

QRCodeToolʹ��zxing.unity.dll�������ж�ά��ı���롣
����������ռ�ΪCYTXGame.QRCodeTool
������������ࣺ

QRCode���ṩ��������̬���������ж�ά��ı���ͽ��룬�Ƕ�zxing.unity.dll��ά�빦�ܵļ򵥷�װ
public static Texture2D Encode(string content, int size)
public static string Decode(Color32[] data, int width, int height)

QREncoder�����QREncoder prefabʹ�ã����ж�ά����������Ļ����ʾ��ά��
�����������������ö�ά�����ݼ���ʾ
public string QRCodeScheme		// ��ά���������ǰ׺���������ֲ�ͬӦ�����ɵĶ�ά�룬�����ı�������Ϊ "<QRCodeScheme>:<QRCodeContnet>"��ʽ
public string QRCodeContnet		// ��ά�����ʵ������
public int QRCodeTextureSize	// ��ά�������С��Ĭ��ֵΪ256

QRDecoder�����QRDecoder prefabʹ�ã���������ͷ���沢ɨ���ά��
���������Ժ�һ��������ʵ��ɨ���߼�
public string QRCodeScheme						// ��ά��ǰ׺���������ֲ�ͬӦ�����ɵĶ�ά��
public Camera FitCamera							// ����ͷ����Ļ�����Ҫȫ����ʾ����Ļ�ϣ�������Ҫ����ʾWebCameraTexture��Quad�������ţ�FitCamera��������Ϊ��ʾQuad������ͶӰ����Լ�������ֵ��Ĭ��ֵΪCamera.main
public Rect ScanWindowRect						// ����ɨ������Screen Coordination��������������Ļ�ϵ�һ��������Ϊɨ������ɨ������֮���ͼ�����ʾmask
public void StartScan(Action<string> callback)	// ��ʼɨ�裬�������Ϊɨ��ɹ��Ļص��������ص�������stringΪ��������ӦQRCodeContent������

SampleĿ¼��������ʾ���������ֱ���ʾ��QREncoder��QRDecoder��ʹ��