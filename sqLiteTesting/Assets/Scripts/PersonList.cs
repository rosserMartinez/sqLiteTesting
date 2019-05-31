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

    /// <summary>
    /// massive list of necessary keys database side for people generation
    /// </summary>

    //create string constants for each table (messy for the moment), naming convention: <tableName> <TableName>/<Key><KeyName>
    private const string peopleTableName = "People";
    private const string peopleKeyPersonID = "Person_ID";
    private const string peopleKeyLastName = "Last_Name";
    private const string peopleKeyFirstName = "First_Name";
    private const string peopleKeyTown = "HomeTown";
    ///just so you remember how its sorted on the database side! (provided the table is complex at all)
    private string[] peopleColumns = new string[] { peopleKeyPersonID, peopleKeyLastName, peopleKeyFirstName, peopleKeyTown };


    //dont define these yet since you have the UI to generate them for you, but leave them here when we switch to DB integration
    //possible first names
    private const string firstNameTableName = "FirstNames";
    ///just ids and values

    //possible last names
    private const string lastNameTableName = "LastNames";
    ///just ids and values

    //possible hometowns
    private const string homeTownTableName = "HomeTowns";
    ///just ids and values

    //possible occupations
    private const string occupationTableName = "Occupations";
    private const string occKeyID = "OccupationID";
    private const string occKeyOccupation = "Occupation";
    private string[] occColumns = new string[] { occKeyID, occKeyOccupation };

    //possible tags
    private const string tagTableName = "Tags";
    private const string tagKeyID = "TagID";
    private const string tagKeyDesc = "TagDescriptor";
    private string[] tagColumns = new string[] { tagKeyID, tagKeyDesc };

    //what tags people possess
    private const string personTagTableName = "PersonTags";
    private const string personTagKeyPersonID = "PersonID";
    private const string personTagKeyTagID = "TagID";
    private string[] tagColumns = new string[] { personTagKeyPersonID, personTagKeyTagID };

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

        string connectionString = "URI=file:" + Application.persistentDataPath + "/Data/" + base.name + ".db";
        //open connection
        base.connection = new SqliteConnection(connectionString);
        base.connection.Open();

        //create people table
        IDbCommand createPeopleCmd = CreateDBCommand();

        createPeopleCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + peopleTableName
            + " ( " + peopleKeyPersonID + "TEXT PRIMARY KEY, "
            + peopleKeyLastName + " TEXT, "
            + peopleKeyFirstName + " TEXT, "
            + peopleKeyTown + " TEXT )";

        createPeopleCmd.ExecuteNonQuery();

        //create occupation table
        IDbCommand createOccCmd = CreateDBCommand();

        createOccCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + occupationTableName
            + " ( " + occKeyID + "INTEGER PRIMARY KEY AUTOINCREMENT, "
            + occKeyOccupation + " TEXT )";

        createOccCmd.ExecuteNonQuery();

        //create tags table
        IDbCommand createTagCmd = CreateDBCommand();

        createTagCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tagTableName
            + " ( " + occKeyID + "INTEGER PRIMARY KEY AUTOINCREMENT, "
            + occKeyOccupation + " TEXT )";

        createTagCmd.ExecuteNonQuery();

        //create person table
        IDbCommand createTagCmd = CreateDBCommand();

        createTagCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + personTagTableName
            + " ( " + occKeyID + "INTEGER PRIMARY KEY AUTOINCREMENT, "
            + occKeyOccupation + " INTEGER )";

        createTagCmd.ExecuteNonQuery();

        //get current people list from DB
        RequestPeopleList();
    }

    // Update is called once per frame
    void Update()
    {

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
            "INSERT INTO " + peopleTableName + " ( "
            + peopleKeyPersonID + ", "
            + peopleKeyLastName + ", "
            + peopleKeyFirstName + ", "
            + peopleKeyTown + " ) "

            + "VALUES ( '"
            + person.personID + "', '"
            + person.lastName + "', '"
            + person.firstName + "', '"
            + person.homeTown + "' )";

        addCmd.ExecuteNonQuery();

        //add person to local list
        //people.Add(person);



        //create tags for that persons ID in person tag


        //create hunger / sickness stats for that person??

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

        //pick random tags and add them to player
        List<string> newTags;


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

        IDataReader tableReader = GetDataFromTable(peopleTableName);

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

    //dont need to request individual items at the moment
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
