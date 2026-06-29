using OrderManagement.Infra;

namespace OrderManagement.Application.ProductService
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }





        #region "Add"


        public void AddProductByAdmin()
        {
            
        }

        public void AddProductByUser()
        {

        }

        public void AddProductByOperator()
        {

        }


        #endregion


        #region "Read"


        public List<ProductDto> GetProducts()
        {
            var list = _productRepository.GetProducts();


            List<ProductDto> listRetdurn = new List<ProductDto>();

            return listRetdurn;
        }

        #endregion
    }
}
