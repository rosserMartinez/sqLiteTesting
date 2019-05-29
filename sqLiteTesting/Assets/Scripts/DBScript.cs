using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//includes for sqlite
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DBScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //open database in data folder
        string targetDBstr = "URI=file:" + Application.dataPath + "/Data/DataBank.db";

        //open connection
        IDbConnection dbConnection = new SqliteConnection(targetDBstr);
        dbConnection.Open();
       
        //read table
        IDbCommand readCmd = dbConnection.CreateCommand();
        IDataReader dataReader;

        string query = "SELECT * FROM People";
        readCmd.CommandText = query;
        dataReader = readCmd.ExecuteReader();

        //print table values
        while (dataReader.Read())
        {
            Debug.Log("LAST: " + dataReader[0].ToString());
            Debug.Log("FIRST: " + dataReader[1].ToString());
            Debug.Log("HOME: " + dataReader[2].ToString());
        }

        //close connection
        dbConnection.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
