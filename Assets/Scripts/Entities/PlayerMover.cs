using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void MovePlayer(Vector3 movePosition)
    {
        if (!_agent) return;
        _agent.destination = movePosition;
    }

}
