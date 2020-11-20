using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //перезагрузка уровня при смерти
        if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
