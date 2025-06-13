using UnityEngine;

public class Floor : MonoBehaviour, IClickable
{
    public void OnClicked(Vector3 point)
    {
        Debug.Log(point);
    }
}
