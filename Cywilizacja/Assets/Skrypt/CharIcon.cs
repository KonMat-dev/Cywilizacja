using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  
public class CharIcon : MonoBehaviour
{
    [SerializeField] internal Image heroImage;
    [SerializeField] internal Image backGround;
    [SerializeField] internal TMPro.TextMeshProUGUI stackText;
    [SerializeField] internal CharAttributes charAttributes;
    internal bool deployed = false;

    STorageMNG storage;
    private void Start()
    {
        storage = GetComponentInParent<STorageMNG>();
        STorageMNG.OnClickOnGrayIcon += ReturnDefaultState;
    }

    internal void FillIcon()
    {
        heroImage.sprite = charAttributes.heroSprite;
        stackText.text = charAttributes.stack.ToString();
    }
    public void IconClicked() 
    {
        STorageMNG storage = GetComponentInParent<STorageMNG>();
        if (!deployed)//evaluates if the unit is already on the battlefield
        {
            storage.TintIcon(this);//marks a regiment to be placed on the battlefield
        }
      
    }
    public void HeroIsDeployed() 
    {
        backGround.sprite = storage.deployedRegiment;
    }

    public void ReturnDefaultState(CharAttributes selectedCharAttributes)//sets light green background to the icon
    {
        if (selectedCharAttributes == charAttributes)//determines if the icon should respond to an event
        {
            backGround.sprite = GetComponentInParent<STorageMNG>().defaultIcon; //sets light green icon
        }
    }

}
