using UnityEngine;
using UnityEngine.Events;

public class GameOverState : MonoBehaviour, IState
{
    [SerializeField] private StateManager gameStateManager;

    public UnityEvent OnEnterState;
    public UnityEvent OnUpdateState;
    public UnityEvent OnExitState;

    public void EnterState()
    {
        Debug.Log("Entering game over state");
        OnEnterState?.Invoke();
    }

    public void ExitState()
    {
        Debug.Log("Exiting the game over state");
        OnExitState?.Invoke();
    }

    public void UpdateState()
    {
        Debug.Log("Updating in the game over state");
        OnUpdateState?.Invoke();
    }
}
