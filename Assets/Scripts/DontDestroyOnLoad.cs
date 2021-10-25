using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject[] objects;

  void Awake(){
      foreach (var element in objects)
      {
          DontDestroyOnLoad(element);
      }
      
  }
}
