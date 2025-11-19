using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp.Services
{
	public interface ICategoryService
	{
		string GetCatagoryName(int id, int categoryId);
	}

	public interface IProductService
	{
		string GetProductCategory(int it, int category);
	}


	public class ProductService(ICategoryService catService) : IProductService
	{
		private ICategoryService CatService => catService;

    public string GetProductCategory(int it, int categoryId) 
		{
			// try {
			// 	if (categoryId == 3) 
			// 		throw new Exception("CategorId does not exits");

				return CatService.GetCatagoryName(it, categoryId);
			// }
			// catch (Exception)
			// {
			// 	throw;
			// }
		}												
  };
}