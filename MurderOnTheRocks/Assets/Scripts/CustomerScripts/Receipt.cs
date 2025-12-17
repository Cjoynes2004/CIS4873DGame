using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Receipt : MonoBehaviour
{
    public List<string> customIngredients = new List<string>();
    public TextAsset ingredientFile;
    public string glassType = "";
    public string baseType = "";

    private PlayerController playerCheck;
    private List<string> totalIngredients = new List<string>();
    private Dictionary<string, int> glasses = new Dictionary<string, int>();
    private List<string> bases = new List<string>();
    private int totalSlots = 0;

    void Awake()
    {
        LoadInFile();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCheck = GetComponent<PlayerController>();
        if (!playerCheck)
        {
            GenerateOrder();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateOrder()
    {

        if (glasses.Count == 0 || bases.Count == 0 || totalIngredients.Count == 0)
        {
            Debug.LogError(
                $"GenerateOrder called too early on {gameObject.name} | " +
                $"Glasses={glasses.Count}, Bases={bases.Count}, Ingredients={totalIngredients.Count}"
            );
            return;
        }

        customIngredients.Clear();

        int glassIndex = Random.Range(0, glasses.Count);
        var glassList = glasses.ToList();
        var selectedGlass = glassList[glassIndex];

        glassType = selectedGlass.Key;
        totalSlots = selectedGlass.Value;

        int baseIndex = Random.Range(0, bases.Count);
        baseType = bases.ElementAt(baseIndex);

        for (int i = 0; i < totalSlots / 2; i++)
        {
            int ingredientIndex = Random.Range(0, totalIngredients.Count);
            customIngredients.Add(totalIngredients.ElementAt(ingredientIndex));
        }
    }

    private void LoadInFile()
    {
        string[] lines = ingredientFile.text.Split('\n');

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                continue;

            string[] parts = line.Split(',');

            switch (parts[0])
            {
                case "GLASS":
                    glasses.Add(parts[1], int.Parse(parts[2]));
                    break;

                case "BASE":
                    bases.Add(parts[1]);
                    break;

                case "INGREDIENT":
                    totalIngredients.Add(parts[1]);
                    break;
            }
        }
    }

    public bool IsEqual(Receipt order)
    {
        if (order.glassType.Equals(glassType))
        {
            if (order.baseType.Equals(baseType))
            {
                bool areEqual = new HashSet<string>(order.customIngredients).SetEquals(customIngredients);
                if (areEqual)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
