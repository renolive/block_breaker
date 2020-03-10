using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName="LevelState", menuName="State/LevelState")]
public class LevelState : ScriptableObject, ISerializationCallbackReceiver
{
    public int InitialBlockCount = 0;
    public int BlockPoints = 83;
    public int Score = 0;

    public LevelEvent levelEvent;

    [System.NonSerialized]
    private int RuntimeBlockCount, RuntimeScore;

    public int CurrentScore {
        get => RuntimeScore;
    }


    public void OnBeforeSerialize() { }


    public void OnAfterDeserialize() {
        RuntimeBlockCount = InitialBlockCount;
        RuntimeScore = Score;
    }


    public void CountBreakableBlocks() {
        RuntimeBlockCount++;
    }


    public void DestroyBlock() {
        RuntimeScore += BlockPoints;
        levelEvent?.RaiseBlockBroke();

        RuntimeBlockCount--;
        if (RuntimeBlockCount <= 0) {
            levelEvent?.LevelCleared();
        }
    }
}
