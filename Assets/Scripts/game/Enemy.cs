using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f;
    float timerLimit = 3;
    float timerDestroy;
    bool dead = false;
    public float movementSpeed;
    int damage = 20;

    public Transform player;

    Vector3 direction;
    Vector3 movement;

    public Collider playerCol;

    private void Start()
    {
        timerDestroy = 0;
    }

    private void Update()
    {
        direction = player.position - transform.position;
        movement = direction * movementSpeed * Time.deltaTime;

        if (!dead)
        {
            transform.position += movement;
        }

        if (dead)
        {
            timerDestroy += Time.deltaTime;
            if (timerDestroy >= timerLimit)
            {
                Die();
            }
        }
    }
    public void takeDamage(float ammount)
    {
        health -= ammount;
        if (health <= 0)
        {
            dead = true;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playerCol.gameObject == player)
        {
            Player playerS = GetComponent<Player>();
            if (player!=null)
            {
                playerS.takeDamage(damage);
                Destroy(this);
            }
        }
    }

}

