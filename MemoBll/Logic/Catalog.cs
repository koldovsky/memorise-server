using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
	public class Catalog : ICatalog
	{
		IUnitOfWork unitOfWork;

		public Catalog()
		{
			unitOfWork = new UnitOfWork(new MemoContext());
		}

		public Catalog(IUnitOfWork uow)
		{
			unitOfWork = uow;
		}

		public IEnumerable<Category> GetAllCategories()
		{
			return unitOfWork.Categories.GetAll();
		}

		public IEnumerable<Course> GetAllCourses()
		{
			return unitOfWork.Courses.GetAll();
		}

		public IEnumerable<Deck> GetAllDecks()
		{
			return unitOfWork.Decks.GetAll();
		}

		public IEnumerable<Deck> GetAllDecksByCourse(string courseLinking)
		{
			return unitOfWork.Courses
				.GetAll()
				.FirstOrDefault(x => x.Linking == courseLinking)
				.Decks;
		}

		public IEnumerable<Deck> GetAllDecksByCategory(string categoryLinking)
		{
            var category = unitOfWork.Categories
                        .GetAll()
                        .FirstOrDefault(x => x.Linking == categoryLinking);
            return category?.Decks;	
		}

        public IEnumerable<Course> GetAllCoursesByCategory(string categoryLinking)
        {
            var category = unitOfWork.Categories
            .GetAll()
            .FirstOrDefault(x => x.Linking == categoryLinking);
            return category?.Courses;
        }

        public Course GetCourse(string courseLinking)
		{
			return unitOfWork.Courses
				.GetAll()
				.FirstOrDefault(x => x.Linking == courseLinking);
		}

        public Deck GetDeck(string linking)
        {
            return unitOfWork.Decks
                .GetAll()
                .FirstOrDefault(x => x.Linking == linking);
        }
    }
}
