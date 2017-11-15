using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Threading;

namespace CYTXGame.QRCodeTool
{
    public class QRDecoder : MonoBehaviour
    {
        private GameObject capture;
        private MeshRenderer renderer;
        private GameObject mask;
        private Rect scanWindowRect;
        private Camera fitCamera;
        private bool isDirty = false;

        public Camera FitCamera
        {
            get
            {
                return fitCamera;
            }
            set
            {
                fitCamera = value;
                isDirty = true;
            }
        }

        public Rect ScanWindowRect
        {
            get
            {
                return scanWindowRect;
            }
            set
            {
                scanWindowRect = value;
                isDirty = true;
            }
        }

        private WebCamTexture cameraTexture = null;
        private string cameraName = null;

        [SerializeField]
        private string _QRCodeScheme = "YourScheme";
        [SerializeField]
        private string _SortingLayerName = "Default";
        [SerializeField]
        private int _SortingOrder = 0;

        public string QRCodeScheme
        {
            get
            {
                return _QRCodeScheme;
            }
            set
            {
                _QRCodeScheme = value;
            }
        }

        private Texture2D maskTexture;

        private Thread qrThread;

        private Color32[] cameraImage = null;
        private int imageWidth;
        private int imageHeight;
        private Color32[] data = null;
        private bool hasData = false;
        private int cx, cy, cw, ch;
        private bool isQuit = false;
        private string lastResult = null;

        private Action<string> m_callback = null;

        void Awake()
        {
            capture = transform.Find("Capture").gameObject;
            mask = transform.Find("Mask").gameObject;
            renderer = capture.GetComponent<MeshRenderer>();
            renderer.sortingLayerName = _SortingLayerName;
            renderer.sortingOrder = _SortingOrder;
            MeshRenderer maskRenderer = mask.GetComponent<MeshRenderer>();
            maskRenderer.sortingLayerName = _SortingLayerName;
            maskRenderer.sortingOrder = _SortingOrder + 1;
            fitCamera = Camera.main;
            int size = System.Math.Min(Screen.width, Screen.height);
            size /= 2;
            scanWindowRect = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - size / 2, size, size);
            isDirty = true;
        }

        // Use this for initialization  
        void Start()
        {
            capture.SetActive(false);
            mask.SetActive(false);
            maskTexture = new Texture2D(Screen.width, Screen.height);
        }

        // 摄像头捕获的图像全屏显示，camera必须是正交投影
        private void FitScreen()
        {
            float scaleY = fitCamera.orthographicSize * 2;
            float scaleX = scaleY * Screen.width / Screen.height;
            transform.position = new Vector3(fitCamera.transform.position.x, fitCamera.transform.position.y, transform.position.z);
            mask.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);

            for (int x = 0; x < Screen.width; x++)
            {
                for (int y = 0; y < Screen.height; y++)
                {
                    if (x >= scanWindowRect.x && x < scanWindowRect.x + scanWindowRect.width && y >= scanWindowRect.y && y < scanWindowRect.y + scanWindowRect.height)
                    {
                        maskTexture.SetPixel(x, y, new Color(0, 0, 0, 0));
                    }
                    else
                    {
                        maskTexture.SetPixel(x, y, new Color(0, 0, 0, 0.5f));
                    }
                }
            }
            maskTexture.Apply();

