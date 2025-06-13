using UnityEngine;
using UnityEngine.AI;

public class NPCMoveToDestinationCommand : ICommand
{
    private bool _isComplete;
    public bool IsComplete => _isComplete;

    private NavMeshAgent _agent;
    private Vector3 _destination;
    private float _destinationCheckThreshold;

    private bool _isMoving;

    //Constructor to initiate the values
    public NPCMoveToDestinationCommand(NavMeshAgent currentAgent, Vector3 target, float destinationCheck = 0.1f)
    {
        // initiate all the values
        _agent = currentAgent;
        _destination = target;
        _destinationCheckThreshold = destinationCheck;
        _isMoving = false;
        _isComplete = false;
    }

    public void Execute()
    {
        // check for the distance
        if (_isMoving && _agent.remainingDistance <= _destinationCheckThreshold)
        {
            _isComplete = true;
        }

        // check the condition and start the movement
        if (!_isMoving && !_isComplete)
        {
            InitiateMovement();
        }
    }

    private void InitiateMovement()
    {
        Debug.Log("Move to destination started " + _destination);
        _agent.destination = _destination;
        _isMoving = true;
    }
    
}
