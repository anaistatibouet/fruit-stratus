using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddFruit(1);
            Destroy(objectToDestroy);
        }
    } 
}
