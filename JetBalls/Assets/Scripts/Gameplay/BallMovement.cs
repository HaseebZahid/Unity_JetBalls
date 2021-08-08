using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    public TweenRectTransformPosition posTweener;
    public TweenRotation tweenRotation;

    public TweenScale effectsTween;

    public Vector2 startPos = new Vector2(150, -30);

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            posTweener.StartTween();

    }

    public void HandleInput()
    {
        if (!GameManager.instance.isPlaying)
            return;

        if (posTweener.IsPlaying)
            return;

        posTweener.StartTween();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " collided with " + col.name);

        if (col.name.Contains("Obstacle_"))
        {
            GameManager.instance.GameOver();
            effectsTween.StartTween();
        }
    }

    public void Reset()
    {
        posTweener.StopTween();
        tweenRotation.StartTween();
        effectsTween.StopTween();
        effectsTween.transform.localScale = Vector3.zero;
        GetComponent<RectTransform>().anchoredPosition = startPos;
    }

    public void StopMovement()
    {
        posTweener.StopTween();
        tweenRotation.StopTween();
    }
}
