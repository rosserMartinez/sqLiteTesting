using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public string personID;
    public string lastName;
    public string firstName;
    public string homeTown;
    public string occupation;

    public List<string> tags;

    public Person(string id, string last, string first, string town, string job, List<string> newTags)
    {
        //set values
        personID = id;
        lastName = last;
        firstName = first;
        homeTown = town;
        occupation = job;

        //copy tmp tags to person tags
        tags = new List<string>(newTags);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
