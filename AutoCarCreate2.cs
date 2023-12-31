using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCarCreate2 : MonoBehaviour
{
    [NonSerialized]
    public bool IsEnemy = false;
    public GameObject car;
    public float time = 5f;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        for (int i = 1; i <= 3; i++)
        {
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(
                 transform.GetChild(0).position.x + UnityEngine.Random.Range(4f, 15f),
                  transform.GetChild(0).position.y,
                   transform.GetChild(0).position.z + UnityEngine.Random.Range(4f, 15f)
                );
            GameObject spawn = Instantiate(car, pos, Quaternion.identity);

            if (IsEnemy)
                spawn.tag = "Enemy";
        }
    }

}
