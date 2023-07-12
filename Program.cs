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
ViewPlantDetails();







void ViewPlantDetails() {
    
    for (int i = 0; i < plants.Count; i++) {
        Console.WriteLine($"{i+1}. {plants[i].Species}");
    }
}