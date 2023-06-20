using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Explode : MonoBehaviour
{
    public GameObject capsulePrefab;
    public GameObject cubePrebab;
    public GameObject spherePrefab;

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Wall2"))
        {

            Instantiate(capsulePrefab, transform.position, Quaternion.identity);
            Instantiate(cubePrebab, transform.position, Quaternion.identity);
            Instantiate(spherePrefab, transform.position, Quaternion.identity);

            Vector3 randomDirection = Random.onUnitSphere;
            float randomSpeed = Random.Range(5f, 10f);

            capsulePrefab.GetComponent<Rigidbody>().velocity = randomDirection * randomSpeed;
            cubePrebab.GetComponent<Rigidbody>().velocity = randomDirection * randomSpeed;
            spherePrefab.GetComponent<Rigidbody>().velocity = randomDirection * randomSpeed;

            Destroy(gameObject);
        }
    }


}
