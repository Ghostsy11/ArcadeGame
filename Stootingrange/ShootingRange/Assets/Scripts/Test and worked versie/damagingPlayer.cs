using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damagingPlayer : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public Image healthBar;
    public float playerHealth = 100;
    private bool isDead;
    private void Update()
    {

        if (playerHealth <= 0 && !isDead)
        {
            isDead = true; 
            gameObject.SetActive(false);
            gameManagerScript.gameOver();
            Debug.Log("Dead");
        }

    }



    public void TakeDamageOnPlayer(float hp)
    {
        playerHealth -= hp;
        healthBar.fillAmount = playerHealth / 100;

    }
    

    public void Healing(float healHp)
    {
        playerHealth += healHp;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);

        healthBar.fillAmount = playerHealth / 100;
    }

}
