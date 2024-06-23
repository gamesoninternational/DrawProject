using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyObject;
    public GameObject Draw;
    public GameObject[] DrawList1, DrawList2;
    public GameObject prefabParticleSystem; // Reference to the particle system prefab
    public Transform particleSystemSpawnLocation; // Reference to the spawn location for the particle system

    void Start()
    {
        SetRandomActive();
    }

    void Update()
    {
        CheckAndDestroyEnemy();
    }

    // Function to randomly set one GameObject from each list to active
    public void SetRandomActive()
    {
        // Deactivate all GameObjects in DrawList1 and DrawList2
        foreach (GameObject obj in DrawList1)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in DrawList2)
        {
            obj.SetActive(false);
        }

        // Randomly select one GameObject from each list and activate it
        int randomIndex1 = Random.Range(0, DrawList1.Length);
        int randomIndex2 = Random.Range(0, DrawList2.Length);

        DrawList1[randomIndex1].SetActive(true);
        DrawList2[randomIndex2].SetActive(true);
    }

    // Function to check if all GameObjects in DrawList1 and DrawList2 are inactive and destroy EnemyObject
    void CheckAndDestroyEnemy()
    {
        bool allInactive = true;

        // Check if all GameObjects in DrawList1 are inactive
        foreach (GameObject obj in DrawList1)
        {
            if (obj.activeSelf)
            {
                allInactive = false;
                break;
            }
        }

        // Check if all GameObjects in DrawList2 are inactive
        if (allInactive)
        {
            foreach (GameObject obj in DrawList2)
            {
                if (obj.activeSelf)
                {
                    allInactive = false;
                    break;
                }
            }
        }

        // If all are inactive, destroy the EnemyObject and instantiate the particle system
        if (allInactive)
        {
            Vector3 spawnPosition = particleSystemSpawnLocation != null ? particleSystemSpawnLocation.position : EnemyObject.transform.position;
            GameObject particleSystemInstance = Instantiate(prefabParticleSystem, spawnPosition, Quaternion.identity);
            Destroy(EnemyObject);

            // Destroy the particle system after its duration has finished
            DestroyParticleSystemAfterDuration(particleSystemInstance);
        }
    }

    // Function to destroy the particle system after its duration
    void DestroyParticleSystemAfterDuration(GameObject particleSystemInstance)
    {
        ParticleSystem ps = particleSystemInstance.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            // Get the duration of the particle system
            float duration = ps.main.duration;

            // Schedule the destruction of the particle system
            Destroy(particleSystemInstance, duration);
        }
    }
}
