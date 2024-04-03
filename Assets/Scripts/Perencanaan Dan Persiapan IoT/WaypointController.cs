using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    [System.Serializable]
    public struct WaypointData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public List<WaypointData> questWaypoints; // List of quest waypoints
    private int currentWaypointIndex = 0;
    public GameObject target;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target object is not assigned in WaypointController!");
            return;
        }

        if (questWaypoints.Count > 0)
        {
            SetWaypoint(0);
        }
        else
        {
            Debug.LogError("No waypoints assigned in WaypointController!");
        }
    }

    public void CompleteQuest()
    {
        if (currentWaypointIndex < questWaypoints.Count - 1)
        {
            currentWaypointIndex++;
            SetWaypoint(currentWaypointIndex);
            Debug.Log("playit");
        }
        else
        {
            Debug.Log("All quests completed!");
        }
    }
    private void SetWaypoint(int index)
    {
        if (index < questWaypoints.Count)
        {
            target.transform.localPosition = questWaypoints[index].position;
            target.transform.localRotation = questWaypoints[index].rotation;
        }
        else
        {
            Debug.LogError("Invalid waypoint index in WaypointController!");
        }
    }

    public void Awake()
    {
        target.SetActive(true);
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target.SetActive(false);
        }
    }


}
