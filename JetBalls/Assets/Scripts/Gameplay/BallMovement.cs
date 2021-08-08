using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    public TweenRectTransformPosition posTweener;
    public TweenRotation tweenRotation;

    public Vector2 startPos = new Vector2(150, -30);

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            posTweener.StartTween();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " collided with " + col.name);

        if (col.name.Contains("Obstacle_"))
        {
            GameManager.instance.GameOver();
        }
    }

    public void Reset()
    {
        posTweener.StopTween();
        tweenRotation.StartTween();
        GetComponent<RectTransform>().anchoredPosition = startPos;
    }

    public void StopMovement()
    {
        posTweener.StopTween();
        tweenRotation.StopTween();
    }
}
