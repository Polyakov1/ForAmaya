using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
   [SerializeField] private int rows;
   [SerializeField] private int columns; 

    public int GetRows()
    {
        return rows;
    }
    public int GetColumns()
    {
        return columns;
    }
}
