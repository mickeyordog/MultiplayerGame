using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onTickCallback += Move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        //Debug.Log("Move");
    }
}
