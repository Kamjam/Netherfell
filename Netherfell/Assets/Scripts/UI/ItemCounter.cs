using UnityEngine;
using TMPro;

public class ItemCounter : MonoBehaviour
{
    //self reference that can be used anywhere
    public static ItemCounter instance;
    [SerializeField] public TMP_Text countTextL;
    [SerializeField] public TMP_Text countTextR;

    public int currentLeft;
    public int currentRight;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //makes sure texts are deactivated and that the numbers display 0
        countTextL.enabled = false;
        countTextR.enabled = false;

        countTextL.text = currentLeft.ToString();
        countTextR.text = currentRight.ToString();

    }

    //functions to increment item count
    public void increaseLeftSlot(int amount)
    {
        countTextL.enabled = true;
        currentLeft += amount;

        countTextL.text = currentLeft.ToString(); 
    }

    public void increaseRightSlot(int amount)
    {
        countTextR.enabled = true;
        currentRight += amount;

        countTextR.text = currentRight.ToString(); 
    }

    //functions to decrease the item count
    public void decreaseLeftSlot(int amount)
    {
        currentLeft -= amount;
        countTextL.text = currentLeft.ToString(); 

        //disable text when there are no more
        if(currentLeft <= 0)
        {
            countTextL.enabled = false;
        } 
    }

    public void decreaseRightSlot(int amount)
    {
        currentRight -= amount;
        countTextR.text = currentRight.ToString();

        if(currentRight <= 0)
        {
            countTextR.enabled = false;
        } 
    }
}
