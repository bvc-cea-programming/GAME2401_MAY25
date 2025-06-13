using UnityEngine;
using UnityEngine.Events;

public class MenuState : MonoBehaviour, IState
{
    [SerializeField] private StateManager gameStateManager;

    public UnityEvent OnEnterState;
    public UnityEvent OnUpdateState;
    public UnityEvent OnExitState;

    public void EnterState()
    {
        Debug.Log("Entering menu state");
        OnEnterState?.Invoke();
    }

    public void ExitState()
    {
        Debug.Log("Exiting the menu state");
        OnExitState?.Invoke();
    }

    public void UpdateState()
    {
        Debug.Log("Updating in the menu state");
        OnUpdateState?.Invoke();
    }

    public void StartGame()
    {
        gameStateManager.ChangeState(gameStateManager.gamePlayState);
    }
}
