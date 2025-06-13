using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    [SerializeField] private Renderer renderer;

    public void Interact()
    {
        // when interacted, change the color to a random value.
        renderer.material.color = Random.ColorHSV();
    }
}
