using UnityEngine;

public class PlayerBuildStrategy : IStrategy
{
    private PlayerStratManager _stratManager;

    public PlayerBuildStrategy(PlayerStratManager manager)
    {
        _stratManager = manager;
    }

    public void Execute()
    {
        _stratManager.mPlayerBuilder.Build(_stratManager.ClickedPoint);
    }
}
