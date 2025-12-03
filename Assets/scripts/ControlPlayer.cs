using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    float speed, rotatioAroundY;
    Animator anim;
    CharacterController controller;
    AnimatorStateInfo info;
    bool isTalking = false;

    GameObject objectToPickUp;
    bool itemToPickUpNearBy = false;
    GameObject userMessage;

    GameObject healthUI, skillsUI, shopUI;
    [Header("Health Settings")]
    [Tooltip("Health value between 0 and 100")]
    public int health = 50;

    public bool shopIsDisplayed;
    GameObject weapon;
    bool weaponIsActive = false;

    // Start is called before the first frame update
    //public void IncreaseHealth (int amount)
    //{

    // health += amount;
    //if (health > 100) health = 100;
    //print("Health: " + health);
    //GameObject.Find("healthBar").GetComponent<ManageBar>().SetValue(health);

    //}

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // userMessage = GameObject.Find("userMessage");
        //userMessage.SetActive(false);

        // GameObject.Find("healthBar").GetComponent<ManageBar>().SetValue(health);
        //  shopUI = GameObject.Find("shopUI");
        //  shopUI.SetActive(false);
        // weapon = GameObject.Find("playerWeapon").gameObject; weapon.SetActive(false);
        // }

        // Update is called once per frame
    }
    void Update()
    {
        if (isTalking) return;
        info = anim.GetCurrentAnimatorStateInfo(0);
        speed = Input.GetAxis("Vertical");
        rotatioAroundY = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", speed);
        gameObject.transform.Rotate(0, rotatioAroundY, 0);
        if (speed > 0) controller.Move(transform.forward * speed * 2.0f * Time.deltaTime);


    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.name == "Diana" && !isTalking)
        {

            hit.collider.gameObject.GetComponent<DialogueSystem>().startDialogue();
            isTalking = true;
            anim.SetFloat("speed", 0);
            hit.collider.isTrigger = true;
            hit.collider.gameObject.GetComponent<BoxCollider>().size = new Vector3(2, 1, 2);

        }
    }
    public void EndTalking()
    {

        isTalking = false;
    }
}