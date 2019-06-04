using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//includes for sqlite
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DBBase : MonoBehaviour
{
    public string name = "Databank";

    public string connectionString;
    public IDbConnection connection;

    public DBBase()
    {
        //open database in data folder
        name = "DataBank";
        //create connection from path
    }

    public void CloseDB()
    {
        //close connection
        connection.Close();
    }

    ~DBBase()
    {
        //close connection
        CloseDB();
    }

    public IDbCommand CreateDBCommand()
    {
        //create and return command from db
        return connection.CreateCommand();
    }

    public bool TableExists(string tableName)
    {
        IDbCommand checkCmd = CreateDBCommand();
        checkCmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";

        IDbDataParameter tableNameParam = checkCmd.CreateParameter(); //dont @ me, this is simpler than casting idbdata param to sqliteparam
        tableNameParam.ParameterName = "@name";
        tableNameParam.Value = tableName;

        checkCmd.Parameters.Add(tableNameParam);

        IDataReader dataReader = checkCmd.ExecuteReader();

         if (dataReader.Read())
         {
             Debug.Log(tableName + " table already exists");
             return true;
         }
         else
         {
             Debug.Log(tableName + " table does not exist");
             return false;
         }
    }

    public virtual IDataReader GetDataFromTable(string tableName)
    {
    //    IDbCommand readCmd = connection.CreateCommand();
    //
    //    //set and execute command to read table 
    //    readCmd.CommandText = "SELECT * FROM " + tableName;
    //    IDataReader dataReader = readCmd.ExecuteReader();

    //    return dataReader;

        Debug.Log("Get function is null!");
        throw null;
    }

    public virtual void DeleteTable(string tableName)
    {
    //    IDbCommand deleteCmd = connection.CreateCommand();
    //
    //    //set and execute command to delete table
    //    deleteCmd.CommandText = "DROP TABLE IF EXISTS " + tableName;
    //    deleteCmd.ExecuteNonQuery();

        Debug.Log("Delete function is null!");
        throw null;
    }

    public virtual IDataReader GetTableRowCount(string tableName)
    {
    //    IDbCommand rowCmd = connection.CreateCommand();
    //
    //    //set and execute command to count rows
    //    rowCmd.CommandText = "SELECT COALESCE(MAX(id)+1, 0) FROM " + tableName;
    //    IDataReader dataReader = rowCmd.ExecuteReader();
    //    return dataReader;
    //
        Debug.Log("Count function is null!");
        throw null;

    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        //Debug.Log(Application.persistentDataPath);

        connectionString = "URI=file:" + Application.persistentDataPath + "/Data/" + name + ".db";
        //open connection
        IDbConnection connection = new SqliteConnection(connectionString);
        connection.Open();

        Debug.Log("base start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
