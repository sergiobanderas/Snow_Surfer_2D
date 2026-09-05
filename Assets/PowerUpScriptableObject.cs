using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Scriptable Objects/PowerUpScriptableObject")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private float valueChange;
    [SerializeField] private float time;

    public string PowerUpType { get => powerUpType; set => powerUpType = value; }
    public float ValueChange { get => valueChange; set => valueChange = value; }
    public float Time { get => time; set => time = value; }
}
