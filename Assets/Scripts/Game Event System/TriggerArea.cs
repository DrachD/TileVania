using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private int id;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvent.Instance.DoorwayTriggerEnter(id);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameEvent.Instance.DoorwayTriggerExit(id);
    }
}
