using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    private FPSCamera fpsCam;
    public Button deutButton, protButton, tritButton, defButton;

    public GameObject buttons;
    public ColorManager colorManager;
    
    // Start is called before the first frame update
    void Start()
    {
        // get active camera
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FPSCamera>();

        // hide the menu buttons
        buttons.SetActive(false);

        // connect the buttons to the functions in the script
        deutButton.onClick.AddListener(DeutOnClick);
        protButton.onClick.AddListener(ProtOnClick);
        tritButton.onClick.AddListener(TritOnClick);
        defButton.onClick.AddListener(DefOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Toggle the UI menu with escape
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (fpsCam.FollowMouse){

                // unlock cursor and freeze camera movement
                fpsCam.FollowMouse = false;

                //display colorblind options
                buttons.SetActive(true);
            }
            else {

                fpsCam.FollowMouse = true;
                buttons.SetActive(false);
            }
        }
    }


    void DeutOnClick(){
        colorManager.ImageColor = colorManager.deutCrosshair;
        colorManager.OutlineColor = colorManager.deutHighlight;
    }

    void ProtOnClick(){
        colorManager.ImageColor = colorManager.protCrosshair;
        colorManager.OutlineColor = colorManager.protHighlight;
    }

    void TritOnClick(){
        colorManager.ImageColor = colorManager.tritCrosshair;
        colorManager.OutlineColor = colorManager.tritHighlight;
    }

    void DefOnClick(){
        colorManager.ImageColor = colorManager.defCrosshair;
        colorManager.OutlineColor = colorManager.defHighlight;
    }
}
