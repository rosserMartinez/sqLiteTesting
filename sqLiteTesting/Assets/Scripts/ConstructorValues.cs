using System.Collections.Generic;
using UnityEngine;

public static class ConstructorValues
{
    public static int startingFood = 0;
    public static int startingMedicine = 0;

    public static float foodWeight = 1;
    public static float fuelWeight = .5f;
    public static float woodWeight = 1;
    public static float metalWeight = 1;
    public static float medicineWeight = 1;
    public static float personWeight = 1;

    public static float helicopterMaxInventoryWeight = 1000f;

    public static string[] MPNames2017Girls = { "Emma", "Olivia", "Ava", "Isabella", "Sophia",
    "Mia", "Charlotte", "Amelia", "Evelyn", "Abigail", "Harper", "Emily", "Elizabeth", "Avery",
    "Sofia", "Ella", "Madison", "Scarlett", "Victoria", "Aria", "Grace", "Chloe", "Camila", "Penelope",
    "Riley", "Layla", "Lillian", "Nora", "Zoey", "Mila", "Aubrey", "Hannah", "Lily", "Addison", "Eleanor",
    "Natalie", "Luna", "Savannah", "Brooklyn", "Leah", "Zoe", "Stella", "Hazel", "Ellie", "Paisley",
    "Audrey", "Skylar", "Violet", "Claire", "Bella", "Aurora", "Lucy", "Anna", "Samantha", "Caroline",
    "Genesis", "Aaliyah", "Kennedy", "Kinsley", "Allison", "Maya", "Sarah", "Madelyn", "Adeline", "Alexa",
    "Ariana", "Elena", "Gabriella", "Naomi", "Alice", "Sadie", "Hailey", "Eva", "Emilia", "Autumn", "Quinn",
    "Nevaeh", "Piper", "Ruby", "Serenity", "Willow", "Everly", "Cora", "Kaylee", "Lydia", "Aubree",
    "Arianna", "Eliana", "Peyton", "Melanie", "Gianna", "Isabelle", "Julia", "Valentina", "Nova",
    "Clara", "Vivian", "Reagan", "Mackenzie", "Madeline"};

    public static string[] MPNames2017Boys = {"Liam", "Noah", "William", "James", "Logan", "Benjamin",
    "Mason", "Elijah", "Oliver", "Jacob", "Lucas", "Michael", "Alexander", "Ethan", "Daniel", "Matthew",
    "Aiden", "Henry", "Joseph", "Jackon", "Samuel", "Sebastian", "David", "Carter", "Wyatt", "Jayden",
    "John", "Owen", "Dylan", "Luke", "Gabriel", "Anthony", "Isaac", "Grayson", "Jack", "Julian", "Levi",
    "Christopher", "Joshua", "Andrew", "Lincoln", "Mateo", "Ryan", "Jaxon", "Nathan", "Aaron", "Isaiah",
    "Thomas", "Charles", "Caleb", "Josiah", "Christian", "Hunter", "Eli", "Jonathan", "Connor", "Landon",
    "Adrian", "Asher", "Cameron", "Leo", "Theodore", "Jeremiah", "Hudson", "Robert", "Easton", "Nolan",
    "Nicholas", "Ezra", "Colton", "Angel", "Brayden", "Jordan", "Dominic", "Austin", "Ian", "Adam", "Elias",
    "Jaxson", "Greyson", "Jose", "Ezekiel", "Carson", "Evan", "Maverick", "Bryson", "Jace", "Cooper", "Xavier",
    "Parker", "Roman", "Jason", "Santiago", "Chase", "Sawyer", "Gavin", "Leonardo", "Kayden", "Ayden"};

    public static List<string> lastNames = new List<string> { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller",
        "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson",
        "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young",
        "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson",
        "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards",
        "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey",
        "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez", "James",
        "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett", "Wood", "Barnes", "Ross", "Henderson", "Coleman",
        "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington", "Butler", "Simmons",
        "Foster", "Gonzales", "Bryant", "Alexander", "Russell", "Griffin", "Diaz", "Hayes" };

    public struct Age
    {
        public string name;
        public float probability;
        public int minAge;
        public int maxAge;

