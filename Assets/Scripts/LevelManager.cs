using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager sharedInstance;

    public List<LevelBlock> allTheLevelBloks = new List<LevelBlock>();

    public List<LevelBlock> currentLevelBlocks = new
        List<LevelBlock>();

    public Transform levelStartPosition;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelBlock()
    {
        int randomIdx = Random.Range(0, allTheLevelBloks.Count);

        LevelBlock block;

        Vector3 spawPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBloks[0]);
            spawPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBloks[randomIdx]);
            spawPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].exitPoint.position;
        }

        block.transform.SetParent(this.transform, false);

        Vector3 correction = new Vector3(
            spawPosition.x-block.startPoint.position.x,
            spawPosition.y-block.startPoint.position.y,
            0
            );
        block.transform.position = correction;
        currentLevelBlocks.Add(block);
    }

    public void RemoveLevelBlock()
    {

    }

    public void RemoveAllLevelBlocks()
    {

    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();
        }
    }
}
