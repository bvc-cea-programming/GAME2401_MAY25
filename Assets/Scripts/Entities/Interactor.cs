using UnityEngine;

public class Interactor : MonoBehaviour
{
    private IInteractable _currentInteractable;

    void OnTriggerEnter(Collider col)
    {
        _currentInteractable = col.gameObject.GetComponent<IInteractable>();
        if (_currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }
    
}
