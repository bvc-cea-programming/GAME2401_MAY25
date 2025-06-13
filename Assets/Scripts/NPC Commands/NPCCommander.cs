using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCommander : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PatrollingPointsManager pointsManager;
    [SerializeField] private List<Transform> avaialbleTerminals = new List<Transform>();

    [SerializeField] private float defaultWaitTime = 5f;

    private Queue<ICommand> commandQueue = new Queue<ICommand>();

    private ICommand _currentCommand;


    void Start()
    {
        CreatePatrollingCommandQueue();
    }

    void CreatePatrollingCommandQueue()
    {
        //create three commands
        // 1. go to a random point
        NPCMoveToDestinationCommand moveToFirstPoint = new NPCMoveToDestinationCommand(agent, pointsManager.GetRandomPatrolPoint());
        commandQueue.Enqueue(moveToFirstPoint);

        // 2. wait 
        NPCWaitCommand defaultWait = new NPCWaitCommand(defaultWaitTime);
        commandQueue.Enqueue(defaultWait);

        
        //select a terminal
        Transform targetTerminal = avaialbleTerminals[Random.Range(0, avaialbleTerminals.Count)];
        IInteractable terminalInteractable = targetTerminal.GetComponent<IInteractable>();
        // 3. go the selected terminal
        NPCMoveToDestinationCommand moveToRandomTerminal = new NPCMoveToDestinationCommand(agent, targetTerminal.position, 2f);
        commandQueue.Enqueue(moveToRandomTerminal);

        // 4. wait for some time
        NPCWaitCommand defaultWaitBeforeTerminal = new NPCWaitCommand(2.0f);
        commandQueue.Enqueue(defaultWaitBeforeTerminal);

        // 5. interact with the terminal
        NPCInteractCommand terminalInteract = new NPCInteractCommand(terminalInteractable);
        commandQueue.Enqueue(terminalInteract);

        // 6. wait for some time
        NPCWaitCommand defaultWaitAfterTerminal = new NPCWaitCommand(2.0f);
        commandQueue.Enqueue(defaultWaitAfterTerminal);

        // 7. go to a second random point
        NPCMoveToDestinationCommand moveToSecondPoint = new NPCMoveToDestinationCommand(agent, pointsManager.GetRandomPatrolPoint());
        commandQueue.Enqueue(moveToSecondPoint);

        //set the first command
        _currentCommand = commandQueue.Dequeue();
    }


    void Update()
    {
        _currentCommand?.Execute();

        // check if the current command is complete. If so, move to the next command
        if (_currentCommand != null && _currentCommand.IsComplete)
        {
            if (commandQueue.Count > 0)
                _currentCommand = commandQueue.Dequeue();
            else
                CreatePatrollingCommandQueue(); // avoid executing the last command event after completion
        }
    }
}
