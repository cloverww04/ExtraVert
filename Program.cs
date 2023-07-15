List<Plant> plants = new() {
    new Plant() {
        Species = "Hemlock",
        AskingPrice = 1.99m,
        LightNeeds = 1,
        City = "Nashville",
        Sold = false,
        Zip = "12345"
    },
    new Plant() {
        Species = "Japanese stiltgrass",
        AskingPrice = 19.99m,
        LightNeeds = 2,
        City = "Cincinatti",
        Sold = false,
        Zip = "65345"
    },
    new Plant() {
        Species = "Oat",
        AskingPrice = 5.99m,
        LightNeeds = 3,
        City = "Carthage",
        Sold = false,
        Zip = "12984"
    },
    new Plant() {
        Species = "Tree of heaven",
        AskingPrice = 99.99m,
        LightNeeds = 4,
        City = "Detriot",
        Sold = false,
        Zip = "94567"
    },
    new Plant() {
        Species = "Norway maple",
        AskingPrice = 12.99m,
        LightNeeds = 5,
        City = "Cookeville",
        Sold = false,
        Zip = "98765"
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
    5. Plant of the day");
    
    choice = Console.ReadLine()!;

    if (choice == "0") {
        Console.WriteLine("Goodbye!");
    }
    else if ( choice == "1") {
        ViewPlantDetails();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if ( choice == "2") {
        addPlant();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if( choice == "3") {
        adoptPlant();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if(choice == "4") {
        removePlant();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if (choice == "5") {
        plantOfDay();
    }
    else {
        Console.WriteLine("\nPlease enter a number within range\n");
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

    Console.WriteLine($@"The {chosenPlant.Species} in {chosenPlant.City} {(chosenPlant.Sold ? "was sold" : "is available")} for {chosenPlant.AskingPrice} dollars.");
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

    Plant newPlant = new() {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        Zip = zip,
        Sold = false
    };

    plants.Add(newPlant);

    Console.WriteLine("Plant added succesfully!");
}

void adoptPlant() {
    Console.WriteLine("Adopt a plant!");

    List<Plant> availablePlants = plants.Where(plant => !plant.Sold).ToList(); // lambda expression. Like anonymous function in JS

    if (availablePlants.Count == 0) {
        Console.WriteLine("No available plants to adopt.");
        return;
    }

    for (int i = 0; i < availablePlants.Count; i++) {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }

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