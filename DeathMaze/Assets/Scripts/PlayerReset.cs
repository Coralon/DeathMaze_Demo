using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReset : MonoBehaviour
{
    Transform ResetPoint;
    public bool KillCheckPointOnTouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        if (ResetPoint != null)
        {
            this.gameObject.transform.position = ResetPoint.position;
        }
        else
        {
            ReloadCurrentScene();
        }
        FindObjectOfType<AudioManager>().Play("Death");
        Debug.Log("Player Reset");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillBox"))
        {
            PlayerInventory playerDeath = gameObject.GetComponent<PlayerInventory>();
            playerDeath.changePoints(1);
            Reset();
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Debug.Log("Checkpoint");
            ResetPoint = other.transform;
            if (KillCheckPointOnTouch)
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}