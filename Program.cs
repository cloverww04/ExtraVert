using Microsoft.VisualBasic;

List<Plant> plants = new() {
    new Plant() {
        Species = "Hemlock",
        AskingPrice = 1.99m,
        LightNeeds = 1,
        City = "Nashville",
        Sold = false,
        Zip = "12345",
        AvailableUntil = new DateTime(2023, 7, 30)
    },
    new Plant() {
        Species = "Japanese stiltgrass",
        AskingPrice = 19.99m,
        LightNeeds = 2,
        City = "Cincinatti",
        Sold = false,
        Zip = "65345",
        AvailableUntil = new DateTime(2023, 7, 30)
    },
    new Plant() {
        Species = "Oat",
        AskingPrice = 5.99m,
        LightNeeds = 3,
        City = "Carthage",
        Sold = true,
        Zip = "12984",
        AvailableUntil = new DateTime(2023, 7, 30)
    },
    new Plant() {
        Species = "Tree of heaven",
        AskingPrice = 99.99m,
        LightNeeds = 4,
        City = "Detroit",
        Sold = false,
        Zip = "94567",
        AvailableUntil = new DateTime(2023, 7, 30)
    },
    new Plant() {
        Species = "Norway maple",
        AskingPrice = 12.99m,
        LightNeeds = 5,
        City = "Cookeville",
        Sold = false,
        Zip = "98765",
        AvailableUntil = new DateTime(2023, 7, 30)
    }
};

Random random = new();

string greeting = @"Welcome to ExtraVert!
We got plants if you got money.";
Console.WriteLine(greeting);
Console.WriteLine("\n");
string choice = null!;
while(choice != "0") {
    Console.WriteLine(@"Choose from the following options:
    0. Exit
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5. Plant of the day
    6. Search by plants light needs
    7. View app statistics");
    
    choice = Console.ReadLine()!;

    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        case "1":
            ViewPlantDetails();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "2":
            addPlant();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "3":
            adoptPlant();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "4":
            removePlant();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "5":
            plantOfDay();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "6":
            search();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "7":
            showStats(plants);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            break;
        default:
            Console.WriteLine("\nPlease enter a number within range\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            break;
    }



    
}







void ViewPlantDetails() {
    
    for (int i = 0; i < plants.Count; i++) {
        Console.WriteLine($"{i+1}. {plants[i].Species}");
    }

    Plant chosenPlant = null!;

    while (chosenPlant == null) {
        Console.WriteLine("Please Enter a number for which plant you'd like to choose: ");
        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            chosenPlant = plants[response - 1]; 

            if( response <1 || response > plants.Count) {
                Console.WriteLine("Please enter a valid plant number");
                return;
            }
        }
        catch (FormatException) {
            Console.WriteLine("Please enter a valid number.");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong. Please try again.");
        }
    }

    Console.WriteLine($"The {chosenPlant.Species} in {chosenPlant.City} {(chosenPlant.Sold ? "was sold" : (chosenPlant.AvailableUntil >= DateTime.Now ? "is available" : "is no longer available for adoption"))} for {chosenPlant.AskingPrice} dollars.");
}

void addPlant() {
    Console.WriteLine("Add a new plant");
    Console.WriteLine("Enter the species:");
    string species = Console.ReadLine()!;
    if (String.IsNullOrEmpty(species)) {
        Console.WriteLine("Species cannot be empty");
        return;
    }

    Console.WriteLine("Enter the plants light needs (1-5)");
    if (!Int32.TryParse(Console.ReadLine(), out int lightNeeds) || lightNeeds < 0 || lightNeeds > 5)
    {
        Console.WriteLine("Invalid light needs. Please enter a number between 1 and 5.");
        return;
    }

    Console.WriteLine("Enter the asking price:");
    string askingPriceInput = Console.ReadLine()!;
    if(!Decimal.TryParse(askingPriceInput, out decimal askingPrice)) {
        Console.WriteLine("Invalid asking price. Please enter a valid decimal number for the asking price.");
        return;
    }

    Console.WriteLine("Enter the city:");
    string city = Console.ReadLine()!;
    if(String.IsNullOrEmpty(city)) {
        Console.WriteLine("City cannot be empty");
        return;
    }

    Console.WriteLine("Enter the zip code");
    string zip = Console.ReadLine()!;
    if(String.IsNullOrEmpty(zip)) {
        Console.WriteLine("Zip code cannot be empty");
        return;
    }

    Console.WriteLine("Enter the expiration date (Year): ");
    string yearInput = Console.ReadLine()!;
    if( !Int32.TryParse(yearInput, out int year) || yearInput.Length != 4) {
        Console.WriteLine("Invalid year. Please enter a valid year with 4 digits.");
        return;
    }

    Console.WriteLine("Enter the expiration date (Month): ");
    if(!Int32.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12) {
        Console.WriteLine("Invalid month. Please enter a valid month between 1 and 12");
        return;
    }

    Console.WriteLine("Enter the expiration date (Day): ");
    if(!Int32.TryParse(Console.ReadLine(), out int day) || day < 1 || day > 31) {
        Console.WriteLine("Invalid day. Please enter a valid day between 1 and 31");
        return;
    }

    DateTime expirationDate = new (year, month, day);

    Plant newPlant = new() {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        Zip = zip,
        Sold = false,
        AvailableUntil = expirationDate 
    };

    plants.Add(newPlant);

    Console.WriteLine("Plant added succesfully!");
}

