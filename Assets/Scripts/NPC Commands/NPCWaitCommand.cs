using UnityEngine;

public class NPCWaitCommand : ICommand
{
    private bool _isComplete;

    public bool IsComplete => _isComplete;

    private float _timer;
    private float _timeToComplete;
    private bool _isTimerRunning;

    public NPCWaitCommand(float timeToWait)
    {
        _timeToComplete = timeToWait;
        _isComplete = false;
        
    }

    public void Execute()
    {
        
        if (!_isTimerRunning && !_isComplete)
        {
            IntitiateWait();
        }

        if (_isTimerRunning)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToComplete)
            {
                _isComplete = true;
                _isTimerRunning = false;
            }
        }
    }

    private void IntitiateWait()
    {
        Debug.Log("Wait command started!");
        _timer = 0;
        _isTimerRunning = true;
    }
}
