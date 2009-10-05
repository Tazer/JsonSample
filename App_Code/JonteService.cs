using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using App_Code.Model;

/// <summary>
/// Summary description for JonteService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class JonteService : System.Web.Services.WebService {

    public JonteService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetTasks() {

        IList<Task> tasks = new List<Task>();
        
        using(SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JonteDatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True") )
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Tasks",connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task();
                    task.ID = (int)reader["TaskID"];
                    task.Name = (string)reader["Name"];
                    task.Author = (string) reader["Author"];
                    task.Done = (bool) reader["Done"];
                    tasks.Add(task);
                }
            }
        }


        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(tasks);
    }
}



