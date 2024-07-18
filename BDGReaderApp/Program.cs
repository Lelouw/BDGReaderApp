// See https://aka.ms/new-console-template for more information
using BDGReaderApp.model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

//PLEASE CHECK FILE LOCATION ON YOUR LOCAL FOR FILE PATH

var filePath = @"C:\my stuff\C#\solution2\lelo (1)\Nompumelelo\BDGReaderApp\BDGReaderApp\data\";
var inputFile = filePath + "BDG_Input.txt";
var outputFile = filePath + "BDG_Output.json";
var delimeter = "|";
var strData = string.Empty;
try
{
    using (var sReader = new StreamReader(inputFile))
    {
        List<String> lstData = new List<String>();
        var lstUser = new List<User>();
        while ((strData = sReader.ReadLine()) != null)
        {
            if (String.IsNullOrEmpty(strData))
                continue;

            lstData = [.. strData.Split(delimeter)];

            lstUser.Add(new User
            {
                Id = Convert.ToInt32(lstData[0]),
                Name = lstData[1],
                Surname = lstData[2],
                Email = lstData[3],
                IPAddress = lstData[4]
            });
        }

        if (lstUser.Count > 0)
        {
            var dataString = JsonConvert.SerializeObject(lstUser);
            var strWriter = new StreamWriter(outputFile);
            strWriter.Write(dataString);
            strWriter.Dispose();
        }
    }
}
catch (Exception ex) { 
    Console.WriteLine(ex.Message);
}
Console.Read();
