using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PlayerController playerController;

    public GameManager GameManager => gameManager;
    public PlayerController PlayerController => playerController;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}