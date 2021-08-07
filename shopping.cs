using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class shopping : MonoBehaviour
{
    public static List<Vector3> FinalPoints;
    public GameObject[] questiongroup;
    public options[] qa;
    public GameObject Answerpanel;
    private int[,] coordinates = { { 0, 0 }, { 1, 9 }, { 4, 6 }, { 3, 5 }, { 7, 10 }, { 5, 8 }, { 12, 2 } };
    private string[] stores= { "fruits", "clothes", "toys", "jewellery", "cinema", "grocery" };
    public int counter = 0;
    private ArrayList x = new ArrayList();
    private ArrayList y = new ArrayList();
    private ArrayList X = new ArrayList();
    private ArrayList Y = new ArrayList();
    private ArrayList P= new ArrayList();
    private ArrayList Q = new ArrayList();
    private int dist(int x1, int y1, int x2, int y2)
     {  //function for finding distance brtween two pts
         int x = Math.Abs(x1 - x2);
         int y = Math.Abs(y1 - y2);
         int distance = x + y;
         return distance;
     }
    void Start()
    {
        qa = new options[questiongroup.Length];
        FinalPoints = new List<Vector3>();
    }
    public void submit()
    {
        for(int i = 0; i < qa.Length; i++)
        {
            qa[i] = Read(questiongroup[i]);
        }
        arrange();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    options Read(GameObject question)
    {
        options result = new options();
        GameObject ans = question.transform.Find("Answer").gameObject;
        string s = "";
        x.Add(0);
        y.Add(0);
        int k = 1; 
        int counter = 0;
       
        for (int i = 0; i < ans.transform.childCount; i++)
        { 
           
            if (ans.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
             
                s=ans.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                counter++;
                for(int j = 0; j < 6; j++)
                {
                    
                    if (s == stores[j])
                    {
                        x.Add(coordinates[j+1,0]);
                        y.Add(coordinates[j + 1, 1]);
                       
                    }
                }
                k++;
            }
            
        }
        x.TrimToSize();
        y.TrimToSize();
        result.Answer = s;
        return result;
    }
  
   public void arrange()
    {
        int length = x.Count - 1;
        
       int r, sum = 0, l=0, K=0, count = 0, a = 0, b = 0;
        while (count < length)
        {
            r = Int32.MaxValue;
            for (int j = 1; j <= length ; j++)
            {
                int transform = Convert.ToInt32(x[j]);
                int transform1 =Convert.ToInt32(y[j]);
                if (transform != a && transform1 != b)
                {
                    int d =Convert.ToInt32(dist(a, b, transform,transform1));
                    l = Math.Min(r, d);
                    
                    if (l != r)
                    {
                        X.Insert(count, transform); Y.Insert(count, transform1);
                        K = j;
                        r = l;
                        
                    }
                    

                }
            }
            sum += l;
            a = Convert.ToInt32(x[K]); b = Convert.ToInt32(y[K]);
            x[K]=1000; y[K] =1000;
            count++;
        }
        counter = length;
       
        int variable1 = Convert.ToInt32(X[length - 1]);
        int variable2 = Convert.ToInt32(Y[length - 1]);
        sum += Convert.ToInt32(dist(variable1, variable2, 0, 0));
        P.Add(0);
        for (int j = 0;  j < counter;  j++){

            P.Add(X[j]); P.Add(X[j]);
        }
        for (int j = 0;  j < counter; j++){
            Q.Add(Y[j]); Q.Add(Y[j]);
        }
        Q.Add(0);
        for (int j = 0; j < (counter*2)+1; j++)
        {
            Debug.Log(x.Capacity+" the intermediate coordinates are=" + P[j] + " " + Q[j]);
            FinalPoints.Add(new Vector3(Convert.ToInt32(P[j]), 0, Convert.ToInt32(Q[j])));
        }
      
        Debug.Log("Total shortest distance=" + sum);
    }    
}


  [System.Serializable]
public class options
{
   public string Answer = "";
}