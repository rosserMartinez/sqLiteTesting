using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//includes for sqlite
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class PersonList : DBBase
{

    //public class Person
    //{
    //
    //    public string personID;
    //    public string lastName;
    //    public string firstName;
    //    public string homeTown;
    //
    //    public List<string> tags;
    //
    //    public Person(string id, string last, string first, string town)
    //    {
    //        //set values
    //        personID = id;
    //        lastName = last;
    //        firstName = first;
    //        homeTown = town;
    //
    //        //initialize tags here
    //        //come back to this, get base functionality first
    //    }
    //}

    public InputField lastName;
    public InputField firstName;
    public InputField homeTown;

    public Text dbText;

    public List<Person> people;

    private const string tableName = "People";
    private const string tableKeyPersonID = "Person_ID";
    private const string tableKeyLastName = "Last_Name";
    private const string tableKeyFirstName = "First_Name";
    private const string tableKeyTown = "HomeTown";

    private string[] columns = new string[] { tableKeyPersonID, tableKeyLastName, tableKeyFirstName, tableKeyTown };


    public PersonList() : base()
    {
        //empty for now?
    }

    // Start is called before the first frame update
    public override void Start()
    {
        //List<Person> people = new List<Person>();
        //base.Start();
        Debug.Log("child start");


        string connectionString = "URI=file:" + Application.dataPath + "/Data/" + base.name + ".db";
        //open connection
        base.connection = new SqliteConnection(connectionString);
        base.connection.Open();

        IDbCommand createCmd = CreateDBCommand();

        createCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName
            + " ( " + tableKeyPersonID + "TEXT PRIMARY KEY, "
            + tableKeyLastName + " TEXT, "
            + tableKeyFirstName + " TEXT, "
            + tableKeyTown + " TEXT )";

        createCmd.ExecuteNonQuery();

        RequestPeopleList();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void DisplayPeopleList()
    {
        //request data from db
        //update current persons list

        //iterate through persons list and display relevant data in a text box on the screen

    }

    //overrides for base functions
    public override IDataReader GetDataFromTable(string tableName)
    {
        IDbCommand readCmd = connection.CreateCommand();

        //set and execute command to read table 
        readCmd.CommandText = "SELECT * FROM " + tableName;
        IDataReader dataReader = readCmd.ExecuteReader();

        return dataReader;
    }

    public override void DeleteTable(string tableName)
    {
        IDbCommand deleteCmd = connection.CreateCommand();

        //set and execute command to delete table
        deleteCmd.CommandText = "DROP TABLE IF EXISTS " + tableName;
        deleteCmd.ExecuteNonQuery();
    }

    public override IDataReader GetTableRowCount(string tableName)
    {
        IDbCommand rowCmd = connection.CreateCommand();

        //set and execute command to count rows
        rowCmd.CommandText = "SELECT COALESCE(MAX(id)+1, 0) FROM " + tableName;
        IDataReader dataReader = rowCmd.ExecuteReader();
        return dataReader;
    }

    //CURD create update request delete

    //functions for DB interaction
    void CreateAndAddPerson(Person person)
    {
        //add target person to database of people
        IDbCommand addCmd = base.CreateDBCommand();

        addCmd.CommandText =
            "INSERT INTO " + tableName + " ( "
            + tableKeyPersonID + ", "
            + tableKeyLastName + ", "
            + tableKeyFirstName + ", "
            + tableKeyTown + " ) "

            + "VALUES ( '"
            + person.personID + "', '"
            + person.lastName + "', '"
            + person.firstName + "', '"
            + person.homeTown + "' )";

        addCmd.ExecuteNonQuery();

        //add person to local list
        //people.Add(person);
    }

    public void ButtonPersonCreation()
    {
        //input validation
        if (lastName.text == "")
        {
            Debug.Log("LASTNAME EMPTY, PERSON CREATION FAILED");
            return;
        }

        if (firstName.text == "")
        {
            Debug.Log("FIRSTNAME EMPTY, PERSON CREATION FAILED");
            return;
        }

        if (homeTown.text == "")
        {
            Debug.Log("HOMETOWN EMPTY, PERSON CREATION FAILED");
            return;
        }

        //create new person from saved text fields, randomly generate an ID number
        Person newPerson;
        newPerson = new Person(Random.Range(1111, 9999).ToString(), lastName.text, firstName.text, homeTown.text);

        CreateAndAddPerson(newPerson);

        //clear text for next new person
        lastName.text  = "";
        firstName.text = "";
        homeTown.text  = "";

        //update text list with database info
        RequestPeopleList();
    }

    void UpdatePeopleList()
    {
        //update db with current list of people
    }

    void RequestPeopleList()
    {
        //get list of people so you can display it in ui
        //do formatting in here, dont spend much time modifying UI

        IDataReader tableReader = GetDataFromTable(tableName);

        dbText.text = "";

        string tmp;

        while (tableReader.Read())
        {
            //DEBUUUUUG
            //Debug.Log("id: "    + tableReader[0].ToString());
            //Debug.Log("last: "  + tableReader[1].ToString());
            //Debug.Log("first: " + tableReader[2].ToString());
            //Debug.Log("town: "  + tableReader[3].ToString());

            tmp = tableReader[0].ToString() + "   " +
                tableReader[1].ToString() + "   " +
                tableReader[2].ToString() + "   " +
                tableReader[3].ToString() + "   ";

            dbText.text = dbText.text + "\n" + tmp;
        }
    }

    void RequestPersonsByID()
    {

    }

    void RequestPersonsByLastName()
    {

    }

    void RequestPersonsByFirstName()
    {

    }

    void RequestPersonsByHometown()
    {

    }



    //dont need delete functions yet, just creation for the moment
    void DeletePeopleList()
    {

    }

    void DeletePersonsByID()
    {

    }

    void DeletePersonsByLastName()
    {

    }

    void DeletePersonsByFirstName()
    {

    }

    void DeletePersonsByHometown()
    {
        
    }

}
