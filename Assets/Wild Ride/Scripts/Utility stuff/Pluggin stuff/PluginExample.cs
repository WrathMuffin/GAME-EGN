using UnityEngine;

public class PluginExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyPlugin.ID = 67;
        Debug.Log(MyPlugin.ID);
    }
}
