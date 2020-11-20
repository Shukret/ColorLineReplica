using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation.Examples;

public class Player : MonoBehaviour
{
    //путь
    [SerializeField] private PathFollower pf;
    //эффект дыма
    [SerializeField] private ParticleSystem particles;

    //UI-элементы
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private Image img;
    [SerializeField] private Text restartTxt;


    //мини-частицы для разрыва на части после смерти
    [SerializeField] private GameObject[] children;
    //цвет куба
    [SerializeField] private Material startColor;
    //trail
    [SerializeField] private Color trailColor;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Gradient gradient;
    float alpha = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        //украшаем все необходимое на старте 
        img.color = trailColor;
        for (int i = 0; i < children.Length; i++)
        {
            children[i].GetComponent<MeshRenderer>().material = startColor;
        }
         gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(trailColor, 1.0f), new GradientColorKey(trailColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        mesh.material = startColor;
        trail.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        //Нажатие мыши
        if (Input.GetMouseButtonDown(0))
        {
            particles.Play();
            if (menu.activeSelf==true)
                menu.SetActive(false);
        }
        //Отпустили мышь
        if(Input.GetMouseButtonUp(0))
        {
            particles.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //смерть
        if (other.CompareTag("destroy"))
        {
            gameObject.SetActive(false);
            deathMenu.SetActive(true);
            restartTxt.color = trailColor;
            restartTxt.text = (int)pf.result + "% COMPLETED";
            for (int i = 0; i < children.Length; i++)
            {
                particles.Stop();
                children[i].SetActive(true);
            }
        }
    }
}
