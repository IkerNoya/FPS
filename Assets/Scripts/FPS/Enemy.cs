using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f;
    float timerLimit = 3;
    bool dead = false;
    float timerDestroy;
    private void Start()
    {
        timerDestroy = 0;
    }

    private void Update()
    {
        if (dead == true)
        {
            timerDestroy += Time.deltaTime;
            Debug.Log(timerDestroy);
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
}

