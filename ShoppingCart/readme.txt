Basic design and implementation strategies.
-	Separate components for the product selection and cart computation components.
-	Minimal data transfer size due to passing id's instead of full product details where possible.
-	Calculations done on the server to minimize the client render time.
-	Dependency injection used to decouple server components
-	Entity framework used to abstract the data storage layer.  In memory database used for ease of testing, but easily translatable to other database providers.
-	Separation of repository interfaces and controller implementation to allow other data access strategies.
-	Extensive XML commenting and documentation to allow ease of integration.

Tasks
-----
1. Running tests - Run the MSTests directly from Visual Studio, or run "vstest.console.exe ShoppingCartTests.dll" from the developer command line.
2. Finding the API documentation - Navigate to https://localhost:5001/swagger to see the documentation.

To do list given more time :
1.	Adding language translation (along with currency handling)
2.	Far more extensive unit tests, including GUI unit tests
3.	Responsive UI to handle various screen sizes.  I did not spend much time on layout.
4.	Extensive debug and information logging.
5.	Much better error handling throughout the application, such as argument handling
6.	Add theming support and better UI layout and look/feel.  For example, adding images to products.
7.	Add docker support.
8.	Adding indication of current shopping cart contents / size.