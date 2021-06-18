using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int numCars;
    public List<SerializableVector3> carPositions = new List<SerializableVector3>();
    public List<SerializableQuaternion> carRotations = new List<SerializableQuaternion>();
    public SerializableVector3 frogPosition;

    public string name;
    public int lives;
    public int livesUsed;
    public float carSpeed;
    public int score;
}
