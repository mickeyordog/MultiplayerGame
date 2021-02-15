using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Vector3 desiredPos;
    // Start is called before the first frame update
    void Start()
    {
        desiredPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPos, 10f * Time.deltaTime);
    }

    public void SetPosition(Vector3 position)
    {
        desiredPos = position;
    }
}
