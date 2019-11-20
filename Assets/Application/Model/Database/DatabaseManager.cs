using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;
using System;
using System.IO;

public class DatabaseManager 
{
    #region Database basic settings
   private SQLiteConnection _connection;
   public SQLiteConnection Connection{
       get{
           return _connection;
       }
   }

   public DatabaseManager(string DatabaseName){

        string dbPath = Application.streamingAssetsPath + "/" + DatabaseName;
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
   }

   public void CreateDB(System.Type[] pTableTypes){
       var createList = pTableTypes.Where<System.Type>(x =>
       {
           _connection.CreateTable(x);
           return true;
       }).ToList();
   }

   public void AddOrUpdate<T>(T Record){
       try{
           _connection.Insert(Record);
       }catch(Exception e){
            Debug.LogError(e.InnerException.Message);
       }
   }

   public void AddAll<T>(T[] RecordList){
       try{
           _connection.InsertAll(RecordList);
       }catch(Exception e){
           Debug.LogError(e.InnerException.Message);
       }
   }
    #endregion
    public void CreateDB(){
        _connection.DropTable<Player>();
        _connection.CreateTable<Player>();

        _connection.DropTable<UserAccount>();
        _connection.CreateTable<UserAccount>();

        _connection.DropTable<ChatData>();
        _connection.CreateTable<ChatData>();

        _connection.DropTable<Room>();
        _connection.CreateTable<Room>();

        _connection.InsertAll(new[] {
            new UserAccount{
                ID = 0,
                playerUsername = "Aline",
                password = "jibbajabba"
            },

            new UserAccount{
                ID = 1,
                playerUsername = "Rodolpho",
                password = "chocolate"
            }
        });
        
    }

    #region User information management

    //List user accounts that exist
    public IEnumerable<UserAccount> GetUserAccounts(){
        return _connection.Table<UserAccount>();
    }

    //get one specific user account
    public UserAccount GetUserAccount(string username){
        return _connection.Table<UserAccount>().Where(x => x.playerUsername.ToLower() == username.ToLower()).FirstOrDefault();
    }

    //create a new user account
    public UserAccount CreateUserAccount(string username){
        UserAccount newUserAccount = new UserAccount{
            playerUsername = username
        };
        _connection.Insert(newUserAccount);
        return newUserAccount;
    }

    //Login, checking if credetials match with register
    public UserAccount Login(string username, string password){
        if(username !=null && password !=null){
            return _connection.Table<UserAccount>().Where(x => (x.playerUsername == username) && (x.password == password)).FirstOrDefault();
        }else{
            Debug.Log("Invalid credentials");
            return null;
        }
        
    }
    #endregion

}
