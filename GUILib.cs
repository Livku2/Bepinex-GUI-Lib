using GUI = UnityEngine.GUI;
using Action = System.Action;
using Color = UnityEngine.Color;
using Texture2D = UnityEngine.Texture2D;
using Rect = UnityEngine.Rect;
using Texture = UnityEngine.Texture;
using ScaleMode = UnityEngine.ScaleMode;
using Vector2 = UnityEngine.Vector2;
using GUIStyle = UnityEngine.GUIStyle;

namespace UnityUILib.Gui
{
    public class GUILib
    {
        public static Texture2D MakeTex(int width, int height, Color colour)
        {
            Color[] array = new Color[width * height];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = colour;
            }
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(array);
            texture2D.Apply();
            return texture2D;
        }
        public static void TextBox(ref string text, Rect rect, bool Encrypted, Texture texture, Color color, float rounded)
        {
            GUI.backgroundColor = Color.clear;
            if (Encrypted)
            {
                text = GUI.TextArea(rect, text);
            }
            else
            {
                text = GUI.TextArea(rect, text);
            }
            GUI.DrawTexture(new Rect(rect.x -3, rect.y -3, rect.width, rect.height), texture, ScaleMode.StretchToFill, true, 0f, color, 0f, 20f);
            GUI.Label(rect, text);
        }
        public static void doWindow(ref Rect rect, GUI.WindowFunction windowFunction, Texture texture, Color colour, float rounded, int windowNum)
        {
            GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill, true, 0f, colour, 0f, rounded);
            GUI.backgroundColor = Color.clear;
            rect = GUI.Window(windowNum, rect, windowFunction, "");
        }
        public static bool Toggle(ref bool toggled, Rect rect, string text, Texture texture, float rounded, Color colour1, Color colour2)
        {
            GUIStyle guistyle = new GUIStyle(GUI.skin.button);
            guistyle.hover.textColor = new Color(guistyle.normal.textColor.r + 0.3f, guistyle.normal.textColor.g + 0.3f, guistyle.normal.textColor.b + 0.3f);
            GUI.backgroundColor = Color.clear;
            if (GUI.Button(rect, "", guistyle))
            {
                toggled = !toggled;
            }
            GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill, true, 0f, colour1, 0f, rounded);
            GUI.Label(new Rect(rect.x + rect.width + 10f, rect.y, rect.width * 3f, rect.height * 3f), text);
            if (toggled)
            {
                GUI.DrawTexture(new Rect(rect.x + 22f, rect.y + 2.5f, 15f, 15f), texture, ScaleMode.StretchToFill, true, 0f, colour2, 0f, rounded);
            }
            else
            {
                GUI.DrawTexture(new Rect(rect.x + 3f, rect.y + 2.5f, 15f, 15f), texture, ScaleMode.StretchToFill, true, 0f, colour2, 0f, rounded);
            }
            return toggled;
        }
        public static void Button(Rect rect, Action action, Color color, string text, Texture2D texture)
        {
            GUIStyle guistyle = new GUIStyle(GUI.skin.button);
            guistyle.hover.textColor = new Color(guistyle.normal.textColor.r + 0.3f, guistyle.normal.textColor.g + 0.3f, guistyle.normal.textColor.b + 0.3f);
            GUI.DrawTexture(rect, texture, ScaleMode.StretchToFill, true, 0f, color, 0f, 3f);
            GUI.backgroundColor = Color.clear;
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(rect.x + 2f, rect.y + 2f, rect.width - 4f, rect.height - 4f), text, guistyle))
            {
                action();
            }
        }
        public static void TabButton(Rect rect, string text, ref string pageText, Texture texture, float rounded, Color colour)
        {
            GUIStyle guistyle = new GUIStyle(GUI.skin.button);
            guistyle.hover.textColor = new Color(guistyle.normal.textColor.r + 0.4f, guistyle.normal.textColor.g + 0.4f, guistyle.normal.textColor.b + 0.4f);
            GUI.backgroundColor = Color.clear;
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(rect.x + 2f, rect.y + 2f, rect.width - 4f, rect.height - 4f), text, guistyle))
            {
                pageText = text;
            }
            if (pageText == text)
            {
                GUI.DrawTexture(new Rect(0f, rect.y, 5f, rect.height), texture, ScaleMode.StretchToFill, true, 0f, colour, 0f, rounded);
            }
        }
        public static bool CheckBoxToggle(ref bool boolean, Vector2 pos, string text, Texture2D texture, Action onDisable)
        {
            GUIStyle guistyle = new GUIStyle(GUI.skin.button);
            guistyle.hover.textColor = new Color(guistyle.normal.textColor.r + 0.3f, guistyle.normal.textColor.g + 0.3f, guistyle.normal.textColor.b + 0.3f);
            GUI.backgroundColor = Color.clear;
            if (GUI.Button(new Rect(pos.x, pos.y, 20f, 20f), "", guistyle))
            {
                if (!boolean)
                {
                    onDisable();
                }
                boolean = !boolean;
            }
            GUI.DrawTexture(new Rect(pos.x, pos.y, 20f, 20f), texture, ScaleMode.StretchToFill, true, 0f, Color.black, 0f, 4f);
            GUI.Label(new Rect(pos.x + 30f, pos.y, 90f, 90f), text);
            if (boolean)
            {
                GUI.DrawTexture(new Rect(pos.x, pos.y, 20f, 20f), texture, ScaleMode.StretchToFill, true, 0f, Color.white, 0f, 4f);
            }
            return boolean;
        }
        public static bool CheckBoxToggle(ref bool boolean, Vector2 pos, string text, Texture2D texture)
        {
            GUIStyle guistyle = new GUIStyle(GUI.skin.button);
            guistyle.hover.textColor = new Color(guistyle.normal.textColor.r + 0.3f, guistyle.normal.textColor.g + 0.3f, guistyle.normal.textColor.b + 0.3f);
            GUI.backgroundColor = Color.clear;
            if (GUI.Button(new Rect(pos.x, pos.y, 20f, 20f), "", guistyle))
            {
                boolean = !boolean;
            }
            GUI.DrawTexture(new Rect(pos.x, pos.y, 20f, 20f), texture, ScaleMode.StretchToFill, true, 0f, Color.black, 0f, 4f);
            GUI.Label(new Rect(pos.x + 30f, pos.y, 90f, 90f), text);
            if (boolean)
            {
                GUI.DrawTexture(new Rect(pos.x, pos.y, 20f, 20f), texture, ScaleMode.StretchToFill, true, 0f, Color.white, 0f, 4f);
            }
            return boolean;
        }
    }
}
