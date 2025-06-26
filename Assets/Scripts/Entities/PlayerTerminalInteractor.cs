using UnityEngine;

public class PlayerTerminalInteractor : MonoBehaviour
{
    public void Interact(IClickable interactable)
    {
        interactable?.OnClicked(Vector3.zero);
    }
}
