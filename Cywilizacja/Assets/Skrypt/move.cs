using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class move : MonoBehaviour
{
    public bool isMoving = false;
    Hero hero;
    public List<Image> path;
    private int totalSteps;
    private int currentStep;
    Vector3 targetPos;
    float speedOfAnim = 2f;
    internal bool lookingToTheRight = true;//determines the rotation of the hero
    SpriteRenderer heroSprite;//SpriteRenderer component reference
    BattaleControler battaleControler;

    void Start()
    {
        hero = GetComponent<Hero>();
        heroSprite = GetComponent<SpriteRenderer>();
        battaleControler = FindObjectOfType<BattaleControler>();
    }

    void Update()
    {
        if (isMoving)
            HeroIsMoving();
    }
    public void StartsMoving()
    {
        battaleControler.CleanField();
        if (!(hero.getAlreadyMoved())) {
            hero.setAlreadyMoved(true);
            currentStep = 0;
            totalSteps = path.Count - 1;
            isMoving = true;
            ResetTargetPos();
        }
    }
    private void ResetTargetPos()
    {
        targetPos = new Vector3(path[currentStep].transform.position.x,
      path[currentStep].transform.position.y,
      transform.position.z);
        ControlDirection(targetPos);
    }
    private void HeroIsMoving()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos,
                        speedOfAnim * Time.deltaTime);
        ManageSteps();
    }
    private void ManageSteps()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f
      && currentStep < totalSteps)
        {
            currentStep++;
            ResetTargetPos();
        }
        else if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            StopsMoving();
        }
    }
    private void StopsMoving()
    {
        isMoving = !isMoving;

    }
    internal void ControlDirection(Vector3 targetPos)
    {

        if (transform.position.x > targetPos.x && lookingToTheRight ||
            transform.position.x < targetPos.x && !lookingToTheRight)
        {
            heroSprite.flipX = !heroSprite.flipX;
            lookingToTheRight = !lookingToTheRight;
        }
    }
}
