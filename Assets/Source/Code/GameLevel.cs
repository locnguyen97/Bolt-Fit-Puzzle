using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsTarget;
    public List<GameObject> gameObjectsPoint;
    [SerializeField] private Transform parentListObj;
    [SerializeField] private Transform parentListObjPoint;
    private bool canCheck = true;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObj)
        {
            gameObjectsTarget.Add(tr.gameObject);
            tr.gameObject.SetActive(false);
        }
        foreach (Transform tr in parentListObjPoint)
        {
            if (tr.GetComponent<TouchPoint>())
            {
                gameObjectsPoint.Add(tr.gameObject);
                tr.gameObject.SetActive(true);
            }
        }
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        if (canCheck)
        {
            if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }
    
    public void RemoveObjectTarget(GameObject obj)
    {
        gameObjectsTarget.Remove(obj);
    }
}
