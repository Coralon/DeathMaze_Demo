using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gunUI;
    [SerializeField] private GameObject grapplingHookUI;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject itemUI;
    public Text healthUI;
    public Text deathsUI;
    public Text itemText;
    private int playerHealth;
    private int playerDeaths;
    private bool controlsUIClosed = false;
    private int activeItem;

    // Start is called before the first frame update
    /*void Start()
    {
        GetPlayerHealth();
        CountDeaths();
    }*/

    // Update is called once per frame
    void Update()
    {
        GetPlayerHealth();
        CountDeaths();

        if (!controlsUIClosed)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                controlsUIClosed = true;
                controlsUI.SetActive(false);
            }
        }

        if (itemUI.activeSelf)
        {
            GetActiveItem();
        }
    }

    void GetPlayerHealth()
    {
        playerHealth = player.GetComponent<PlayerInventory>().playerHealth;
        healthUI.text = "Health: " + playerHealth.ToString();
    }

    void CountDeaths()
    {
        playerDeaths = player.GetComponent<PlayerInventory>().playerPoints;
        deathsUI.text = "Deaths: " + playerDeaths.ToString();
    }

    void GetActiveItem()
    {
        activeItem = player.GetComponent<PlayerFire>().currentWeaponNum;
        if (activeItem == 0)
        {
            itemText.text = "Grappling Hook";
        } else
        {
            itemText.text = "Gun";
        }
    }


    // UI elements called from other scripts
    public void EnableGunUI()
    {
        gunUI.SetActive(true);
        Debug.Log("UI Active" + Time.time);
        StartCoroutine(GunCollected());
    }

    IEnumerator GunCollected()
    {
        if (gunUI != null)
        {
            yield return new WaitForSeconds(5f);
            gunUI.SetActive(false);
            Debug.Log("UI Deactive" + Time.time);
        }
    }

    public void EnableGrapplingHookUI()
    {
        grapplingHookUI.SetActive(true);
        itemUI.SetActive(true);
        Debug.Log("UI Active" + Time.time);
        StartCoroutine(GrapplingHookCollected());
    }

    IEnumerator GrapplingHookCollected()
    {
        if (gunUI != null)
        {
            yield return new WaitForSeconds(10f);
            grapplingHookUI.SetActive(false);
            Debug.Log("UI Deactive" + Time.time);
        }
    }
}
