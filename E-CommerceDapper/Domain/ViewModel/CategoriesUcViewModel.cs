using E_CommerceDapper.DataAccess.Entities;
using E_CommerceDapper.Domain.Command;
using E_CommerceDapper.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.Domain.ViewModel
{
    public class CategoriesUcViewModel:BaseViewModel
    {

		public RelayCommand SelectedCategoryCommand { get; set; }
		public RelayCommand SelectedProductCommand { get; set; }
		private readonly CategoryService _categoryService;

		private ObservableCollection<string> allCategories;

		public ObservableCollection<string> AllCategories
		{
			get { return allCategories; }
			set { allCategories = value; OnPropertyChanged(); }
		}

		private ObservableCollection<Product> allProducts;

		public ObservableCollection<Product> AllProducts
		{
			get { return allProducts; }
			set { allProducts = value; OnPropertyChanged(); }
		}

		private string selectedCategory;

		public string SelectedCategory
        {
			get { return selectedCategory; }
			set { selectedCategory = value;OnPropertyChanged(); }
		}

		private Product selectedProduct;

		public Product SelectedProduct
		{
			get { return selectedProduct; }
			set { selectedProduct = value; OnPropertyChanged(); }
		}

		public CategoriesUcViewModel()
		{
			AllCategories= new ObservableCollection<string>();
			AllProducts= new ObservableCollection<Product>();
			_categoryService= new CategoryService();
			GetData();
            ProductOfSelectedCategories();
			ShowProductInformation();
		}

		public async void GetData()
		{
			await GetCategoryAsync();
			await GetAllProduct();
		}

		public async Task GetCategoryAsync()
		{
            var categories = await App.DB.CategoryRepository.GetAll();

            foreach (var category in categories)
                AllCategories.Add(category.CategoryName);
        }

		public async Task GetAllProduct()
		{
			var products=await App.DB.ProductRepository.GetAll();

			foreach (var item in products)
				AllProducts.Add(item);
		}

		//funksiyanin yazilis prinsipini duz olub olmadigini mellimnen sorus;
		public void ProductOfSelectedCategories()
		{
            SelectedCategoryCommand = new RelayCommand(async(e) =>
			{
				var products=await _categoryService.ProductOfSelectedCategoriesAsync(SelectedCategory);
				for (int i = 0; i < AllProducts.Count; i++)
					AllProducts.RemoveAt(i);

				foreach (var item in products)
					AllProducts.Add(item);
			});
		}

		public void ShowProductInformation()
		{
			SelectedProductCommand = new RelayCommand((e) =>
			{
				var a = SelectedProduct;
			});
		}
	}
}
