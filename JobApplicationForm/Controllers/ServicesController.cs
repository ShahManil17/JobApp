﻿using JobApplicationForm.Areas.Identity.Data.DataModel;
using JobApplicationForm.Data;
using JobApplicationForm.Models;
using JobApplicationForm.Models.UpdateView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace JobApplicationForm.Controllers
{
    public class ServicesController : Controller
    {
        private static int Id = 0;
        private readonly ApplicationDbContext _context;
        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Apply()
        {
            ViewBag.UpdateFlag = false;
            return View();
        }

        [HttpPost]
        public IActionResult Apply(ApplicationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.UpdateFlag = false;
                return View();
            }
            BasicDetails basicModel = new BasicDetails()
            {
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                PhoneNo = model.PhoneNo,
                Gender = model.Gender,
                RelationshipStatus = model.RelationshipStatus
            };
            _context.BasicDetails.Add(basicModel);
            _context.SaveChanges();
            int basicId = basicModel.Id;

            int count = 1;
            foreach (var item in model.EducationDetails)
            {
                EducationDetails educationModel = new EducationDetails()
                {
                    BasicDetailsId = basicId,
                    EduLevel = count,
                    BoardName = item.BoardName,
                    Percentage = item.Percentage,
                    PassingYear = item.PassingYear
                };
                _context.EducationDetails.Add(educationModel);
                _context.SaveChanges();
                count++;
            }

            for(int i=0; i<model.Company.Count; i++)
            {
                WorkExperience workExperience = new WorkExperience();
                workExperience.BasicDetailsId = basicId;
                workExperience.Company = model.Company[i];
                workExperience.Designation = model.Designation[i];
                workExperience.StartDate = model.From[i];
                workExperience.EndDate = model.To[i];
                _context.WorkExperiences.Add(workExperience);
                _context.SaveChanges();
            }

            string[] langArr = new string[] { "hindi", "english", "gujarati" };
            string[] knownArr = new string[] { "read", "write", "speak" };
            
            for (int i=0; i<3; i++)
            {  
                Languages langModel = new Languages();
                if (model.LangName[i] == null)
                {
                    langModel.BasicDetailsId = basicId;
                    langModel.LangName = langArr[i];
                    string langLevel = "";
                    for(int j=0; j<3; j++)
                    {
                        if (model.LangLevel[i][j] == null)
                        {
                            langLevel += knownArr[j] + ",";
                        }
                    }
                    if(langLevel != "")
                    {
                        langLevel = langLevel.TrimEnd(',');
                    }
                    langModel.LangLevel = langLevel;
                    _context.Languages.Add(langModel);
                    _context.SaveChanges();
                }
            }

            string[] techName = new string[] { "php", "mysql", "oracle", "laravel" };
            for(int i=0; i<4; i++)
            {
                Technologies techModel = new Technologies();
                if (model.TechName[i] == null)
                {
                    techModel.BasicDetailsId = basicId;
                    techModel.TechName = techName[i];
                    switch(techName[i])
                    {
                        case "php":
                            techModel.TechLevel = model.PhpLevel;
                            break;
                        case "mysql":
                            techModel.TechLevel = model.MysqlLevel;
                            break;
                        case "oracle":
                            techModel.TechLevel = model.OracleLevel;
                            break;
                        case "laravel":
                            techModel.TechLevel = model.LaravelLevel;
                            break;
                    }
                    _context.Technologies.Add(techModel);
                    _context.SaveChanges();
                }
            }

            string locationIns = "";
            for(int i=0; i<model.Location.Count; i++)
            {
                locationIns += model.Location[i] + ",";
            }
            locationIns = locationIns.TrimEnd(',');
            Preferences prefModel = new Preferences();
            prefModel.BasicDetailsId = basicId;
            prefModel.Location = locationIns;
            prefModel.Notice = model.Notice;
            prefModel.ExpectedCtc = model.ExpectedCtc;
            prefModel.CurrentCtc = model.CurrentCtc;
            prefModel.Department = model.Department;
            _context.Preferences.Add(prefModel);
            _context.SaveChanges();

            return RedirectToAction("Thankyou");
        }

        public IActionResult List()
        {
            var data = _context.BasicDetails.FromSqlRaw("EXEC getAllData").ToList();
            ViewBag.Data = data;
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction()) {
                try
                {
                    var eduItems = _context.EducationDetails.Where(x => x.BasicDetailsId == id);
                    _context.EducationDetails.RemoveRange(eduItems);
                    _context.SaveChanges();

                    var expItems = _context.WorkExperiences.Where(x => x.BasicDetailsId == id);
                    _context.WorkExperiences.RemoveRange(expItems);
                    _context.SaveChanges();

                    var techItems = _context.Technologies.Where(x => x.BasicDetailsId == id);
                    _context.Technologies.RemoveRange(techItems);
                    _context.SaveChanges();

                    var langItems = _context.Languages.Where(x => x.BasicDetailsId == id);
                    _context.Languages.RemoveRange(langItems);
                    _context.SaveChanges();

                    _context.Preferences.Remove(_context.Preferences.Where(x => x.BasicDetailsId == id).FirstOrDefault());
                    _context.SaveChanges();

                    _context.BasicDetails.Remove(_context.BasicDetails.Where(x => x.Id == id).FirstOrDefault());
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                }
            }
            
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            ServicesController.Id = id;
            ViewBag.UpdateFlag = true;
            var UpdateData = await _context.Database.SqlQuery<string>($"EXEC getPerticularData {id}").ToListAsync();
            UpdateDataModel[] updateDataModel;
            updateDataModel = JsonSerializer.Deserialize<UpdateDataModel[]>(UpdateData.First());
            ViewBag.UpdateData = updateDataModel[0];
            

            return View("Apply");
        }

        [HttpPost]
        public IActionResult Update(ApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UpdateFlag = false;
                return RedirectToAction("Update");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Update Basic Details
                    var id = _context.BasicDetails
                        .Where(x => x.Id == ServicesController.Id)
                        .Select(x => x.Id)
                        .FirstOrDefault();
                    BasicDetails basicModel = new BasicDetails()
                    {
                        Id = id,
                        Name = model.Name,
                        Email = model.Email,
                        Address = model.Address,
                        PhoneNo = model.PhoneNo,
                        Gender = model.Gender,
                        RelationshipStatus = model.RelationshipStatus
                    };
                    _context.BasicDetails.Update(basicModel);
                    _context.SaveChanges();

                    //Update Educational Details
                    var eduId = _context.EducationDetails
                        .Where(x => x.BasicDetailsId == ServicesController.Id)
                        .Select(x => x.Id)
                        .ToList();
                    int count = 1;
                    int idCount = 0;
                    foreach (var item in model.EducationDetails)
                    {
                        EducationDetails educationModel = new EducationDetails()
                        {
                            Id = eduId[idCount],
                            BasicDetailsId = ServicesController.Id,
                            EduLevel = count,
                            BoardName = item.BoardName,
                            Percentage = item.Percentage,
                            PassingYear = item.PassingYear
                        };
                        _context.EducationDetails.Update(educationModel);
                        _context.SaveChanges();
                        idCount++;
                    }

                    //Delete Old Work Experience
                    var expItems = _context.WorkExperiences
                        .Where(x => x.BasicDetailsId == ServicesController.Id);
                    _context.WorkExperiences.RemoveRange(expItems);
                    _context.SaveChanges();

                    //Add Updated Work Experience
                    for (int i = 0; i < model.Company.Count; i++)
                    {
                        if (model.Company[i] != null)
                        {
                            WorkExperience workExperience = new WorkExperience();
                            workExperience.BasicDetailsId = ServicesController.Id;
                            workExperience.Company = model.Company[i];
                            workExperience.Designation = model.Designation[i];
                            workExperience.StartDate = model.From[i];
                            workExperience.EndDate = model.To[i];
                            _context.WorkExperiences.Add(workExperience);
                            _context.SaveChanges();
                        }
                    }

                    //Delete Old Technologies
                    var techItems = _context.Technologies.Where(x => x.BasicDetailsId == ServicesController.Id);
                    _context.Technologies.RemoveRange(techItems);
                    _context.SaveChanges();
                    
                    //Add updated Technologies
                    string[] techName = new string[] { "php", "mysql", "oracle", "laravel" };
                    for (int i = 0; i < 4; i++)
                    {
                        Technologies techModel = new Technologies();
                        if (model.TechName[i] == null)
                        {
                            techModel.BasicDetailsId = ServicesController.Id;
                            techModel.TechName = techName[i];
                            switch (techName[i])
                            {
                                case "php":
                                    techModel.TechLevel = model.PhpLevel;
                                    break;
                                case "mysql":
                                    techModel.TechLevel = model.MysqlLevel;
                                    break;
                                case "oracle":
                                    techModel.TechLevel = model.OracleLevel;
                                    break;
                                case "laravel":
                                    techModel.TechLevel = model.LaravelLevel;
                                    break;
                            }
                            _context.Technologies.Add(techModel);
                            _context.SaveChanges();
                        }
                    }

                    //Delete Old Language Details
                    var langItems = _context.Languages.Where(x => x.BasicDetailsId == ServicesController.Id);
                    _context.Languages.RemoveRange(langItems);
                    _context.SaveChanges();
                    
                    //Add Updated Language Details
                    string[] langArr = new string[] { "hindi", "english", "gujarati" };
                    string[] knownArr = new string[] { "read", "write", "speak" };
                    for (int i = 0; i < 3; i++)
                    {
                        Languages langModel = new Languages();
                        if (model.LangName[i] == null)
                        {
                            langModel.BasicDetailsId = ServicesController.Id;
                            langModel.LangName = langArr[i];
                            string langLevel = "";
                            for (int j = 0; j < 3; j++)
                            {
                                if (model.LangLevel[i][j] == null)
                                {
                                    langLevel += knownArr[j] + ",";
                                }
                            }
                            if (langLevel != "")
                            {
                                langLevel = langLevel.TrimEnd(',');
                            }
                            langModel.LangLevel = langLevel;
                            _context.Languages.Add(langModel);
                            _context.SaveChanges();
                        }
                    }

                    //Update Preferences Details
                    string locationIns = "";
                    for (int i = 0; i < model.Location.Count; i++)
                    {
                        locationIns += model.Location[i] + ",";
                    }
                    locationIns = locationIns.TrimEnd(',');
                    id = _context.Preferences
                        .Where(x => x.BasicDetailsId == ServicesController.Id)
                        .Select(x => x.Id)
                        .FirstOrDefault();
                    Preferences prefModel = new Preferences();
                    prefModel.Id = id;
                    prefModel.BasicDetailsId = ServicesController.Id;
                    prefModel.Location = locationIns;
                    prefModel.Notice = model.Notice;
                    prefModel.ExpectedCtc = model.ExpectedCtc;
                    prefModel.CurrentCtc = model.CurrentCtc;
                    prefModel.Department = model.Department;
                    _context.Preferences.Update(prefModel);
                    _context.SaveChanges();

                    //If Everything is right Commit the changes to the database
                    transaction.Commit();
                }
                catch
                {
                    //handle exception and Rollback to prevent data loss
                    transaction.Rollback();
                }
            }
                
            return RedirectToAction("List");
        }

        public IActionResult Thankyou()
        {
            return View();
        }
    }
}
