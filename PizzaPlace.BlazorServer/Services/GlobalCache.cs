namespace PizzaPlace.BlazorServer.Services
{
    public class GlobalCache
    {
        public ProductData Products { get; set; }

        public GlobalCache()
        {
            Products = new ProductData();
        }

        public class ProductData
        {
            public IEnumerable<ProductDTO>? ProductDTOs { get; set; }
            public IEnumerable<ProductDTO>? AvailableProductsDTO { get => ProductDTOs?.Where(x => !x.IsArchived).OrderBy(x=>x.DiscountedPrice>0).ThenBy(x=>x.Name); }
            public IEnumerable<ProductDTO>? ArchivedProductsDTO { get => ProductDTOs?.Where(x => x.IsArchived).OrderBy(x => x.DiscountedPrice > 0).ThenBy(x => x.Name); }
            public IEnumerable<ProductDTO>? DiscountedProductsDTO { get => ProductDTOs?.Where(x => !x.IsArchived && x.DiscountedPrice > 0).OrderBy(x => x.Name); }
            public IEnumerable<ProductDTO>? FullPriceProductsDTO { get => ProductDTOs?.Where(x => !x.IsArchived && x.DiscountedPrice==0).OrderBy(x => x.Name); }

        }

    }


}
