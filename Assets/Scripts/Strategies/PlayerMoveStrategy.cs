using UnityEngine;

public class PlayerMoveStrategy : IStrategy
{

    PlayerMover _playerMover;
    PlayerStratManager _stategyManager;

    public PlayerMoveStrategy(PlayerStratManager manager)
    {
        _stategyManager = manager;
    }

    public void Execute()
    {
        //Debug.Log("Player should move now");
        // check if the IClickable is the floor
        // if the clicked target is not the floor, do nothing
        if (_stategyManager.ClickedTarget.GetType() != typeof(Floor)) return;

        // Move the player towards the target
        _stategyManager.mPlayerMover.MovePlayer(_stategyManager.ClickedPoint);
        
    }
}
