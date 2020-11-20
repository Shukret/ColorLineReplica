using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        //смещение оффсета текстурки по оси x - "движение моря"
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
