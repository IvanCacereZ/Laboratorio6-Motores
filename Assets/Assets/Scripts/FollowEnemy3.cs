using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy3 : MonoBehaviour
{
    [SerializeField] private Transform Enemy3Transform;
    [SerializeField] private Rigidbody2D Enemy3RB2D;
    [SerializeField] private float velocityModifier = 5;
    [SerializeField] private Enemy3 enemy3;
    private Transform currentTarget;
    private bool isMoving;

    private void Start()
    {
        currentTarget = transform;
    }

    private void Update()
    {
        if (isMoving)
        {
            Enemy3RB2D.velocity = (currentTarget.position - Enemy3Transform.position).normalized * velocityModifier;
            CalculateDistance();
        }
        else
        {
            Enemy3RB2D.velocity = (currentTarget.position - Enemy3Transform.position).normalized * velocityModifier;
            CalculateDistance();
        }
    }

    private void CalculateDistance()
    {
        if ((currentTarget.position - Enemy3Transform.position).magnitude < 0.05f)
        {
            Enemy3Transform.position = currentTarget.position;
            isMoving = false;
            Enemy3RB2D.velocity = Vector2.zero;
        }
        else
        {
            isMoving = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentTarget = other.transform;
            enemy3.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentTarget = transform;
            enemy3.enabled = true;
        }
    }
}
