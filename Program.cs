List<Plant> plants = new() {
    new Plant() {
        Species = "Hemlock",
        AskingPrice = 1.99m,
        LightNeeds = 1,
        City = "Nashville",
        Sold = false
    },
    new Plant() {
        Species = "Japanese stiltgrass",
        AskingPrice = 19.99m,
        LightNeeds = 2,
        City = "Cincinatti",
        Sold = false
    },
    new Plant() {
        Species = "Oat",
        AskingPrice = 5.99m,
        LightNeeds = 3,
        City = "Carthage",
        Sold = true
    },
    new Plant() {
        Species = "Tree of heaven",
        AskingPrice = 99.99m,
        LightNeeds = 4,
        City = "Detriot",
        Sold = false
    },
    new Plant() {
        Species = "Norway maple",
        AskingPrice = 12.99m,
        LightNeeds = 5,
        City = "Cookeville",
        Sold = false
    }
};

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
    4. Delist a plant");
    
    choice = Console.ReadLine()!;

    if (choice == "0") {
        Console.WriteLine("Goodbye!");
    }
    else if ( choice == "1") {
        Console.WriteLine("Display all plants");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if ( choice == "2") {
        Console.WriteLine("Post a plant to be adopted");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if( choice == "3") {
        Console.WriteLine("Adopt a plant");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else if(choice == "4") {
        Console.WriteLine("Delist a plant");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    else {
        Console.WriteLine("\nPlease enter a number between 0 and 4\n");
    }
}







void ViewPlantDetails() {
    
    for (int i = 0; i < plants.Count; i++) {
        Console.WriteLine($"{i+1}. {plants[i].Species}");
    }
}