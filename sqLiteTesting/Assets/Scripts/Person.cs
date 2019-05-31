using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public string personID;
    public string lastName;
    public string firstName;
    public string homeTown;

    public List<string> tags;

    public Person(string id, string last, string first, string town)
    {
        //set values
        personID = id;
        lastName = last;
        firstName = first;
        homeTown = town;

        //initialize tags here
        //come back to this, get base functionality first
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
