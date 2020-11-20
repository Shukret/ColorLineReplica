using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //монет в награду за уровень
    [SerializeField] private int reward;
    //показатель награды игроку
    [SerializeField] private Text rewardTxt;
    //слудующий уровень
    [SerializeField] private string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rewardTxt.text = "+" + reward.ToString();
    }

    //кнопка получения награды и загрузки нового уровня
    public void ButtonNextLevel()
    {
        Static.coins += reward;
        SceneManager.LoadScene(nextScene);
    }
}
