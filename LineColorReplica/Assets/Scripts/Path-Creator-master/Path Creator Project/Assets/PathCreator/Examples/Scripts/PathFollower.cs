using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {

        //UI
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject winPanel;
        
        //Переменные для движения
        public PathCreator pathCreator;
        [SerializeField] private GameObject follower;
        public EndOfPathInstruction endOfPathInstruction;
        [SerializeField] private float speed = 5;
        float distanceTravelled;

        //Финиш
        [SerializeField] private Animator chest;
        public PathCreator pathCreator2;
        [SerializeField] private float speed2 = 2;
        float distanceTravelled2;
        [SerializeField] private GameObject[] coins;
        [SerializeField] private GameObject Camera;
        [SerializeField] private Follow CameraFollow;


        //подсчет пройденного расстояния
        public float result;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                winPanel.SetActive(false);
            }
        }

        void Update()
        {
            if (follower && slider)
            {
                slider.value = result;
                //расчет процентов прохождения уровня для слайдера
                result = pathCreator.path.GetClosestTimeOnPath(transform.position) * 100;
                if (Input.GetMouseButtonDown(0))
                {
                    speed = 10;
                    StartCoroutine(Plus());
                }
                if (pathCreator != null && Input.GetMouseButton(0) && follower.activeSelf)
                {
                    Move();  
                }
            }
            else
            {
                Move();      
            }

            if (result >= 100)
            {
                StartCoroutine(Finish());
                Move2();
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        IEnumerator Plus()
        {
            while (speed <= 15)
            {
                speed += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }

        IEnumerator Finish()
        {
            CameraFollow.canMove = false;
            yield return new WaitForSeconds(0.7f);
            chest.SetTrigger("open");
            yield return new WaitForSeconds(1.45f);
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].SetActive(true);
            }
            winPanel.SetActive(true);
        }

        void Move()
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
        void Move2()
        {
            distanceTravelled2 += speed2 * Time.deltaTime;
            transform.position = pathCreator2.path.GetPointAtDistance(distanceTravelled2, endOfPathInstruction);
            transform.rotation = pathCreator2.path.GetRotationAtDistance(distanceTravelled2, endOfPathInstruction);
        }
    }
}