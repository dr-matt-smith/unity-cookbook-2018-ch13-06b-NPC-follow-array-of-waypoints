using UnityEngine;
using System.Collections;

public class ArrowNPCMovement : MonoBehaviour {
	private GameObject targetGO = null;
	private WaypointManager waypointManager;
	private UnityEngine.AI.NavMeshAgent navMeshAgent;
	
	void Start ()
	{
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		waypointManager = GetComponent<WaypointManager>();
		HeadForNextWayPoint();
	}

	void Update () 
	{
		float closeToDestinaton = navMeshAgent.stoppingDistance * 2;
		if (navMeshAgent.remainingDistance < closeToDestinaton){
			HeadForNextWayPoint ();
		}
	}

	private void HeadForNextWayPoint ()
	{
		targetGO = waypointManager.NextWaypoint (targetGO);
		navMeshAgent.SetDestination (targetGO.transform.position);
	}
}
