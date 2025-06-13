using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{

    private PointAndClickManager _pointAndClickManager;
    private NavMeshAgent _agent;

    void Awake()
    {
        // Ask the service locator to locate the point and click manager
        _pointAndClickManager = ServiceLocator.instance.GetService<PointAndClickManager>();
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        _pointAndClickManager.OnClicked += MovePlayer;
    }

    void OnDisable()
    {
        _pointAndClickManager.OnClicked -= MovePlayer;
    }

    private void MovePlayer(Vector3 movePosition)
    {
        if (!_agent) return;

        _agent.destination = movePosition;
    }


    
}
