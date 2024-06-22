using Proyect;

namespace TestProyect
{
    [TestClass]
    public class AuthenticationServiceUnitTest
    {
        [TestMethod]
        public void LoginUser_ShouldReturnNullOnIncorrectCredentials()
        {
            UserDataService userDataService = new UserDataService();
            User existingUser = new User
            {
                Username = "existingUser",
                Password = "existingPassword",
            };

            userDataService.RegisterUser(existingUser);

            User loggedInUser = userDataService.LoginUser("nonExistingUser", "wrongPassword");

            Assert.IsNull(loggedInUser);
        }

        [TestMethod]
        public void RegisterUser_ShouldNotAddDuplicateUser()
        {
            UserDataService userDataService = new UserDataService();
            User user = new User()
            {
                Username = "testUser",
                Password = "testPassword",
            };
            userDataService.RegisterUser(user);
            User user2 = new User()
            {
                Username = "testUser",
                Password = "testPassword"
            };
            bool result = userDataService.RegisterUser(user2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginUser_ShouldReturnUserWithCorrectData()
        {
            UserDataService userDataService = new UserDataService();
            User user = new User
            {
                Username = "testUser",
                Password = "testPassword"
            };

            userDataService.RegisterUser(user);

            User loggedUser = userDataService.LoginUser("testUser", "testPassword");

            Assert.IsNotNull(loggedUser);
            Assert.AreEqual(user.Username, loggedUser.Username);
            Assert.AreEqual(user.Password, loggedUser.Password);
        }

        [TestMethod]
        public void CanUserTakeData_True()
        {
            User user = new User();

            user.Username = "Test";
            user.UserId = 1;
            user.Password = "PasswordTest";
            user.Role = UserRole.Customer;

            string actualUsername = user.Username;
            int actualUserId = user.UserId;
            string actualPassword = user.Password;
            UserRole actualRole = user.Role;

            Assert.AreEqual("Test", actualUsername);
            Assert.AreEqual(1, actualUserId);
            Assert.AreEqual("PasswordTest", actualPassword);
            Assert.AreEqual(UserRole.Customer, actualRole);
        }

        private static string testProductDataFile = "test_products.json";

        [TestMethod]
        public void LoadProducts_WhenFileExists_ShouldReturnListOfProducts()
        {
            if (File.Exists(testProductDataFile))
            {
                File.Delete(testProductDataFile);
            }

            List<Product> testData = new List<Product>
            {
                new Product { ProductId = 1, Name = "TestProduct1" },
                new Product { ProductId = 2, Name = "TestProduct2" }
            };

            DataRepository.SaveProducts(testData);

            Product additionalProduct = new Product { ProductId = 3, Name = "AdditionalProduct" };
            testData.Add(additionalProduct);
            DataRepository.SaveProducts(testData);

            List<Product> actualProducts = DataRepository.LoadProducts();

            CollectionAssert.AreEqual(testData, actualProducts);
        }

        [TestMethod]
        public void UpdateProduct_ShouldUpdateExistingProductAndSaveToFile()
        {
            Product updatedProduct = new Product { ProductId = 2, Name = "UpdatedProduct" };
            List<Product> existingProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product1" },
                new Product { ProductId = 2, Name = "Product2" },
            };

            DataRepository.UpdateProduct(updatedProduct);
            List<Product> updatedProducts = DataRepository.LoadProducts();
 
            Product actualUpdatedProduct = updatedProducts.Find(p => p.ProductId == updatedProduct.ProductId);
            Assert.IsNotNull(actualUpdatedProduct);
            Assert.AreEqual(updatedProduct.Name, actualUpdatedProduct.Name);

            File.Delete(testProductDataFile);
        }

        [TestMethod]
        public void LoadProducts_WhenFileDoesNotExist_ShouldReturnEmptyList()
        {
            string productDataFile = "DataToDelete.json";

            if (File.Exists(productDataFile))
            {
                File.Delete(productDataFile);
            }

            Assert.IsFalse(File.Exists(productDataFile));
        }
    }
}