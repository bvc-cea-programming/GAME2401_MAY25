using System;
using UnityEngine;

public class PointAndClickManager : MonoBehaviour
{
    [SerializeField] private float maxRayDistance;
    public event Action<Vector3> OnClicked;

    private Camera _mainCamera;
    private RaycastHit hit;

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (!_mainCamera) return;

        if (!Input.GetMouseButtonDown(0)) return;

        if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit, maxRayDistance))
        {
            IClickable clickable = hit.transform.GetComponent<IClickable>();

            if (clickable == null) return; // If clickable is null, exit

            clickable.OnClicked(hit.point); // call the onclicked in clickable
            OnClicked?.Invoke(hit.point); // invoke the onclicked event
        }

    }
}
