using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject ChoiceButton;

    [Header("Plugin Components")]
    [SerializeField]
    private Transform GridParent;
    public GameObject SuccessWindowObj;
    public SuccessWindow sucessWindow;
    public GameObject FailureWindow;

    [Header("Variables")]
    public int AmountRiskIncreasedPerRound = 10;
    public int InitialRisk = 10;
    public int AmountOfChoices = 3;

    [Header("Info")]
    public int CurrentRoundNumber;


    //Privates
    private GameObject data;
    private GatheringRepo gatheringRepo;
    private List<GameObject> CurrentlySpawnedChoiceButtons = new List<GameObject>();
    public List<Item> NewYeild = new List<Item>();


    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        gatheringRepo = data.GetComponent<GatheringRepo>();

        InitializeFirstRoundOfChoices();
    }


    public void InitializeFirstRoundOfChoices()
    {
        for(int i = 0; i < AmountOfChoices; i++)
        {
            GameObject ThisChoiceButton = Instantiate(ChoiceButton, GridParent);
            GatheringChoiceButton gatheringChoiceButtonComponent = ThisChoiceButton.GetComponent<GatheringChoiceButton>();

            Item SelectedItem = SelectItemFromRepo(0);

            float RiskLevel = 10 * SelectedItem.RiskModifier;

            gatheringChoiceButtonComponent.item = SelectedItem;
            gatheringChoiceButtonComponent.RiskPercentage = RiskLevel;
            gatheringChoiceButtonComponent.FillChoiceButtonUIInfo();

            CurrentlySpawnedChoiceButtons.Add(ThisChoiceButton);
        }
    }

    public void NextRound()
    {
        CurrentRoundNumber++;

        //Delete Existing Choice Buttons
        foreach(GameObject ExistingButton in CurrentlySpawnedChoiceButtons)
        {
            Destroy(ExistingButton);
        }

        CurrentlySpawnedChoiceButtons.Clear();

        for (int i = 0; i < AmountOfChoices; i++)
        {
            GameObject ThisChoiceButton = Instantiate(ChoiceButton, GridParent);
            GatheringChoiceButton gatheringChoiceButtonComponent = ThisChoiceButton.GetComponent<GatheringChoiceButton>();

            Item SelectedItem = SelectItemFromRepo(CurrentRoundNumber);

            float RiskLevel = (CurrentRoundNumber * AmountRiskIncreasedPerRound) * SelectedItem.RiskModifier;

            gatheringChoiceButtonComponent.item = SelectedItem;
            gatheringChoiceButtonComponent.RiskPercentage = RiskLevel;
            gatheringChoiceButtonComponent.FillChoiceButtonUIInfo();

            CurrentlySpawnedChoiceButtons.Add(ThisChoiceButton);
        }
    }


    public Item SelectItemFromRepo(int RoundLevel)
    {
        for (int i = 0; i < 5; i++)
        {
            //Look for a matching item using the percent chances for each round located in the gathering repo in Data
            foreach (ItemChancePair itemChancePair in gatheringRepo.gatherableIngredientsPerLevel[RoundLevel].itemChancePairs)
            {
                float RNG = Random.Range(0, 100);

                if (RNG < itemChancePair.PercentageChanceToBeFoundThisLevel)
                {
                    return itemChancePair.item;
                }
            }
        }

        // None found, unacceptable, fill in a random for now, I have to find a better solution 
        Debug.Log("NO MATCHES FOUND, SELECTING RANDOMLY, fix this eventually");
        return gatheringRepo.gatherableIngredientsPerLevel[RoundLevel].itemChancePairs[Random.Range(0, gatheringRepo.gatherableIngredientsPerLevel[RoundLevel].itemChancePairs.Length)].item;
    }
}
