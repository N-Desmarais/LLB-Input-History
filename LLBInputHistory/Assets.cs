using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LLBInputHistory {
    public static class Assets {
        //Asset bundle stolen from Daioutzu's input viewer mod
        static string bundle = "C:\\Users\\njdes\\Documents\\GitHub\\LLB-Input-History\\LLBInputHistory\\Assets\\Bundles\\ui";

        static AssetBundle stolenBundle;
        static Font inputViewerFont;
        //public static Dictionary<string, Texture2D> stolenAssets = new Dictionary<string, Texture2D>();
        public static Texture2D[] textures;

        public static int textureNumber = 0;

        public static void LoadAssets() {
            Debug.Log("bbb");
            try {
            stolenBundle = AssetBundle.LoadFromFile(bundle);
            textures = stolenBundle.LoadAllAssets<Texture2D>();
            foreach (Texture2D t in textures) {
                if (t.name != "Font Texture") {
                    byte[] bytes = t.EncodeToPNG();
                    File.WriteAllBytes("C:\\Users\\njdes\\Documents\\GitHub\\LLB-Input-History\\LLBInputHistory\\Assets\\" + t.name + ".png", bytes);
                }
            }
            inputViewerFont = stolenBundle.LoadAsset<Font>("assets/ui/elements.ttf");
            } catch (Exception e) {
                Debug.Log(e.ToString());
            }
        }

        public static Texture2D StolenAssetViewer() {
            Texture2D texture = textures[textureNumber];
            return texture;
        }
    }
}
