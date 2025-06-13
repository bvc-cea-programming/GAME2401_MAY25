using UnityEngine;
using UnityEngine.Events;

public class GamePlayState : MonoBehaviour, IState
{
    [SerializeField] private StateManager gameStateManager;

    public UnityEvent OnEnterState;
    public UnityEvent OnUpdateState;
    public UnityEvent OnExitState;

    public void EnterState()
    {
        Debug.Log("Entering gameplay state");
        OnEnterState?.Invoke();
    }

    public void ExitState()
    {
        Debug.Log("Exiting the gameplay state");
        OnExitState?.Invoke();
    }

    public void UpdateState()
    {
        Debug.Log("Updating in the gameplay state");
        OnUpdateState?.Invoke();
    }

    public void PauseGame()
    {
        gameStateManager.ChangeState(gameStateManager.gamePauseState);
    }
}
