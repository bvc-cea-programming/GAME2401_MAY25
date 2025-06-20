using UnityEngine;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject buildPrefab;
    [SerializeField] private float buildMaxDistance = 5;

    public void Build(Vector3 buildPoint)
    {
        if (Vector3.Distance(transform.position, buildPoint) > buildMaxDistance)
        {
            Debug.Log("Too far dude!");
            return;
        }

        var obj = Instantiate(buildPrefab, buildPoint, Quaternion.identity);
        obj.transform.forward = transform.forward;
    }
}
