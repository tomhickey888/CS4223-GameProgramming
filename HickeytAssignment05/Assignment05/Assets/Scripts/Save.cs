using System.Collections.Generic;

[System.Serializable]
public class Save
{
    public int numWords;
    public List<SerializableVector3> wordPositions = new List<SerializableVector3>();
    public string name;
    public float wordSpeed;
    public int score;
}