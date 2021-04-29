using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/ChangePlayerInventory")]
public class ChangePlayerGun : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("GrapplingHook"))
        {
            PlayerFire player = other.gameObject.GetComponent<PlayerFire>();
            player.canFire = true;
            GameManager setUI = FindObjectOfType<GameManager>();
            setUI.EnableGrapplingHookUI();
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Gun"))
        {
            PlayerFire player = other.gameObject.GetComponent<PlayerFire>();
            player.allowWeaponChanging = true;
            GameManager setUI = FindObjectOfType<GameManager>();
            setUI.EnableGunUI();
            Destroy(gameObject);
        }
        FindObjectOfType<AudioManager>().Play("CollectItem");
    }
}
