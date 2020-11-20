using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    //UI-элементы
    [SerializeField] private Text coinsTxt;
    [SerializeField] private GameObject img;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //текст показывает количесвто монет
        coinsTxt.text = Static.coins.ToString();
        //выключение показателя монет
        if (menuPanel.activeSelf || deathPanel.activeSelf || winPanel.activeSelf)
        {
            coinsTxt.gameObject.SetActive(true);
            img.SetActive(true);
        }
        //выключение показателя монет
        else
        {
            coinsTxt.gameObject.SetActive(false);
            img.SetActive(false);
        }
    }
}
