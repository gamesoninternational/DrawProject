using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTag : MonoBehaviour
{
    public GameObject[] gameObjectsToTag; // Drag and drop the GameObjects you want to tag in the Inspector
    private string[] tags = { "HorizontalLine", "VerticalLine", "Diagonal Line /" };

    void Start()
    {
        AssignRandomTags();
    }

    void AssignRandomTags()
    {
        foreach (GameObject obj in gameObjectsToTag)
        {
            if (obj != null)
            {
                string randomTag = tags[Random.Range(0, tags.Length)];
                obj.tag = randomTag;
            }
        }
    }
}
