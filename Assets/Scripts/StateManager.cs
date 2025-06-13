using UnityEngine;

public class StateManager : MonoBehaviour
{

    // state manager to know all the available states
    public MenuState menuState;
    public GamePlayState gamePlayState;
    public GameOverState gameOverState;
    public PauseState gamePauseState;


    private IState _currentState;

    
    public void ChangeState(IState newState)
    {
        // check if there is a current state and if so, exit
        _currentState?.ExitState();

        // change the current state to the new state
        _currentState = newState;

        // enter the new state
        _currentState.EnterState();
    }


    void Start()
    {
        //Set the default state
        ChangeState(menuState);
    }


    void Update()
    {
        
        _currentState?.UpdateState();
        
    }
}
