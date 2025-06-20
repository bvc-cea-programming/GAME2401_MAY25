using UnityEngine;

public class PlayerTerminalStretegy : IStrategy
{
    public void Execute()
    {
        Debug.Log("Player interacts with the terminal");
    }
}
