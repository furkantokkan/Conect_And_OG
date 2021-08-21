using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public List<Transform> poses = new List<Transform>();
    public int[] levelPoses;
    public List<Transform> hitColliders = new List<Transform>();
    List<Transform> oldColliders = new List<Transform>();
    Collider[] tempColliders;
    public LayerMask targetLayer;
    Collider tempCollider;
    public int aiIndex;
    private void Update()
    {
        if (LevelManager.gameState == GameState.Normal)
        {
            tempColliders = Physics.OverlapSphere(transform.position, 3f, targetLayer);
            if (tempColliders.Length > 0)
            {
                tempCollider = tempColliders[0];
                PosControl(tempCollider.transform);
            }
        }
    }

    void PosControl(Transform posObject)
    {
        if (!hitColliders.Contains(posObject) && !oldColliders.Contains(posObject))
        {
            hitColliders.Add(posObject);
            oldColliders.Add(posObject);
        }
    }

    void TempFunc()
    {
        hitColliders[0].position = poses[aiIndex].position;
        hitColliders[0].SetParent(poses[aiIndex]);
        hitColliders[0].GetComponent<Collider>().enabled = false;
        hitColliders.RemoveAt(0);
        aiIndex++;
    }

    public void AIAdder()
    {
        if (PlayerController.wifiStack == 1 && aiIndex < 2 && hitColliders.Count > 0)
        {
            TempFunc();
        }
        else if (PlayerController.wifiStack == 2 && aiIndex < 5 && hitColliders.Count > 0)
        {
            TempFunc();
        }
        else if (PlayerController.wifiStack >= 3 && aiIndex < 9 && hitColliders.Count > 0)
        {
            TempFunc();
        }
        //Camera Geniþliði ayarlama
        if (aiIndex > 5)
        {
            Camera.main.fieldOfView = 92;
        }
        else if (aiIndex > 2)
        {
            Camera.main.fieldOfView = 88;
        }
        else if (aiIndex > 0)
        {
            Camera.main.fieldOfView = 84;
        }
    }
}
