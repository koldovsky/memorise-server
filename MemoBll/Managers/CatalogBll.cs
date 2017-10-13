using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class CatalogBll
    {
        ICatalog catalog;
        IConverterToDTO converterToDto;

        public CatalogBll()
        {
			this.catalog = new Catalog();
            this.converterToDto = new ConverterToDTO();
        }

        public CatalogBll(ICatalog catalog, IConverterToDTO converter)
        {
			this.catalog = catalog;
            this.converterToDto = converter;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
			return catalog.GetAllCategories()
				.Select(c => converterToDto.ConvertToCategoryDTO(c));
        }

        public IEnumerable<CourseDTO> GetAllCourses()
        {
            return catalog.GetAllCourses()
				.Select(c => converterToDto.ConvertToCourseDTO(c));

        }

        public IEnumerable<DeckDTO> GetAllDecks()
        {
            return catalog.GetAllDecks()
				.Select(d => converterToDto.ConvertToDeckDTO(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            return catalog.GetAllDecksByCourse(courseName)
				.Select(d => converterToDto.ConvertToDeckDTO(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCategory(string categoryName)
        {
			return catalog.GetAllDecksByCategory(categoryName)
				.Select(d => converterToDto.ConvertToDeckDTO(d));
        }

        public IEnumerable<CourseDTO> GetAllCoursesByCategory(string categoryName)
        {
            return catalog.GetAllCoursesByCategory(categoryName)
				.Select(c => converterToDto.ConvertToCourseDTO(c));
        }

        public CourseWithDecksDTO GetCourseWithDecksDTO(string courseName)
        {
			return converterToDto.ConvertToCourseWithDecksDTO(
				catalog.GetCourse(courseName));
        }

        public DeckDTO GetDeckDTO(string linking)
        {
            return converterToDto.ConvertToDeckDTO(catalog.GetDeck(linking));
        }
    }
}
