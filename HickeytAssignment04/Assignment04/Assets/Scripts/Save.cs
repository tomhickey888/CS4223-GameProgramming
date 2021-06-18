using System.Collections.Generic;

[System.Serializable]

public class Save
{
    public int numPins;
    public List<SerializableVector3> pinPositions = new List<SerializableVector3>();
    public List<SerializableQuaternion> pinRotations = new List<SerializableQuaternion>();

    public string name;
    public int score;
    public int lives;
    public float timer;
    public float rotationSpeed;
    public float pinSpeed;
}
