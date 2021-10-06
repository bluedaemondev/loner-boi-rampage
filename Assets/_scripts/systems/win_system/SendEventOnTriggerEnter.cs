using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SendEventOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string eventTriggered;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        EventManager.ExecuteEvent(eventTriggered);
        Destroy(this.gameObject);
    }

}
