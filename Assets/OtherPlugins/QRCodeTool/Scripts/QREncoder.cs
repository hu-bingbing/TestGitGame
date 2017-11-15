using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace CYTXGame.QRCodeTool
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class QREncoder : MonoBehaviour
    {
        private Texture2D QRCodeTex;
        private MeshRenderer renderer;
        private bool isDirty = false;

        [SerializeField]
        private string _QRCodeScheme = "YourScheme";
        [SerializeField]
        private int _QRCodeTextureSize = 256;
        [SerializeField]
        private string _QRCodeContent = "Nothing";
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
                isDirty = true;
            }
        }

        public string QRCodeContnet
        {
            get { return _QRCodeContent; }
            set
            {
                _QRCodeContent = value;
                isDirty = true;
            }
        }

        public int QRCodeTextureSize
        {
            get
            {
                return _QRCodeTextureSize;
            }
            set
            {
                _QRCodeTextureSize = value;
                isDirty = true;
            }
        }

        void Awake()
        {
            renderer = GetComponent<MeshRenderer>();
            renderer.sortingLayerName = _SortingLayerName;
            renderer.sortingOrder = _SortingOrder;
        }

        // Use this for initialization
        void Start()
        {
        }

        private void UpdateTexture()
        {
            QRCodeTex = QRCode.Encode(_QRCodeScheme + ":" + _QRCodeContent, _QRCodeTextureSize);
            if (renderer != null && QRCodeTex != null)
            {
                renderer.material.mainTexture = QRCodeTex;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isDirty)
            {
                isDirty = false;
                UpdateTexture();
            }
        }
    }
}
