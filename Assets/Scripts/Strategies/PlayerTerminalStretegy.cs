using UnityEngine;

public class PlayerTerminalStretegy : IStrategy
{
    private PlayerStratManager _stratManager;

    public PlayerTerminalStretegy(PlayerStratManager manager)
    {
        _stratManager = manager;
    }

    public void Execute()
    {
        _stratManager.mTerminalInteractor.Interact(_stratManager.ClickedTarget);
    }
}
