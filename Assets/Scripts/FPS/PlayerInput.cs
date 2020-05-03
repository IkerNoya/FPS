using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask rayLayer;

    public float range;
    public float damage;


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, rayLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            shoot(transform.position, hit.transform.position);
        }
    }

    void shoot(Vector3 from, Vector3 to)
    {
        Vector3 direction = to-from;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {

        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, rayLayer))
        {
           Enemy enemy =  hit.transform.GetComponent<Enemy>();
           Rigidbody rigid = hit.transform.GetComponent<Rigidbody>();
            if (enemy!=null)
            {
                enemy.takeDamage(damage);
                if (enemy.health <= 0)
                {
                    rigid.AddForce(direction * 200);
                }
            }
        }
    }
}
