using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject objectToDestroy;

    public int fruitValue = 1;
    public int healing = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddFruit(fruitValue);
            Destroy(objectToDestroy);
            PlayerHealth.instance.RestoreHealth(healing);
        }
    } 
}
