using Rewired.Internal;
using System;
using UnityEngine;

namespace LLBInputHistory
{
    public class LLBInputHistory : MonoBehaviour
    {
        public const string modVersion = "1.0.0";
        private const string repositoryOwner = "N-Desmarais";
        private const string repositoryName = "LLB-Input-History";

        public static LLBInputHistory instance = null;

        public static void Initialize() {
            GameObject gameObject = new GameObject("LLBInputHistory");
            instance = gameObject.AddComponent<LLBInputHistory>();
            DontDestroyOnLoad(gameObject);
            Assets.LoadAssets();
        }

        public ModMenuIntegration MMI = null;

        private void Update() {
            if (MMI == null) { MMI = gameObject.AddComponent<ModMenuIntegration>(); }
        }

        public const float GUI_Height = 1080;
        public const float GUI_Width = 1920;
        Rect inputRect = new Rect(30, GUI_Height - 147, 300, 117);
        private void OnGUI() {
            if(LLModMenu.ModMenu.Instance.inModOptions) inputRect = GUILayout.Window(102289, inputRect, guiFunc,"asset");

        }

        void guiFunc(int wId) {
            GUILayout.BeginVertical();
            GUILayout.Box(Assets.StolenAssetViewer());
            if (GUILayout.Button("next texture")) {
                Assets.textureNumber++;
                if (Assets.textureNumber == Assets.textures.Length) Assets.textureNumber = 0;
            }
            GUILayout.EndVertical();
            GUI.DragWindow(new Rect(0, 0, 500, 500));
        }
    }
}
