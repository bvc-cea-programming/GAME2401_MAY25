using UnityEngine;

public class PatrollingPointsManager : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;

    public Vector3 GetRandomPatrolPoint()
    {
        return patrolPoints[Random.Range(0, patrolPoints.Length)].position;
    }
}
