using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Character enemy;
    [SerializeField] private float footOffset = .3f;
    [SerializeField] private float groundDistance = 1f;
    [SerializeField] private float wallDistance = .5f;
    private bool onWall;
    private bool onGround;
    private Vector2 directionOfSight;
    private Vector2 rayDirection;
    private Vector2 rayDirGround;
    private float damage_ = 20;
    private BoxCollider2D myBodyCollider;
    private void OnValidate()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }
    void Start()
    {
        rayDirection = Vector2.right;
        rayDirGround = Vector2.down;
    }
    void Update()
    {
        EnemyMove();
        onGround = true;
        onWall = false;
    }

    void EnemyMove()
    {
        transform.position += new Vector3(speed, 0) * Time.deltaTime;

        if (WallCheck() || !GroundCheck())
        {
            RevertBody();
        }
    }
    void RevertBody()
    {
        if (speed > 0.0f)
        {   
            transform.localScale = new Vector3(-1, 1);
        }
        if (speed < 0.0f)
        {
            transform.localScale = new Vector3(1, 1);
        }
        footOffset *= -1;
        speed *= -1;
        rayDirection *= -1;
    }

    bool GroundCheck()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position + new Vector3(footOffset, 0), rayDirGround, groundDistance, groundMask);
        Color color = groundCheck ? Color.red : Color.green;
        Debug.DrawRay(transform.position + new Vector3(footOffset, 0), rayDirGround * groundDistance, color);

        return groundCheck;
    }

    bool WallCheck()
    {
        RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, rayDirection, wallDistance, groundMask);
        Color color = wallCheck ? Color.red : Color.green;
        Debug.DrawRay(transform.position, rayDirection * wallDistance, color);

        return wallCheck;
    }

    // ---------- Collision with the Enemy Start----------- //
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage_);
        }
    }
    // ---------- Collision with the Enemy End ----------- //
}