void adoptPlant() {
    Console.WriteLine("Adopt a plant!");

    List<Plant> availablePlants = plants.Where(plant => !plant.Sold && plant.AvailableUntil >= DateTime.Now).ToList(); // lambda expression. Like anonymous function in JS

    if (availablePlants.Count == 0) {
        Console.WriteLine("No available plants to adopt.");
        return;
    }

    for (int i = 0; i < availablePlants.Count; i++) {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }

    int numOfAvailablePlants = availablePlants.Count;
    Console.WriteLine($"The number of available plants: {numOfAvailablePlants}");

    Plant plantToAdopt = null!;

    while (plantToAdopt == null) {
        Console.WriteLine("Enter the number of the plant you would like to adopt: ");

        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            if (response < 1 || response > availablePlants.Count) {
                Console.WriteLine("Please enter a valid plant number.");
                continue;
            }

            plantToAdopt = availablePlants[response -1];
            plantToAdopt.Sold = true; 
        }
        catch (FormatException) {
            Console.WriteLine("Please enter a valid number.");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong. Please try again.");
        }
    }

    Console.WriteLine($"You have adopted the {plantToAdopt.Species}!");


}

void removePlant() {
    Console.WriteLine("Remove a plant");

    for (int i = 0; i < plants.Count; i++) {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    Plant plantToRemove = null!;
    while (plantToRemove == null) {
        Console.WriteLine("Enter the number of the plant to remove: ");

        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            if (response < 1 || response > plants.Count) {
                Console.WriteLine("Please enter a valid plant number.");
                continue;
            }

            plantToRemove = plants[response - 1];
        }
        catch (FormatException) {
            Console.WriteLine("Please enter a valid number");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong. Please try again.");
        }
    }

    plants.Remove(plantToRemove);

    Console.WriteLine("Plant removed successfully!");
}

void plantOfDay() {
    Plant plantOfTheDay = null!;
    int randomIndex;

    do
    {
        randomIndex = random.Next(0, plants.Count);
        plantOfTheDay = plants[randomIndex];
    }
    while (plantOfTheDay.Sold);

    Console.WriteLine($@"Plant Of the Day:
        The plant of the day is a {plantOfTheDay.Species} and it is located in {plantOfTheDay.City}.
        It has a light need of {plantOfTheDay.LightNeeds} and is priced at {plantOfTheDay.AskingPrice} dollars.");

}

void search()
{
    Console.WriteLine("Enter a maximum light need between 1 and 5:");
    if (!Int32.TryParse(Console.ReadLine(), out int response) || response < 1 || response > 5)
    {
        Console.WriteLine("Please enter a valid number between 1 and 5.");
        return;
    }

    List<Plant> availablePlants = plants.Where(plant => plant.LightNeeds <= response && !plant.Sold).ToList();

    if (availablePlants.Count == 0)
    {
        Console.WriteLine("No available plants matching the light needs.");
    }
    else
    {
        for (int i = 0; i < availablePlants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
        }
    }
}

void showStats(List<Plant> plants)
{
    decimal lowestPrice = Decimal.MaxValue;
    string lowestPricePlantName = null!;
    int numOfAvailablePlants = plants.Count(plant => !plant.Sold );
    int numOfAdoptedPlants = plants.Count(plant => plant.Sold);
    string highestLightLevelPlant = null!;
    int highestLightLevel = 0;
    int totalLightLevel = 0;

    foreach (Plant plant in plants)
    {
        if (plant.AskingPrice < lowestPrice)
        {
            lowestPrice = plant.AskingPrice;
            lowestPricePlantName = plant.Species!;
        }

        if (plant.LightNeeds > highestLightLevel) {
            highestLightLevel = plant.LightNeeds;
            highestLightLevelPlant = plant.Species!;
        }
        totalLightLevel += plant.LightNeeds;
    }

   
    if (lowestPricePlantName != null)
    {
        Console.WriteLine($"The lowest price plant is the {lowestPricePlantName} with a asking price of {lowestPrice}.");
    }
    else
    {
        Console.WriteLine("No plants found.");
    }

    if (numOfAvailablePlants != 0) {
        Console.WriteLine($"The number of available plants is {numOfAvailablePlants}.");
    }
    else {
        Console.WriteLine("No plants found.");
    }

    if (highestLightLevelPlant != null) {
        Console.WriteLine($"The plant with the highest light level is the {highestLightLevelPlant} with a light level of {highestLightLevel}.");
    }
    else {
        Console.WriteLine("No plants found.");
    }

    if (totalLightLevel != 0) {
        double averageLightLevel = totalLightLevel / (double)numOfAvailablePlants;
        Console.WriteLine($"The average light level of all the plants is {averageLightLevel}.");
    }
    else {
        Console.WriteLine("No plants found.");
    }

    if (plants.Count != 0) {
        double adoptionPercentage = (double) numOfAdoptedPlants / plants.Count * 100;
        Console.WriteLine($"The percentage of adopted plants is {adoptionPercentage}%.");
    }
    else {
        Console.WriteLine("No plants found.");
    }
}

