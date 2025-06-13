using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    // ENEMY STATES
    public EnemyPatrollingState enemyPatrollingState { get; private set; }

    // EXTERNAL REFERENCES
    [SerializeField] private NavMeshAgent m_agent;
    public NavMeshAgent agent => m_agent;
    [SerializeField] private PatrollingPointsManager m_pointsManager;
    public PatrollingPointsManager pointsManager => m_pointsManager;


    private IState _currentState;

    public void ChangeState(IState nextState)
    {
        _currentState?.ExitState();
        _currentState = nextState;
        _currentState.EnterState();
    }

    void Awake()
    {
        // Create state instances
        enemyPatrollingState = new EnemyPatrollingState(this);

        //set the first state
        ChangeState(enemyPatrollingState);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        _currentState?.UpdateState();
    }
}
