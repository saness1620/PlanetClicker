using UnityEngine;

[CreateAssetMenu(fileName = "New Planet Data", menuName = "Create New Planet Data", order = 54)]
public class PlanetData : ScriptableObject
{
    public string Name;
    public string Description;
    public int Cost;
    public Sprite Icon;
}
