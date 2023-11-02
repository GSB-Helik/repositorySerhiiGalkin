using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 30f;
    public int damage = 20;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);

        if (transform.position == position)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            CarAttack attack = other.GetComponent<CarAttack>();
            attack._health -= damage;

            Transform healtBar = other.transform.GetChild(0).transform;
            healtBar.localScale = new Vector3(
                healtBar.localScale.x - 0.3f,
                healtBar.localScale.y,
                healtBar.localScale.z);

            if (attack._health <= 0)
                Destroy(other.gameObject);
        }
    }

}
