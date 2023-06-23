using System.IO;
using UnityEngine;

namespace Blacktool.Utils
{
    /// <summary>
    /// Class used to take screenshots of the cards
    /// </summary>
    public class CameraCapture : MonoBehaviour
    {
        //Screenshot size
        public enum CaptureSize
        {
            CameraSize,
            ScreenResolution,
            FixedSize
        }

        //Target camera
        public Camera targetCamera;

        //Screenshot size
        public CaptureSize captureSize = CaptureSize.CameraSize;

        //Pixel size
        public Vector2 pixelSize;

        //Save path
        public string savePath = "StreamingAssets/";

#if UNITY_EDITOR
        private void Reset()
        {
            targetCamera = GetComponent<Camera>();
            pixelSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        }
#endif

        ///< summary > Save screenshot < / summary >
        ///< param name = "camera" > target camera < / param >
        public void saveCapture(string fileName)
        {
            Vector2 size = pixelSize;
            if (captureSize == CaptureSize.CameraSize)
            {
                size = new Vector2(targetCamera.pixelWidth, targetCamera.pixelHeight);
            }
            else if (captureSize == CaptureSize.ScreenResolution)
            {
                size = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            }

            string path = Application.dataPath + "/" + savePath + fileName;
            saveTexture(path, capture(targetCamera, (int)size.x, (int)size.y));
        }

        ///< summary > camera screenshot < / summary >
        ///< param name = "camera" > target camera < / param >
        public static Texture2D capture(Camera camera)
        {
            return capture(camera, Screen.width, Screen.height);
        }

        ///< summary > camera screenshot < / summary >
        ///< param name = "camera" > target camera < / param >
        ///< param name = "width" > width < / param >
        ///< param name = "height" > height < / param >
        public static Texture2D capture(Camera camera, int width, int height)
        {
            RenderTexture rt = new RenderTexture(width, height, 0);
            rt.depth = 24;
            rt.antiAliasing = 8;
            camera.targetTexture = rt;
            camera.RenderDontRestore();
            RenderTexture.active = rt;
            Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
            Rect rect = new Rect(0, 0, width, height);
            texture.ReadPixels(rect, 0, 0);
            texture.filterMode = FilterMode.Point;
            texture.Apply();
            camera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            return texture;
        }

        ///< summary > Save map < / summary >
        ///< param name = "path" > save path < / param >
        /// <param name="texture">Texture2D</param>
        public static void saveTexture(string path, Texture2D texture)
        {
            File.WriteAllBytes(path, texture.EncodeToPNG());
#if UNITY_EDITOR
            Debug.Log("saved screenshot to:" + path);
#endif
        }
    }
}