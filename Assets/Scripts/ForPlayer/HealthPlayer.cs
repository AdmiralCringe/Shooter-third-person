using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    private float maxHealthPlayer = 100;
    private float currentHealthPlayer;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image infectionBar;
    
    [HideInInspector]
    public float radioactiveInfection;

    private float radiationProtection;
    private float damageProtection;

    private void Start()
    {
        currentHealthPlayer = maxHealthPlayer;
        radiationProtection = 1;
        damageProtection = 1;
    }

    public void GetStats(float radiationProtection, float damageProtection)
    {
        this.radiationProtection = radiationProtection;
        this.damageProtection = damageProtection;
    }
    public void GetDamage(float damage)
    {
        currentHealthPlayer -= damage / damageProtection;
    }
    
    public void GetRadiation(float radiationDamage)
    {
        if(radioactiveInfection < 100)
        radioactiveInfection += radiationDamage;
    }

    private void GetRadDamage()
    {
        float deltaTime = Time.deltaTime;
        currentHealthPlayer -= ((radioactiveInfection/50) / radiationProtection)  * deltaTime;
    }

    private void Update()
    {
        GetRadDamage();
        if (currentHealthPlayer <= 0)
        {
            Time.timeScale = 0.1f;
        }

        healthBar.fillAmount = currentHealthPlayer / maxHealthPlayer;
        infectionBar.fillAmount = radioactiveInfection / 100;
    }
}
