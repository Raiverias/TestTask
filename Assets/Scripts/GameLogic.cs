using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    public UI ui;
    private void GameCompletionCheck() 
    {
        if(items.Count == 9) 
        {
            Debug.Log("Game Complete");
        }
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (items.Contains(collision.gameObject) == false) { items.Add(collision.gameObject); }
        GameCompletionCheck();
        ui.UpdateUI(items.Count);
    }
    private void OnTriggerExit(Collider collision)
    {
        if (items.Contains(collision.gameObject)) { items.Remove(collision.gameObject); }
        ui.UpdateUI(items.Count);
    }

}
