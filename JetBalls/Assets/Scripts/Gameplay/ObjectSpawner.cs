using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public Sprite obstacle;

    public float spawnTime_min, spawnTime_max;
    private float nextSpawnTime, nextDifficultyChangeTime;

    List<RectTransform> spawnedObjects = new List<RectTransform>();

    private void Update()
    {
        
        HandleObstacleSpawn();
        HandleDifficulty();
    }

    public void HandleDifficulty()
    {
        if (Time.time > nextDifficultyChangeTime)
        {
            spawnTime_min -= 0.25f;
            spawnTime_max -= 0.5f;

            spawnTime_min = Mathf.Max(3f, spawnTime_min);
            spawnTime_max = Mathf.Max(7f, spawnTime_max);

            nextDifficultyChangeTime = Time.time + 5f;
        }
    }

    void HandleObstacleSpawn()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObstacle();

            nextSpawnTime = Time.time + Random.Range(spawnTime_min, spawnTime_max);
        }
    }

    void SpawnObstacle()
    {
        GameObject spawnObject = new GameObject("Obstacle_" + Mathf.CeilToInt(Time.time));
        spawnObject.transform.SetParent(transform);
        RectTransform rectTransform = spawnObject.AddComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
        spawnedObjects.Add(rectTransform);
        Image imageComp = spawnObject.AddComponent<Image>();
        imageComp.sprite = obstacle;

        rectTransform.anchorMin = new Vector2(1, 0);
        rectTransform.anchorMax = new Vector2(1, 0);
        rectTransform.pivot = new Vector2(0.5f, 0);

        rectTransform.anchoredPosition3D = new Vector3(50, 0, 0);
        imageComp.SetNativeSize();

        EdgeCollider2D edgeCollider2D = spawnObject.AddComponent<EdgeCollider2D>();
        edgeCollider2D.points = new Vector2[] { new Vector2(-3.73f, 96.46f), new Vector2(-58.4f, 16.3f), new Vector2(61.91f, 14.18f), new Vector2(-3.73f, 96.46f) };

        Rigidbody2D rigidbody2D = spawnObject.AddComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0f;
        rigidbody2D.velocity = new Vector2(-5f, 0f);

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }

    public void Reset()
    {
        foreach(RectTransform spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject.gameObject);
        }
        spawnedObjects.Clear();

        spawnTime_min = 5f;
        spawnTime_max = 15f;

        nextDifficultyChangeTime = Time.time + 5f;
        nextSpawnTime = Time.time + Random.Range(spawnTime_min, spawnTime_max);
    }
}
