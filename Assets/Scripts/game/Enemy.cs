using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    float timerSel = 0;
    float limit = 3;
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

    Vector3 direction;
    Vector3 movement;

    private void Start()
    {
        state = ghostStates.idle;
        timerDestroy = 0;
    }

    private void Update()
    {
        timerSel += Time.deltaTime;
        if (timerSel>3)
        {
            change = true;
            timerSel = 0;
        }
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
        Quaternion rotAngle;
        movement = direction * movementSpeed * Time.deltaTime;
        switch (state)
        {
            case ghostStates.idle:
                randomDir();
                Debug.Log(enemyDirection);
                
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Player")
        {
            Player playerS = GetComponent<Player>();
            if (player != null)
            {
                playerS.takeDamage(damage);
                Destroy(this);
            }
        }
        if (collision.gameObject.layer == 9)
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

    void randomDir()
    {
        Quaternion rot;
        Vector3 move;
        Debug.Log(timerSel);
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

