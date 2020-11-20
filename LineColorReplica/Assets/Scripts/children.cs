using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class children : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        //создание эффекта "волны" при столкновении с морем
        if (other.CompareTag("sea"))
        {
            Instantiate(explosion,new Vector3(transform.position.x, transform.position.y  + 5, transform.position.z), new Quaternion(0,0,0,1));
        }
    }
}
