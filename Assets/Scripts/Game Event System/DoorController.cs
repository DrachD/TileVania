using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int id;
    private void Start()
    {
        GameEvent.Instance.OnDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvent.Instance.OnDoorwayTriggerExit += OnDoorwayClose;
    }
    private void OnDoorwayOpen(int id)
    {
        if (id != this.id) return;
        Debug.Log("open");
        gameObject.SetActive(false);
    }
    private void OnDoorwayClose(int id)
    {
        if (id != this.id) return;
        Debug.Log("close");
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvent.Instance.OnDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvent.Instance.OnDoorwayTriggerExit -= OnDoorwayClose;
    }
}
