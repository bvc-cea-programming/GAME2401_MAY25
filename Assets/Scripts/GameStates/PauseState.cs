using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PauseState : MonoBehaviour, IState
{
    [SerializeField] private StateManager gameStateManager;

    public UnityEvent OnEnterState;
    public UnityEvent OnUpdateState;
    public UnityEvent OnExitState;

    public void EnterState()
    {
        Debug.Log("Entering pause state");

        Time.timeScale = 0;

        OnEnterState?.Invoke();
    }

    public void ExitState()
    {
        Debug.Log("Exiting the pause state");
        Time.timeScale = 1;
        OnExitState?.Invoke();
    }

    public void UpdateState()
    {
        Debug.Log("Updating in the pause state");
        OnUpdateState?.Invoke();
    }

    public void ResumeGame()
    {
        gameStateManager.ChangeState(gameStateManager.gamePlayState);
    }
}
