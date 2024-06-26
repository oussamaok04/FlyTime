using FlyTime.Core;
using FlyTime.Core.Models;
using FlyTime.Core.Services;
using FlyTime.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;

namespace FlyTime.API.Controllers
{
    public class TestFileController : ControllerBase
    {
        public IActivityService aService;
        public IAeroportService aeService;
        public IVolService vService;

        public string filePath = "Controllers/test.csv";
        public int currentId = 0;

        public TestFileController(IActivityService aService, IAeroportService aeService, IVolService vService)
        {
            this.aService = aService;
            this.aeService = aeService;
            this.vService = vService;
        }

        [HttpGet]
        [Route("/activities/{id}")]
        public Activity getActivityById(int id)
        {
            return aService.GetActivityById(id).Result;
        }

        [HttpGet]
        [Route("/activities")]
        public Task<List<Activity>> getAllActivities()
        {
            return aService.GetAllActivities();
        }

        [HttpGet]
        [Route("/vols")]
        public Task<IEnumerable<Vol>> getAllVols()
        {
            return vService.GetAllVols();
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async void deleteById(int id)
        {
            //Activity activity = await aService.GetActivityById(id).Result;
            aService.DeleteActivity(getActivityById(id));             
        }

        [HttpPost]
        [Route("/add")]
        public async Task add()
        {
            Core.Models.Activity activity = new Activity();
            activity.Id = 3;
            activity.VolId = 1;
            activity.FromDestination = null;
            activity.ToDestination = null;
            activity.StartTime = TimeSpan.Parse("11:00");
            activity.EndTime = TimeSpan.Parse("12:00");
            await aService.CreateActivity(activity);
            //await context.AddAsync(activity);
            //await context.SaveChangesAsync();
            //context.Activities.Add(activity);
            //context.SaveChanges();
        }

        [HttpPost]
        [Route("/addVol")]
        public async Task addVol()
        {
            Vol vol = new Vol();
            vol.PilotId = 1;
            vol.Id = 2;
            await vService.CreateVol(vol);
            //await context.AddAsync(activity);
            //await context.SaveChangesAsync();
            //context.Activities.Add(activity);
            //context.SaveChanges();
        }

        [HttpPost]
        [Route("/activity/save")]
        public void AddActivity()
        {
            Activity activity = content(filePath)[0];
            aService.CreateActivity(activity);
        }

        [HttpGet]
        [Route("/content")]
        public List<Activity> GetContent()
        {
            return content(filePath);
        }

        [HttpGet]
        [Route("/firstActivity")]
        public Activity GetFirstActivity()
        {
            return content(filePath)[0];
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

        [HttpPost]
        [Route("/upload")]
        public async Task content2()
        {
            //List<Activity> result = new List<Activity>();

            var lines = System.IO.File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var cells = line.Split(',');

                Vol vol = new Vol();
                vol.PilotId = 1;
                vol.Id= int.Parse(cells[0]);

                await vService.CreateVol(vol);

                Activity activity = new Activity();

                activity.Id = int.Parse(cells[1]);
                activity.VolId = int.Parse(cells[0]);
                activity.FromDestination = await aeService.GetAeroportByCode(cells[2]);
                activity.ToDestination = await aeService.GetAeroportByCode(cells[3]);
                activity.StartTime = TimeSpan.Parse(cells[4]);
                activity.EndTime = TimeSpan.Parse(cells[5]);

                await aService.CreateActivity(activity);
                //result.Add(activity);

            }
            //return Task.CompletedTask;
            //return result;
        }

        [HttpGet]
        [Route("/activities/vol/{id}")]
        public async Task<IEnumerable<Activity>> getActivitiesByVolId(int id)
        {
            return await aService.GetActivityByVol(id);
        }
    }
}
