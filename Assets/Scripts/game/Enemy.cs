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
    public int rotationSpeed = 1;
    bool isAttacking = false;

    enum ghostStates
    {
        idle,
        attack
    };
    ghostStates state;
    public Transform player;

    Vector3 direction;
    Vector3 movement;

    public Collider playerCol;

    private void Start()
    {
        state = ghostStates.attack;
        timerDestroy = 0;
    }

    private void Update()
    {
        States();

        if (dead)
        {
            isAttacking = false;
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

    void States()
    {
        switch (state)
        {
            case ghostStates.idle:

                break;

            case ghostStates.attack:
                StartCoroutine(enemyAttack());
                if (isAttacking)
                {
                    Quaternion rotAngle = Quaternion.LookRotation(player.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotAngle, rotationSpeed * Time.deltaTime);
                    direction = player.position - transform.position;
                    movement = direction * movementSpeed * Time.deltaTime;
                    transform.position += movement;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playerCol.gameObject == player)
        {
            Player playerS = GetComponent<Player>();
            if (player != null)
            {
                playerS.takeDamage(damage);
                Destroy(this);
            }
        }
    }
    
    IEnumerator enemyAttack() // probablemente sea innecesario, pero funciona bien de momento
    {
        while (!dead)
        {
            isAttacking = true;
            yield return null;
        }
    }

}

