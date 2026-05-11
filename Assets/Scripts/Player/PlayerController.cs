using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public PlayerData playerData;
    public Slider hpSlider;
    public Text hpText;

    private float currentHP;
    private PlayerInput playerInput;
    private Vector2 moveInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        currentHP = playerData.maxHP;

        if (hpSlider != null)
        {
            hpSlider.maxValue = playerData.maxHP;
        }

        UpdateHPUI();
    }
    
    
    void Update()
    {
        if (playerInput == null) return;
        
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        float h = moveInput.x;
        float v = moveInput.y;

        transform.Translate(new Vector3(h, v, 0) * playerData.moveSpeed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TakeDamage(0.1f);
        }
    }

    void TakeDamage(float dmg)
    {
        currentHP = Mathf.Max(currentHP - dmg, 0f);
        Debug.Log("Player HP: " + currentHP);

        UpdateHPUI();

        if (currentHP <= 0f)
        {
            GameManager.Instance.GameOver();
        }
    }

    void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.value = currentHP;
        }

        if (hpText != null)
        {
            hpText.text = $"HP: {currentHP:0}/{playerData.maxHP:0}";
        }
    }
}