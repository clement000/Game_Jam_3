using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MovingTerrain : MonoBehaviour
{
    public float speed = 0.3f;

    public List<GameObject> Level1List;
    
    private float currentBuiltDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = gameObject.GetComponent<Transform>();
        transform.position = new Vector3(0, 0, -16);
        Level1List = Resources.LoadAll<GameObject>("Platforms/Levels/1").ToList();
        InitializePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -speed * 0.01f);
        if (transform.position.z + currentBuiltDistance < 2)
        {
            AddLevelToPlatforms();
        }
    }

    void InitializePlatforms()
    {
        GameObject initializer = Instantiate(Resources.Load("Platforms/Levels/Initializer"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        initializer.transform.parent = gameObject.transform;
        initializer.transform.localPosition = new Vector3(0, 0, 0);
        currentBuiltDistance += initializer.GetComponent<Properties>().length;
        GameObject levelToBuild = Level1List[Random.Range(0, Level1List.Count)];
        GameObject newLevel = Instantiate(levelToBuild, new Vector3(0, 0, currentBuiltDistance), Quaternion.identity) as GameObject;
        newLevel.transform.parent = gameObject.transform;
        newLevel.transform.localPosition = new Vector3(0, 0, currentBuiltDistance);
        currentBuiltDistance += newLevel.GetComponent<Properties>().length;
    }

    void AddLevelToPlatforms()
    {
        GameObject levelToBuild = Level1List[Random.Range(0, Level1List.Count)];
        GameObject newLevel = Instantiate(levelToBuild, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newLevel.transform.parent = gameObject.transform;
        newLevel.transform.localPosition = new Vector3(0, 0, currentBuiltDistance);
        currentBuiltDistance += newLevel.GetComponent<Properties>().length;
    }
}
