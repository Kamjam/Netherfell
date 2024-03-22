using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    //self reference that can be used anywhere
    public static GoldCounter instance;
    [SerializeField] public TMP_Text countText;
    public int currentCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        countText.text = currentCount.ToString();
    }

    //function to increment gold
    public void increaseCurrency(int amount)
    {
        currentCount += amount;
        countText.text = currentCount.ToString(); 
    }

}
