using FlyTime.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;

namespace FlyTime.API.Controllers
{
    public class TestFileController : ControllerBase
    {
        public string filePath = "Controllers/test.csv";
        public int currentId = 0;

        [HttpGet]
        [Route("/content")]
        public List<Activity> GetContent()
        {
            return content(filePath);
        }

        public List<Activity> content(string filePath)
        {
            List<Activity> result = new List<Activity>();
            
            var lines = System.IO.File.ReadAllLines(filePath);
      
            foreach (var line in lines)
            {
                var cells = line.Split(',');
                Activity activity = new Activity();
                Aeroport a1 = new Aeroport();
                a1.Id = currentId++;
                a1.Name = cells[2];
                a1.City = cells[2];
                a1.Code = cells[2];
                a1.Country = cells[2];

                Aeroport a2 = new Aeroport();
                a2.Id = currentId++;
                a2.Name = cells[3];
                a2.City = cells[3];
                a2.Code = cells[3];
                a2.Country = cells[3];

                activity.Id = int.Parse(cells[1]);
                activity.VolId = int.Parse(cells[0]);
                activity.FromDestination = a1;
                activity.ToDestination = a2;
                activity.StartTime = TimeSpan.Parse(cells[4]);
                activity.EndTime = TimeSpan.Parse(cells[5]);
                result.Add(activity);
            }
            return result;
        }
    }
}
