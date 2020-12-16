using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using System;

public class PlayerMovement : NetworkBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.isLocalPlayer)
            return;
        MovePlayer();
        
    }

    private void MovePlayer()
    {
        Vector2 desiredPosition = transform.position;
        if (Input.GetKeyDown("up"))
        {
            desiredPosition = (Vector2)transform.position + Vector2.up;
        } else if (Input.GetKeyDown("down"))
        {
            desiredPosition = (Vector2)transform.position + Vector2.down;
        } else if (Input.GetKeyDown("left"))
        {
            desiredPosition = (Vector2)transform.position + Vector2.left;
        } else if (Input.GetKeyDown("right"))
        {
            desiredPosition = (Vector2)transform.position + Vector2.right;
        }
        if (desiredPosition != (Vector2)transform.position && SpaceIsClear(desiredPosition))
        {
            transform.position = desiredPosition;
        }   
    }

    private bool SpaceIsClear(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        Debug.Log(pos + " " + hit.collider);

        return hit.collider == null;
    }
}
