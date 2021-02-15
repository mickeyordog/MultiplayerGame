using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Follower follower;
    private Collider2D coll;
    private Vector3 desiredPos;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        desiredPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        transform.position = Vector3.Lerp(transform.position, desiredPos, 10f * Time.deltaTime);
    }


    private void MovePlayer()
    {
        Vector2 desiredDirection;
        if (Input.GetKeyDown("up"))
        {
            desiredDirection = Vector2.up;
            
        } else if (Input.GetKeyDown("down"))
        {
            desiredDirection = Vector2.down;
        } else if (Input.GetKeyDown("left"))
        {
            desiredDirection = Vector2.left;
        } else if (Input.GetKeyDown("right"))
        {
            desiredDirection = Vector2.right;
        } else
        {
            return;
        }
        if (SpaceIsClear(desiredDirection))
        {
            follower.SetPosition(desiredPos);
            desiredPos +=  (Vector3)desiredDirection;
            GameManager.instance.Tick();
        } 
            
    }

    private bool SpaceIsClear(Vector2 direction)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, 1f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == coll)
                continue;
            if (hit.collider && !hit.collider.isTrigger)
                return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var portal = collision.GetComponent<Portal>();
        if (portal)
        {
            Debug.Log("Going to level " + portal.nextLevel);
        }
    }
}