            MeshRenderer maskRenderer = mask.GetComponent<MeshRenderer>();
            if (maskRenderer != null)
            {
                maskRenderer.material.mainTexture = maskTexture;
            }
        }

        private void SetupCapture()
        {
            //Debug.Log("Screen.width = " + Screen.width);
            //Debug.Log("Screen.height = " + Screen.height);
            //Debug.Log("cameraTexture.width = " + cameraTexture.width);
            //Debug.Log("cameraTexture.height = " + cameraTexture.height);
            //Debug.Log("cameraTexture.videoRotationAngle = " + cameraTexture.videoRotationAngle);

            float scaleY = fitCamera.orthographicSize * 2;
            float scaleX = scaleY * Screen.width / Screen.height;
			if (Screen.width < Screen.height) 
			{
				float temp = scaleX;
				scaleX = scaleY;
				scaleY = temp;
			}

			float screenW = (float)Math.Max (Screen.width, Screen.height);
			float screenH = (float)Math.Min (Screen.width, Screen.height);
            float scaleW = screenW / (float)cameraTexture.width;
            float scaleH = screenH / (float)cameraTexture.height;

            //Debug.Log("scaleX = " + scaleX);
            //Debug.Log("scaleY = " + scaleY);
            //Debug.Log("scaleW = " + scaleW);
            //Debug.Log("scaleH = " + scaleH);

            float scaleCaptureImage = Mathf.Max(scaleW, scaleH);
            if (scaleW > scaleH)
            {
				scaleY = scaleX * (float)cameraTexture.height / (float)cameraTexture.width;
            }
            else
            {
				scaleX = scaleY * (float)cameraTexture.width / (float)cameraTexture.height;
            }

			float flipY = 1.0f;
			if (cameraTexture.videoVerticallyMirrored) 
			{
				flipY = -1.0f;
			}
            capture.transform.localRotation = Quaternion.Euler(0, 0, -cameraTexture.videoRotationAngle);
			capture.transform.localScale = new Vector3(scaleX, scaleY * flipY, 1.0f);
            if (cameraTexture.videoRotationAngle == 0)
            {
				cw = (int)(scanWindowRect.width / scaleCaptureImage);
				ch = (int)(scanWindowRect.height / scaleCaptureImage);
				cx = (int)((scanWindowRect.center.x + (cameraTexture.width * scaleCaptureImage - (float)Screen.width) / 2.0f) / scaleCaptureImage) - cw / 2;
				cy = (int)((scanWindowRect.center.y + (cameraTexture.height * scaleCaptureImage - (float)Screen.height) / 2.0f) / scaleCaptureImage) - ch / 2;
            }
            else if (cameraTexture.videoRotationAngle == 90)
            {
				cw = (int)(scanWindowRect.height / scaleCaptureImage);
				ch = (int)(scanWindowRect.width / scaleCaptureImage);
				cx = (int)((scanWindowRect.center.y + (cameraTexture.width * scaleCaptureImage - (float)Screen.height) / 2.0f) / scaleCaptureImage) + cw / 2;
				cy = (int)((scanWindowRect.center.x + (cameraTexture.height * scaleCaptureImage - (float)Screen.width) / 2.0f) / scaleCaptureImage) - ch / 2;
                cx = cameraTexture.width - cx;
            }
            else if (cameraTexture.videoRotationAngle == 180)
            {
				cw = (int)(scanWindowRect.width / scaleCaptureImage);
				ch = (int)(scanWindowRect.height / scaleCaptureImage);
				cx = (int)((scanWindowRect.center.x + (cameraTexture.width * scaleCaptureImage - (float)Screen.width) / 2.0f) / scaleCaptureImage) + cw / 2;
				cy = (int)((scanWindowRect.center.y + (cameraTexture.height * scaleCaptureImage - (float)Screen.height) / 2.0f) / scaleCaptureImage) + ch / 2;
                cx = cameraTexture.width - cx;
                cy = cameraTexture.height - cy;
            }
            else //if (cameraTexture.videoRotationAngle == 270)
            {
				cw = (int)(scanWindowRect.height / scaleCaptureImage);
				ch = (int)(scanWindowRect.width / scaleCaptureImage);
				cx = (int)((scanWindowRect.center.y + (cameraTexture.width * scaleCaptureImage - (float)Screen.height) / 2.0f) / scaleCaptureImage) - cw / 2;
				cy = (int)((scanWindowRect.center.x + (cameraTexture.height * scaleCaptureImage - (float)Screen.width) / 2.0f) / scaleCaptureImage) + ch / 2;
                cy = cameraTexture.height - cy;
            }
			if (cameraTexture.videoVerticallyMirrored) 
			{
				cy = cameraTexture.height - cy - ch;
			}

            //Debug.Log("scanWindowRect.x = " + scanWindowRect.x);
            //Debug.Log("scanWindowRect.y = " + scanWindowRect.y);
            //Debug.Log("scanWindowRect.width = " + scanWindowRect.width);
            //Debug.Log("scanWindowRect.height = " + scanWindowRect.height);
            //Debug.Log("cx = " + cx);
            //Debug.Log("cy = " + cy);
            //Debug.Log("cw = " + cw);
            //Debug.Log("ch = " + ch);

            data = new Color32[cw * ch];
		}

        public void StartScan(Action<string> callback)
        {
            DestroyCameraTexture();
            m_callback = callback;
            StartCoroutine(CreateCamera());
        }

        public void StopScan()
        {
            StopAllCoroutines();
            m_callback = null;
            if (cameraTexture != null && cameraTexture.isPlaying)
            {
                cameraTexture.Pause();
            }
            capture.SetActive(false);
            mask.SetActive(false);
            isQuit = true;
        }

        private void Begin()
        {
            if (cameraName != null)
            {
                lastResult = null;
                hasData = false;
                isQuit = false;
                cameraTexture = new WebCamTexture(cameraName, Screen.width, Screen.height, 15);
                cameraTexture.Play();
                mask.SetActive(true);
                qrThread = new Thread(DecodeQR);
                qrThread.Start();
            }
        }

        bool IsValidCameraTexture(WebCamTexture tex)
        {
            if (tex.width > 16 && tex.height > 16 && (tex.videoRotationAngle == 0 || tex.videoRotationAngle == 90 || tex.videoRotationAngle == 180 || tex.videoRotationAngle == 270))
            {
                return true;
            }

            return false;
        }

        void OnDestroy()
        {
            DestroyCameraTexture();
        }

        void DestroyCameraTexture()
        {
            if (cameraTexture != null)
            {
                cameraTexture.Stop();
                cameraTexture = null;
            }
        }

        // Update is called once per frame  
        void Update()
        {
            if (isDirty)
            {
                isDirty = false;
                FitScreen();
            }
            if (cameraTexture != null && cameraTexture.isPlaying)
            {
                renderer.material.mainTexture = cameraTexture;

                if (lastResult != null)
                {
                    Debug.Log("Decode result: " + lastResult);
                    cameraTexture.Pause();
                    capture.SetActive(false);
                    mask.SetActive(false);
                    isQuit = true;
                    if (m_callback != null)
                    {
                        m_callback(lastResult);
                    }
                }
                if (isQuit == false && hasData == false)
                {
                    //Debug.Log("Fill data");
					if (IsValidCameraTexture(cameraTexture)) // iOS初始化时width height为16，过一段时间才能正常
					{
                        if (capture.activeSelf == false)
                        {
                            capture.SetActive(true);
                        }
						if (cameraImage == null || imageWidth != cameraTexture.width || imageHeight != cameraTexture.height) 
						{
							cameraImage = new Color32[cameraTexture.width * cameraTexture.height];
                            imageWidth = cameraTexture.width;
                            imageHeight = cameraTexture.height;
							SetupCapture ();
						}
						cameraTexture.GetPixels32 (cameraImage);
						for (int y = 0; y < ch; y++) {
							int newx = cx;
							int newy = cy + y;
							Array.Copy (cameraImage, newy * cameraTexture.width + newx, data, y * cw, cw);
						}
						hasData = true;
					}
                }               
            }
        }

        IEnumerator CreateCamera()
        {
            Debug.Log("CreateCamera");
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                WebCamDevice[] devices = WebCamTexture.devices;
                foreach (var dev in devices)
                {
                    if (dev.isFrontFacing == false)
                    {
                        cameraName = dev.name;
                        Begin();
                        break;
                    }
                }
            }
        }

        // 解码 扫描的内容  
        void DecodeQR()
        {
            while (true)
            {
                if (isQuit)
                {
                    break;
                }

                try
                {

                    if (hasData)
                    {
                        var result = QRCode.Decode(data, cw, ch);
                        if (result != "")
                        {
                            if (result.StartsWith(_QRCodeScheme))
                            {
                                lastResult = result.Substring(_QRCodeScheme.Length + 1);
                            }
                        }

                        hasData = false;
                        Thread.Sleep(200);
                    }
                }
                catch
                {
                }
            }
        }
    }
}
