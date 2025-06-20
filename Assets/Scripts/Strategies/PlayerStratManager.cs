using UnityEngine;

public class PlayerStratManager : MonoBehaviour
{
    [SerializeField] private PointAndClickManager pointAndClickManager;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private PlayerBuilder playerBuilder;
    public PlayerMover mPlayerMover => playerMover; // property only to get access to the ref
    public PlayerBuilder mPlayerBuilder => playerBuilder; 

    
    //Create references for the strategies
    private PlayerMoveStrategy _playerMoveStrategy;
    private PlayerBuildStrategy _playerBuildStrategy;
    private PlayerTerminalStretegy _playerTerminalStrategy;

    //
    private IStrategy _currentStrategy;
    public Vector3 ClickedPoint{ get; private set; }
    public IClickable ClickedTarget { get; private set; }

    private void Awake()
    {
        _playerMoveStrategy = new PlayerMoveStrategy(this);
        _playerBuildStrategy = new PlayerBuildStrategy(this);
        _playerTerminalStrategy = new PlayerTerminalStretegy();
    }

    private void OnEnable()
    {
        pointAndClickManager.OnClicked += ExecuteStrategy;
    }

    private void OnDisable()
    {
        pointAndClickManager.OnClicked -= ExecuteStrategy;
    }

    public void ExecuteStrategy(Vector3 clickedPoint, IClickable clickedTarget)
    {
        ClickedPoint = clickedPoint;
        ClickedTarget = clickedTarget;
        _currentStrategy?.Execute();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentStrategy = _playerMoveStrategy;
            Debug.Log("Switched to Move Strat");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Switched to Build Strat");
            _currentStrategy = _playerBuildStrategy;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Switched to Terminal Strat");
            _currentStrategy = _playerTerminalStrategy;
        }

    }
}
