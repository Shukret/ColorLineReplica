using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float speedRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //вращение объекта
        transform.Rotate(speedRotate*Vector3.up*Time.deltaTime);
    }
}
