﻿using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class Moderation
    {

        //UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());
        //ConverterToDto converterToDto = new ConverterToDto();

        //public int GetReportCountForReason(string reason)
        //{
        //    return unitOfWork.Reports.GetCollectionByPredicate(x => x.Reason == reason).Count();
        //}

        //public List<Report> GetAllReportsOnReason(string reason)
        //{
        //    return unitOfWork.Reports.GetCollectionByPredicate(x => x.Reason == reason).ToList();
        //}

        //public List<Report> GetAllReportsOnDate(DateTime date)
        //{
        //    return unitOfWork.Reports.GetCollectionByPredicate(x => x.Date == date).ToList();
        //}

        //public List<Report> GetAllReportsFromDate(DateTime date)
        //{
        //    return unitOfWork.Reports.GetCollectionByPredicate(x => x.Date >= date).ToList();
        //}

        //public Report GetReport(int reportId)
        //{
        //    return unitOfWork.Reports.Get(reportId);
        //}

        //public int GetDeckStatistics(int deckId)
        //{
        //    List<Statistic> deckStatistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Id == deckId).ToList();

        //    if (deckStatistics.Count > 0)
        //    {
        //        double totalDeckPercent = 0.0;
        //        double result = 0.0;

        //        foreach (Statistic statistic in deckStatistics)
        //        {
        //            totalDeckPercent += statistic.SuccessPercent;
        //        }
        //        result = Math.Round(totalDeckPercent / deckStatistics.Count);

        //        return Convert.ToInt32(result);
        //    }
        //    return 0;
        //}

        //public int GetStatistics(string deckName, int userId)   
        //{
        //    List<Statistic> statistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Name == deckName && x.User.Id == userId).ToList();
        //    if (statistics.Count > 1)
        //    {
        //        return statistics[0].SuccessPercent;
        //    }
        //    return 0;
        //}

        //public void DeleteStatistics(Statistic statistics)
        //{
        //    unitOfWork.Statistics.Delete(statistics);
        //    unitOfWork.Save();
        //}

        //public List<UserDTO> GetAllUsersByCourse(int courseId)
        //{
        //    List<UserCourse> userCourses = unitOfWork.UserCourses.GetCollectionByPredicate(x => x.Course.Id == courseId).ToList();
        //    List<UserDTO> users = new List<UserDTO>();
        //    foreach (UserCourse userCourse in userCourses)
        //    {
        //        users.Add(converterToDto.ConvertToUserDTO(userCourse.User));
        //    }
        //    return users;
        //}

        
        //public List<UserDTO> GetAllUsersByDeck(string deckName)      
        //{
        //    List<Statistic> statistics = unitOfWork.Statistics.GetCollectionByPredicate(x => x.Deck.Name == deckName).ToList();
        //    List<UserDTO> users = new List<UserDTO>();
        //    foreach (Statistic item in statistics)
        //    {
        //        users.Add(converterToDto.ConvertToUserDTO(item.User));
        //    }
        //    return users;
        //}
    }
}