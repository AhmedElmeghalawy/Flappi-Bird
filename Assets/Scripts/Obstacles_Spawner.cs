using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Spawner : MonoBehaviour {

    public float Obstacles_Instantiate_Time = 2f;
    public float Obstacles_moveSpeed = 2f;


    List<GameObject> obstaclesList = new List<GameObject>();

    public GameObject _obstaclePrefab;

    float _timer;



    void Start() {
        for (int i = 0; i < 6; i++) {
            // Instantiate a new obstacle
            GameObject t_obstacle = Instantiate(_obstaclePrefab, new Vector3(5f, Random.Range(4f, -2f), -1f), Quaternion.identity);
            obstaclesList.Add(t_obstacle);
            t_obstacle.gameObject.SetActive(false);
        }

        _timer = Obstacles_Instantiate_Time;
    }


    public void Spawning() {
        _timer -= Time.deltaTime;

        for (int i = 0; i < obstaclesList.Count; i++) {

            if (obstaclesList[i].transform.position.x <= -10) {
                obstaclesList[i].gameObject.SetActive(false);
            }
        }

        if (_timer <= 0f) {

            for (int i = 0; i < obstaclesList.Count; i++) {
                if (!obstaclesList[i].gameObject.activeInHierarchy) {
                    //reposition obstacle to a new initialization point.
                    obstaclesList[i].gameObject.SetActive(true);
                    obstaclesList[i].transform.position = new Vector3(5f, Random.Range(4.0f, -2f), -1f);
                    break;
                }
            }

            _timer = Obstacles_Instantiate_Time;
        }

        //make obstacles move to the left
        for (int i = 0; i < obstaclesList.Count; i++) {
            if (obstaclesList[i].gameObject.activeInHierarchy) {
                obstaclesList[i].transform.position = new Vector3(obstaclesList[i].transform.position.x - (Obstacles_moveSpeed * Time.deltaTime), obstaclesList[i].transform.position.y, -1f);
            }
        }


    }



}
