using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of game manager found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnTick();
    public OnTick onTickCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tick()
    {
        if (onTickCallback != null)
            onTickCallback();
    }
}
