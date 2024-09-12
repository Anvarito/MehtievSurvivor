using TMPro;
using UnityEngine;

namespace Infrastructure
{
    public class FPSCounter : MonoBehaviour
    {
        public TextMeshProUGUI _label;
        private int frameCount = 0;
        private float elapsedTime = 0.0f;
        private float fps = 0.0f;

        public float updateInterval = 0.5f;

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }

        void Update()
        {
            frameCount++;
            elapsedTime += Time.deltaTime;

            if (elapsedTime > updateInterval)
            {
                fps = frameCount / elapsedTime;
                frameCount = 0;
                elapsedTime = 0.0f;
                _label.text = "FPS: " + Mathf.Ceil(fps);
            }
        }

        void OnGUI()
        {
            return;
            int width = 200;
            int height = 40;
        
            Rect rect = new Rect(Screen.width - width, 10, width, height);
        
            GUI.Label(rect, "<size=20>" + " FPS" + Mathf.Ceil(fps) + "</size>");
        }
    }
}