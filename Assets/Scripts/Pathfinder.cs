using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawnner enemySpawnner;
    WaveConfigSO waveConfig; // refernce for Wavescriptable script
    List<Transform> waypoints;   //store waypoints
    int wayPointIndex = 0;   // showing current index

    private void Awake()
    {
        enemySpawnner = FindObjectOfType<EnemySpawnner>();
    }
    void Start()
    {
        waveConfig = enemySpawnner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[wayPointIndex].position;
    }


    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayPointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
