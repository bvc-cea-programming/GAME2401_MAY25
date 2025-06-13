using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrollingState : IState
{
    private EnemyStateMachine _stateMachine;

    // Constructor to call when the state instance is created
    public EnemyPatrollingState(EnemyStateMachine machine)
    {
        _stateMachine = machine;
    }

    private NavMeshAgent _navMeshAgent;
    private PatrollingPointsManager _pointsManager;
    private Vector3 _currentPatrolTarget;

    public void EnterState()
    {
        // cache the references from the state machine
        Debug.Log("Entering the patrolling state");
        _navMeshAgent = _stateMachine.agent;
        _pointsManager = _stateMachine.pointsManager;

        // get a random target from the patrol point manager
        GetRandomPointAndMove();
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        Patrol();
        CheckForSuspiciousActivity();
        CheckForPlayer();
    }

    private void Patrol()
    {
        // check the distance for the current point
        // if the distance is small, then request the next point
        // move to that point
        if (_navMeshAgent.remainingDistance <= .5f)
        {
            GetRandomPointAndMove();
        }
    }

    private void GetRandomPointAndMove()
    {
        _currentPatrolTarget = _pointsManager.GetRandomPatrolPoint();
        _navMeshAgent.SetDestination(_currentPatrolTarget);
    }

    private void CheckForSuspiciousActivity()
    {

    }

    public void CheckForPlayer()
    {
        //next week
    }
}
