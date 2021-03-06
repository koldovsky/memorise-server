﻿using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
    public class Filter
    {
        private IUnitOfWork unitOfWork;
		
        public Filter()
        {
            unitOfWork = new UnitOfWork(new MemoContext());
        }

        public Filter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Category> GetAllCategories()
        {
            return unitOfWork.Categories.GetAll().ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return unitOfWork.Categories.Get(categoryId) ?? throw new ArgumentNullException();
        }

        public List<Course> GetAllCourses()
        {
            return unitOfWork.Courses.GetAll().ToList();
        }
    }
}
