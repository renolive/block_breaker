using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="LevelEvent", menuName="Events/LevelEvent")]
public class LevelEvent : ScriptableObject {
    public delegate void LevelClear();
    public event LevelClear OnLevelClear;

    public delegate void BlockBroke();
    public event BlockBroke OnBlockBroke;

    public void LevelCleared() => OnLevelClear?.Invoke();

    public void RaiseBlockBroke() => OnBlockBroke?.Invoke();
}
