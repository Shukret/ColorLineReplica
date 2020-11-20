using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelName : MonoBehaviour
{
    [SerializeField] private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        //текст показатель уровня
        txt.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
