using GUI = UnityEngine.GUI;
using Action = System.Action;
using Color = UnityEngine.Color;
using Texture2D = UnityEngine.Texture2D;
using Rect = UnityEngine.Rect;
using Texture = UnityEngine.Texture;
using Vector2 = UnityEngine.Vector2;
using GUIStyle = UnityEngine.GUIStyle;
using MonoBehavior = UnityEngine.MonoBehavior;

public class Plugin : MonoBehavior
{
  public Texture2D tex = GUILib.MakeTex(1,1,Color.White);

  public Rect windowRect = new Rect(10,10,400,600);

  public bool ExampleBoolean;

  void OnGUI()
  {
    GUILib.doWindow(ref windowRect, (GUI.WindowFunction)myWindow, tex, Color.Black, 20f, 0);
  }

  void myWindow(int id)
  {
    //Display the window name
    GUI.Label(new Rect(125, 10, 200, 200), "Cheat Name");

    //Create a checkbox
    GUILib.CheckBoxToggle(ref ExampleBoolean, new Vector2(10, 40), "Name", windowTex);

    GUI.DragWindow();
  }
}
