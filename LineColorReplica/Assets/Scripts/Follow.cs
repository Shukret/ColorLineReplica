using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //следование камеры за персонажем
        if (player.gameObject.activeSelf)
            gameObject.transform.position = new Vector3(player.position.x, gameObject.transform.position.y, player.position.z);
        //вращение камеры после выигрыша
        if (!canMove)
            gameObject.transform.Rotate(0,5*Time.deltaTime,0, Space.World);
    }
}
