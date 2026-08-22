using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WaveManager waveManager;

    public GameManager GameManager => gameManager;
    public WaveManager WaveManager => waveManager;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}