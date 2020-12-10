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
        }

        public ModMenuIntegration MMI = null;

        private void Update() {
            if (MMI == null) { MMI = gameObject.AddComponent<ModMenuIntegration>(); }
        }


        private void OnGUI() {
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(10, 10, 100, 25), "LLBM Mod Test");
        }
    }
}