        public Age(string n, float p, int min, int max)
        {
            name = n;
            probability = p;
            minAge = min;
            maxAge = max;
        }
    }

    public static Age toddler = new Age("Toddler", .1f, 1, 5);
    //public static Age child = new Age("Child", .2f, 5, 13);
    //public static Age youngAdult = new Age("Young Adult", .3f, 13, 22);
    public static Age adult = new Age("Adult", .3f, 25, 56);
    public static Age elderly = new Age("Elderly", .1f, 76, 90);

    public static Age[] ages = new Age[] { toddler, adult, elderly };

    public struct Region
    {
        public string name;
        public State[] states;
        public float probability;

        public Region(string nm, float p, State[] st)
        {
            probability = p;
            name = nm;
            states = st;
        }
    }

    public struct State
    {
        public string name;
        public string[] towns;

        public State(string nm, string[] t)
        {
            name = nm;
            towns = t;
        }
    }

    public static string[] VTTowns = { "Burlington", "Rutland", "Montpelier" };
    public static State VT = new State("VT", VTTowns);

    public static string[] NHTowns = { "Manchester", "Nashua", "Concord" };
    public static State NH = new State("NH", NHTowns);

    public static string[] MATowns = { "Boston", "Worcester", "Springfield" };
    public static State MA = new State("MA", MATowns);

    public static string[] METowns = { "Portland", "Lewiston", "Augusta" };
    public static State ME = new State("ME", METowns);

    public static string[] CTTowns = { "Bridgeport", "New Haven", "Hartford" };
    public static State CT = new State("CT", CTTowns);

    public static string[] NYTowns = { "New York City", "Buffalo", "Albany" };
    public static State NY = new State("NY", NYTowns);

    public static string[] RITowns = { "Providence", "Warwick", "Cranston" };
    public static State RI = new State("RI", RITowns);

    public static string[] NJTowns = { "Newark", "Paterson", "Trenton" };
    public static State NJ = new State("NJ", NJTowns);

    public static string[] PATowns = { "Philadelphia", "Pittsburgh", "Harrisburg" };
    public static State PA = new State("PA", PATowns);

    public static Region northeast = new Region("Northeast", 1, new State[] { VT, NH, MA, ME, CT, NY, RI, NJ, PA });

    public static Region[] regions = new Region[] { northeast };
    

    public static string[] occupations = { "Doctor", "Scientist", "Teacher", "Engineer", "Janitor", "Salesperson",
        "Cashier", "Office Clerk", "Chef", "Cook", "Server", "Nurse", "Customer Service", "Cleaner", "Mover",
        "Secretary", "General Manager", "Accountant", "Teller", "Driver", "Game developer", "Administrator",
        "Mechanic", "Maintenance/Repair Person", "Security Guard", "Receptionist", "Farmer", "Business Person",
        "Recruiter", "Landscaper", "Delivery Person", "Construction Worker", "Surgeon", "Mail Person",
        "Police Officer", "Soldier", "Assembly line worker", "Carpenter", "Social Worker", "Therapist", "EMT",
        "Athlete", "Actor", "IT worker", "Student", "Toddler", "Infant", "Lawyer", "Analyst", "Electrician",
        "Software Developer", "Bartender", "Correction officer", "Cashier", "Human Resources", "Quality Assurance",
        "Plumber", "Hairdresser", "Cosmetologist", "Tailor", "Pharmacist", "Programmer", "Welder", "Firefighter",
        "Dentist", "Telemarketer", "Unemployed", "Artist", "Writer", "Architect", "Fisher", "Mathematician",
        "Florist", "Entertainer", "Animal Care", "Psychic" };
    
    public static string[] tags = { "Illiterate", "Tired", "Morose", "Hateful", "Bigot", "Bed-Wetter", "Naive", "Light Sleeper",
    "Heavy Sleeper", "Timid", "Edgy", "Pathetic", "Gullible", "Trustworthy", "Kind", "Energetic", "Deaf", "Blind",
    "Crybaby", "Cool", "Fast", "Intelligent", "Obnoxious", "Passionate", "Tone-Deaf", "Bruises Easily", "Stubborn" };

}
