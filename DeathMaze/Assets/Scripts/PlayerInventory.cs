using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour {

    public int playerPoints;
    public int playerHealth;
    public bool hasKey;


    public void changeHealth(int damageInflicted)
    {
        playerHealth -= damageInflicted;
        FindObjectOfType<AudioManager>().Play("Pain");
        if (playerHealth <= 0)
        {
            //Put in here whatever should happen when player is dead
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            changePoints(1);
            playerHealth = 100;
            PlayerReset reset = FindObjectOfType<PlayerReset>();
            reset.Reset();
        }
    }

    public void changePoints (int pointsChange)
    {
        playerPoints += pointsChange;
    }
}
