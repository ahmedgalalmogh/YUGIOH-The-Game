using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using System.Collections;
using UnityEngine.UI;

public class CardsDB : MonoBehaviour {
    //public static Dictionary<string, Monsters> MonstersInfo;
    //public static Dictionary<string, Spells> SpellInfo;
    //public static Dictionary<string, Traps> TrapInfo;
    public static Dictionary<string, Sprite> ImageInfo;
    public static  Dictionary<string, Cards> AllCardsInfo;
    public static Player PlayerOne;
    public static Player PlayerTwo;
    private void Awake()
    {
        PlayerOne = new Player();
        PlayerTwo = new Player();
        
        //MonstersInfo = new Dictionary<string, Monsters>();
        //SpellInfo = new Dictionary<string, Spells>();
        //TrapInfo = new Dictionary<string, Traps>();
        AllCardsInfo = new Dictionary<string, Cards>();
        ImageInfo = new Dictionary<string, Sprite>();
        ReadMonsterData();
        ReadSpell_TrapsData();
        ReadImages();

    }
    // Use this for initialization
    void Start()
    {
        foreach (var item in AllCardsInfo)
        {
            print(ImageInfo[item.Key]);
            print(AllCardsInfo[item.Key].CardName);
            AllCardsInfo[item.Key].CardImage = ImageInfo[item.Key];
            // Debug.Log(MonstersInfo[item.Key].CardName);
            
            PlayerOne.RandomOrderPlayingCard.Add(AllCardsInfo[item.Key]);
            //print(PlayerOne.RandomOrderPlayingCard[PlayerOne.RandomOrderPlayingCard.Count-1].GetType());
        }
        


    }
    void ReadImages()
    {
        string filePath = @"C:\Users\Hazem\Documents\YuGiOh\Assets\CardEditor\Card Pictures DB";
        DirectoryInfo DI = new DirectoryInfo(filePath);

        FileInfo[] FI = DI.GetFiles();
        
        for (int i = 0; i < FI.Length; i += 2)
        {

            Texture2D tex = new Texture2D(1, 1);
            FileStream file = new FileStream(@"C:\Users\Hazem\Documents\YuGiOh\Assets\CardEditor\Card Pictures DB\" + FI[i].Name, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[file.Length];
            file.Read(b, 0, int.Parse(file.Length.ToString()));

            tex.LoadImage(b);
            //Sprite s=
            Sprite s = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            string Name = "";
            for (int j = 0; j < FI[i].Name.Length; j++)
            {
                if (FI[i].Name[j] == '.' && FI[i].Name[j + 1] == 'p' && FI[i].Name[j + 2] == 'n' && FI[i].Name[j + 3] == 'g')
                {
                    break;
                }
                Name += FI[i].Name[j];
            }
            s.name = Name;
            //ImagesList.Add(s);
            if (!ImageInfo.ContainsKey(s.name))
            {
                //print(s.name);
                ImageInfo.Add(s.name, s);
            }
        }
    }
    public  void ReadMonsterData()
    {
        string conn = "URI=file:" + Application.dataPath + "/CardEditor/CDBLite.db"; //Path to database.
        IDbConnection con;
        con = (IDbConnection)new SqliteConnection(conn);
        con.Open(); //Open connection to the database.
        
        //newMonsters = new List<Monsters>();
        IDbCommand cmd = con.CreateCommand();
        string command="Select * From Monsters";
        cmd.CommandText = command;
        IDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {

            Monsters m = new Monsters();
            m.ID = (string)rdr["Id"];
            m.CardName = (string)rdr["Name"];
            m.CardDesc = (string)rdr["Description"];
            m.Rank = Convert.ToInt32((string)rdr["Level"]);
            m.Attribute = (string)rdr["Attribute"];
            m.Race = (string)rdr["Race"];
            m.AttackPoints = Convert.ToInt32((string)rdr["Attack"]);
            m.DefencePoints = Convert.ToInt32((string)rdr["Defense"]);
            //newMonsters.Add(m);
            if(!AllCardsInfo.ContainsKey(m.ID))
            {
                //Debug.Log(m.CardName);
                AllCardsInfo.Add(m.ID, m);
                //Debug.Log(MonstersInfo[m.ID].CardName);
            }
        }
        rdr.Close();
        rdr = null;
        cmd.Dispose();
        cmd = null;
        con.Close();
        con = null;

    }
    public void ReadSpell_TrapsData()
    {
        string conn = "URI=file:" + Application.dataPath + "/CardEditor/CDBLite.db"; //Path to database.
        IDbConnection con;
        con = (IDbConnection)new SqliteConnection(conn);
        con.Open(); //Open connection to the database.

        //newMonsters = new List<Monsters>();
        IDbCommand cmd = con.CreateCommand();
        string command = "Select * From Spells";
        cmd.CommandText = command;
        IDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            string Id = (string)rdr["Id"];
            string name = (string)rdr["Name"];
            string Desc = (string)rdr["Description"];
            if(Id[0]=='3')
            {
                Spells newCard = new Spells();

                newCard.ID = (string)rdr["Id"];
                newCard.CardName = (string)rdr["Name"];
                newCard.CardDesc = (string)rdr["Description"];

                //newMonsters.Add(m);
                  if (!AllCardsInfo.ContainsKey(newCard.ID))
                    {
                        AllCardsInfo.Add(newCard.ID, newCard);
                    }
            }
            else if(Id[0]=='4')
            {
                Traps newCard = new Traps();

                newCard.ID = (string)rdr["Id"];
                newCard.CardName = (string)rdr["Name"];
                newCard.CardDesc = (string)rdr["Description"];

                //newMonsters.Add(m);
                if (!AllCardsInfo.ContainsKey(newCard.ID))
                {
                    AllCardsInfo.Add(newCard.ID, newCard);
                }
            }
            
        }
        rdr.Close();
        rdr = null;
        cmd.Dispose();
        cmd = null;
        con.Close();
        con = null;

    }

    
}


