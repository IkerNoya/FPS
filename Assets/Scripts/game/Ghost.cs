using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public float health = 100.0f;
    float timerLimit = 3;
    float timerDestroy;
    bool dead = false;
    public float movementSpeed;
    float savedMovementSpeed;
    int damage = 20;
    public int rotationSpeed = 1;
    bool isAttacking = false;
    float attackSpeed;

    float timerSel = 0;
    float limit = 1.5f;
    bool change = false;
    int selection = 0;
    int selComp = 10;

    enum ghostStates
    {
        idle,
        attack
    };

    enum Directions
    {
        forward,
        backwards,
        left,
        right
    };

    ghostStates state;
    Directions enemyDirection;
    public Transform player;
    public Player PlayerS;

    Vector3 direction;
    Vector3 movement;
    private void Start()
    {
        state = ghostStates.idle;
        timerDestroy = 0;
        savedMovementSpeed = movementSpeed;
        attackSpeed = movementSpeed + 2;
    }

    private void Update()
    {
        if (!dead)
        {
            timerSel += Time.deltaTime;
            if (timerSel > limit)
            {
                change = true;
                timerSel = 0;
            }

            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < 20)
            {
                state = ghostStates.attack;
                movementSpeed = attackSpeed;
            }
            if (state == ghostStates.attack && distance > 20)
            {
                state = ghostStates.idle;
                movementSpeed = savedMovementSpeed;
            }
            States();
        }

        if (dead)
        {
            isAttacking = false;
            timerDestroy += Time.deltaTime;
            if (timerDestroy >= timerLimit)
            {
                Destroy(gameObject);
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

    void States()
    {
        Quaternion rotAngle;
        movement = direction.normalized * movementSpeed * Time.deltaTime;
        switch (state)
        {
            case ghostStates.idle:
                RandomDir();
                break;

            case ghostStates.attack:
                StartCoroutine(enemyAttack());
                if (isAttacking)
                {
                    rotAngle = Quaternion.LookRotation(player.position - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotAngle, rotationSpeed * Time.deltaTime);
                    direction = player.position - transform.position;
                    transform.position += movement;
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 10)
        {
            PlayerS.Hurt(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 9)
        {
            enemyDirection = Directions.backwards;
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

    void RandomDir()
    {
        Quaternion rot;
        Vector3 move;

        if (change)
        {
            if (selection!=selComp)
            {
                selection = Random.Range(0, 3);
            }
            else
            {
                selection = Random.Range(0, 3);
            }

            if (selection == 0)
            {
                enemyDirection = Directions.forward;
            }
            if (selection == 1)
            {
                enemyDirection = Directions.left;
            }
            if (selection == 2)
            {
                enemyDirection = Directions.backwards;
            }
            if (selection == 3)
            {
                enemyDirection = Directions.right;
            }
            selComp = selection;
            change = false;
        }

        switch(enemyDirection)
        {
            case Directions.left:

                rot = Quaternion.LookRotation(Vector3.left);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
                direction = transform.forward;
                move = direction * movementSpeed * Time.deltaTime;
                transform.position += movement;
                break;
            case Directions.right:

                rot = Quaternion.LookRotation(Vector3.right);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
                direction = transform.forward;
                move = direction * movementSpeed * Time.deltaTime;
                transform.position += movement;
                break;
            case Directions.backwards:

                rot = Quaternion.LookRotation(Vector3.back);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
                direction = transform.forward;
                move = direction * movementSpeed * Time.deltaTime;
                transform.position += movement;
                break;
            case Directions.forward:

                rot = Quaternion.LookRotation(Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
                direction = transform.forward;
                move = direction * movementSpeed * Time.deltaTime;
                transform.position += movement;
                break;

        }

    }

}

