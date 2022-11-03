using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Duck", menuName = "ScriptableObjects/Duck", order = 1)]
public class SODuck : ScriptableObject
{
    public string duckName;
    public int duckAttentionRadius;
    public float duckSpeed;
    public float duckRotationSpeed;
    public Mesh duckModel;
    public ScriptableObject duckFavoritFood;
}
