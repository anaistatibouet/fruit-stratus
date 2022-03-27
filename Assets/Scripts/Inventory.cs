using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int fruitCount;
    public Text fruitCountText;
    public static Inventory instance;

    public void Awake(){

        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }

        instance = this;
    }

    public void AddFruit(int countItem){
        fruitCount += countItem;
        fruitCountText.text = fruitCount.ToString();
    }

    public void ResetFruitCount(){
        fruitCount = 0;
        fruitCountText.text = fruitCount.ToString();
    }
}
