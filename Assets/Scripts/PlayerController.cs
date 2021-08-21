using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    public float mouseSensivity = 1f;
    public float forwardSpeed = 3f;
    public static int wifiStack = 0;

    Image wifiSprite;

    void Start()
    {
        wifiSprite = transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (LevelManager.gameState == GameState.Normal)
        {
            transform.Translate(Vector3.forward * forwardSpeed / 100);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wifiStick"))
        {
            other.gameObject.SetActive(false);
            StackControl(true);
            GetComponent<AIController>().AIAdder();
            //Debug.Log("wifiStack " + wifiStack);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
            StackControl(false);
            //Debug.Log("wifiStack " + wifiStack);
        }
    }

    public void StackControl(bool status)
    {
        Color color = new Color(0.25f, 0.25f, 0.25f, 0f);
        if (status && wifiStack < 4)
        {
            wifiStack++;
            wifiSprite.color += color;
        }
        else if(!status && wifiStack > 0)
        {
            wifiStack--;
            wifiSprite.color -= color;
        }
        else if (!status && wifiStack <= 0)
        {
            Debug.Log("GAME OVER!");
            LevelManager.gameState = GameState.Failed;
        }
    }

    public void MoveControl(float mouseX)
    {
        Vector3 tempPos = transform.localPosition;
        if (LevelManager.gameState == GameState.Normal)
        {
            tempPos.x += mouseX * Time.deltaTime * mouseSensivity * 1000;
            tempPos.x = Mathf.Clamp(tempPos.x, -1.5f, 1.5f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, tempPos, 0.8f);
        }
    }
}
