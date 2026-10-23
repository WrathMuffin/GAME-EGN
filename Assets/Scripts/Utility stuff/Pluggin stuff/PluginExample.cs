using UnityEngine;

public class PluginExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyPlugin.ID = 67;
        Debug.Log(MyPlugin.ID);

        //MyPlugin.Position = new Vector2D { x = 6.0f, y = 7.0f };
        //Debug.Log(MyPlugin.Position);
    }
}
