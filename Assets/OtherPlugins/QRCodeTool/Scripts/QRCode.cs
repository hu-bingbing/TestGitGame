using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;
using System;
using ZXing.Common;
using ZXing.Rendering;
using System.Collections.Generic;

namespace CYTXGame.QRCodeTool
{
    public class QRCode
    {
        public static Texture2D Encode(string content, int size)
        {
            Texture2D encoded = new Texture2D(size, size);
            if (encoded != null)
            {
                BitMatrix BIT;
                Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
                //设置编码方式  
                hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
                hints.Add(EncodeHintType.MARGIN, 1);
                BIT = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, size, size, hints);

                if (BIT.Width != size || BIT.Height != size)
                {
                    return null;
                }

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (BIT[x, y])
                        {
                            encoded.SetPixel(y, size - x - 1, Color.black);
                        }
                        else
                        {
                            encoded.SetPixel(y, size - x - 1, Color.white);
                        }
                    }
                }
                encoded.Apply();
            }

            return encoded;
        }

        public static string Decode(Color32[] data, int width, int height)
        {
            var qrcodeReader = new QRCodeReader();
            Color32LuminanceSource source = new Color32LuminanceSource(data, width, height);
            var binarizer = new HybridBinarizer(source);
            var binaryBitmap = new BinaryBitmap(binarizer);

            Dictionary<DecodeHintType, object> hints = new Dictionary<DecodeHintType, object>();
            hints.Add(DecodeHintType.CHARACTER_SET, "utf-8");
            hints.Add(DecodeHintType.TRY_HARDER, true);
            hints.Add(DecodeHintType.POSSIBLE_FORMATS, BarcodeFormat.QR_CODE);
            hints.Add(DecodeHintType.TRY_HARDER_WITHOUT_ROTATION, true);

            string content = "";

            Result result = qrcodeReader.decode(binaryBitmap);
            if (result != null)
            {
                content = result.Text;
            }

            return content;
        }
    }
}
