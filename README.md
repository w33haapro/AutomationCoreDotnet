# Nashtech.Core

## Calling rest API by RestSharp

As an automation tester, I want to call Apis to test that Apis or to prepare data to test the UI application. **ApiRest** feature base on RestSharp library, this feature helps you call a randomly Api with just 1 line of code (Actually, you have to prepare data first). For example, this is the most basic API to call

```C#
//Call an get Api wish just url
string url = "http://api.zippopotam.us/nl/3825";
IRestResponse response = ApiRest.Call(Method.GET, url);
```

You can call an API with full information.

```C#
//Call a Put Api with full information (header, parameter, url, body)
Dictionary<string, string> headers = new Dictionary<string, string>
{
    { "Content-Type", "application/json" }
};

Dictionary<string, object> parameters = new Dictionary<string, object>
{
    { "p", 0 }
};

string jsonBody = "{ \"createdAt\": \"2020-10-31T00:30:13.711Z\", \"name\": \"W33Haa\", \"avatar\": \"https://s3.amazonaws.com/uifaces/faces/twitter/ciaranr/33.jpg\" }";

string url = "https://5f9cbdef6dc8300016d3139b.mockapi.io/w33/users/50";

IRestResponse response = ApiRest.Call(Method.PUT, url, jsonBody, headers, parameters);

```

## Database accessing

As an automation tester, I want to access data from databases to get data that will be used in the test cases. For example, read data from SQL server database to verify a new item that was added by calling an Api.

### Access SQL server by System.Data.SqlClient

To get data from the SQL server, you have to connect to that database by **Connection String** and then using **Query String** to get data. The data will be retrieved in DataTable type. For example:

```C#
string connectionString = "Server=HN-SD-0966-WK;Database=w33;User Id=admin;Password=1;";
string queryString = "select * from Student";

SqlConnection connection = connectionString.GetConnection();
DataTable data = connection.Query(queryString);
```

Functions support:

```C#
//Build a new connection
SqlConnection DatabaseSqlServerAccess.GetConnection(this SqlConnectionStringBuilder sqlConnectionStringBuilder)
SqlConnection DatabaseSqlServerAccess.GetConnection(this string connectionString)
//Execute a query string
DataTable DatabaseSqlServerAccess.Query(this SqlConnection connection, string queryString)
```

## File Reading

As an automation tester, I want to read files with various types such as json, csv, excel.

### Raw text file reader by System.IO

This is the most basic type of data file and it is easy to read. To read the text file we just use the script like this example:

```C#
string filePath = "Path/to/your/text/file";
ReadText(string filePath);
```

### Json file reader by System.IO

```C#
string filePath = "Path/to/your/json/file";
string data = FileAccess.ReadJson(filePath);
```

### CSV file reader by System.IO

There are two types of Csv file, so we have 2 ways to get data from a CSV file.
The first one is about to have headers in the 1st line so we make it is the headers of DataTable and the other lines will be the data under these headers. To get that type of data we can use the example below:

```C#
string filePath = "Path/to/your/csv/file";

//This function will read CSV have headers.
string data = FileAccess.ReadCsv(filePath);

//Or you can use this function will have the same result.
string data2 = FileAccess.ReadCsv(filePath, true);
```

The second type of CSV is about that file will just store value and will not have the column headers. Therefore, the DataTable result will generate the headers with the format "Column {index}" with the index will be the column number that counts from zero. To get that type of data we can use the example below:

```C#
string filePath = "Path/to/your/csv/file";

//This function will read CSV have headers.
//Set the second parameter to false will make the system know that the csv does not have the header row data.
string data2 = FileAccess.ReadCsv(filePath, false);
```

### Excel file reader by System.IO

As same as the Cvs file, the excel file has the same structure so we still have 2 ways to get the excel file.
**The first one will have the first row contains headers of table** and the other line will be data below that headers. Besides, there is a diffirent point compare to Csv file is that the Excel file contains many Worksheet. So, when getting that excel file we can use the script in the below example:

```C#
string filePath = "Path/to/your/excel/file";

//This is the function that help you read the excel file with worksheet index
int worksheetIndex = 0; //First worksheet item
string data = FileAccess.ReadExcel(filePath,worksheetIndex);

//This is the function that help you read the excel file with worksheet name
int worksheetName = "User"; //get data from worksheet named User
string data = FileAccess.ReadExcel(filePath,worksheetName);
```

The second one will contain full of data without column titles. So we will get the data from the Excel file in another way that about adds a third parameter with value "false":

```C#
string filePath = "Path/to/your/excel/file";

//This is the function that help you read the excel file with worksheet index
int worksheetIndex = 0; //first item
string data = FileAccess.ReadExcel(filePath,worksheetIndex,false);

//This is the function that help you read the excel file with worksheet name
int worksheetName = "User"; //get data from worksheet named User
string data = FileAccess.ReadExcel(filePath,worksheetName,false);
```

## Data Assertion handling

As an automation tester, I want to verify in my automation test script that the data is returned from the application is correct or not. Therefore, the assertion is one of the most important parts of the automation testing script, it is the verify step to define the status of the script. There are two types of the assertion that consist of normal assertion (SmartAssert), soft assertion (SmartSoftAssert).

### Normal assertion (SmartAssert) by FluentAssertions

SmartAssert supports some type of verifying:

```C#
AreEqual(this List<object> actual,  List<object> expected)
AreEqual(this object actual, object expected)
AreGreaterThan(this int input, int target)
AreLessThan(this int input, int target)
AreEqual(this string actual, string expected)
AreContain(this string input, string target)
IsNotNull(this object item)
IsNull(this object item)
AreEqualJson(this string actual, string expected)
```

This feature is pretty easy to use.
To verify a list object we can just call AreEqual() function. this function can help us to compare 2 list object. Besides, the object can be a class or many other types of data such as string, int, bool, etc.

```C#
List<object> actual = ... //Init 
List<object> expected = ... //Init 

actual.AreEqual(expected)
```

To verify to object, the function to call still is AreEqual() and the object can be many types of data that contains class, string, int, bool.

```C#
object actual = ... //Init 
object expected = ... //Init 

actual.AreEqual(expected)
```

To verify an object is null or not

```C#
object actual = ... //Init

//To verify that data is not null
actual.IsNotNull()

//To verify that data is null
actual.IsNotNull()
```

To compare an int number with a target number

```C#
int actual = ... //Init 
int target = ... //Init

//To verify that data is greater than target data
actual.AreGreaterThan(target)

//To verify that data is less than target data
actual.AreLessThan(target)
```

### Soft assertion (SmartSoftAssert)

//TODO

## Data Generator by System

As an automation tester, I want to generate some data to become input data that will help me reduce a lot of time in the data preparation period. So, the framework will help to generate random data to save that data preparation time.

### Generate string

To generate a random string with a specific length, we can follow this script

```C#
//To generate a string with length is 10
int length = 10;
string stringResult = GenerateString(length);

//To generate a string number with length is 15
//The string number mean the integer number in string type
int intLength = 15;
string stringResult = GenerateString(intLength, true);
```

## Data process

As an automation tester, I want to transform data into many data type to make me easy to use in the automation test script.

### DataTable process by System

DataTable is one of the most popular data types to use when using data in table format. It usually is the raw data when getting data from databases or files. Unfortunately, it is not simple data to process with, so we usually convert that type to List object type and then use that data in the new format. In term of converting data type, we can you this sample to convert DataTable:

```C#
DataTable datatable = ... //Init

//This function will convert dataTable to list object type
List<object> listItems = datatable.ToList<object>();

//we can also convert DataTable to List class object
//User is a class
List<User> listItems2 = datatable.ToList<User>();
```

In addition, you can also convert the DataRow type to object type. DataRow likes a row data of DataTable.

```C#
DataRow datarow = ... //Init

//This function will convert datatble to object type
object item = datarow.ToObject<object>();

//we can also convert DataTable to the class object
//User is a class
User Item2 = datarow.ToObject<User>();
```

### Json process by Newtonsoft

Json data exist two different types and it requires two way to handle. 

#### JsonObject

To let clear about this type of data I will give an example of a json object

```C#
{
    "Name": "John",
    "Age": 31,
    "City": "New York"
}
```

This type of json data will have some function that helps us to handle

```C#
string jsonObject = ... //Init

//Convert json type to object type
object result =  jsonObject.ToObject<object>();

//Convert json type to class object type name User
User result2 =  jsonObject.ToObject<User>();
```

We also can convert from an object to json object type

```C#
object objectData = ... //Init
User user = ... //Init

string jsonObject = objectData.ToJson<object>();
string jsonUser = user.ToJson<user>();
```

In addition, we can get json value by json path

```C#
string jsonObject = ... //Init
string jsonPath = ... //Init

//To get value from jsonObject with path is jsonPath
string result = jsonObject.JsonObjectGetJValue(jsonPath);
```

#### JsonArray

To let clear about this type of data I will give an example of a json array

```C#
[{
    "Name": "John",
    "Age": 31,
    "City": "New York"
},
{
    "Name": "Jack",
    "Age": 30,
    "City": "Texas"
}]
```

This type of json data will have some function that helps usto handle

```C#
string jsonArray = ... //Init

//Convert json type to list object type
List<object> result =  jsonObject.ToListObject<object>();

//Convert json type to list class object type name User
List<User> result2 =  jsonObject.ToListObject<User>();
```

We also can convert from a list object to json array type

```C#
List<object> listObjectData = ... //Init
List<User> users = ... //Init

string jsonObject = listObjectData.ToJson<object>();
string jsonUser= users.ToJson<user>();
```

Besides, we can get json value by json path

```C#
string jsonArray = ... //Init
string jsonPath = ... //Init

//To get value from jsonArray with path is jsonPath
string result = jsonArray.JsonArrayGetJValue(jsonPath);
```

## UI handling

As an automation tester, I want to handle the browser to implement the automation test script.

### Browser factory

This feature is about to initial IWebDriver instance base on browser name

```C#
//Init new IwebDriver instance that supports Chrome browser.
string browserName = "Chrome";
IWebDriver driver = Browser.Init().GetBrowser(browserName);
```

### Cookies helper

Cookies are the best way to increase your UI automation test script. To handles cookies, we can do some activities such as add, get and delete cookies

```C#
IWebDriver driver = ... //Init
string keyCookie = ... //Init
string valueCookie = ... //Init
Cookie cookie = ... //Init
List<Cookie> cookies = ... //Init

//Handle cookies
//Add cookie by key and value
driver.AddCookie(keyCookie,valueCookie)

//Add cookie by Cookie object
driver.AddCookie(cookie);

//Add many cookies by Cookie object
driver.AddCookies(cookies);

//Get all cookie
List<Cookie> cookies = driver.GetAllCookies();

//Delete all cookie
driver.DeleteAllCookies();
```

### Wait helper

In every step in automation testing, we often have to wait for the element to show off, exist, or even clickable. So this feature helps us can handle this

```C#
IWebDriver driver = ... //Init
By element = ... //Init
int timeout = 50;

//Wait element until it is visible and function will return IElement instance
IElement result = driver.WaitUtil(element, WaitType.WaitUtilVisible, timeout);

//Wait for element until it exist and function will return IElement instance
IElement result = driver.WaitUtil(element, WaitType.WaitUtilExist, timeout);

//Wait element until it is clickable and function will return IElement instance
IElement result = driver.WaitUtil(element, WaitType.WaitUtilClickable, timeout);
```

### Element action

This feature will define some common steps that we use to interact with the browser

```C#
IWebDriver driver = ... //Init
IWebElement element1 = ... //Init
IWebElement element2 = ... //Init
string xOffset = ... //Init
string yOffset = ... //Init

//It will move to the element and click (without releasing) in the middle of the given element.
driver.ClickAndHold(element1);

//This method firstly performs a mouse-move to the location of the element and performs the context-click (right-click) on the given element.
driver.RightClick(element1);

//It will move to the element and performs a double-click in the middle of the given element.
driver.DoubleClick(element1);

//This method moves the mouse to the middle of the element. The element is also scrolled into the view on performing this action.
driver.MoveToElement(element1);

//This method moves the mouse from its current position (or 0,0) by the given offset. If the coordinates are outside the view window, then the mouse will end up outside the browser window.
driver.MoveByOffset(xOffset,yOffset)

//This method firstly performs a click-and-hold on the source element, moves to the location of the target element, and then releases the mouse.
driver.DragAndDrop(element1,element2)

// This method firstly performs a click-and-hold on the source element, moves to the given offset, and then releases the mouse.
driver.DragAndDropBy(element1,xOffset,yOffset)

//This action releases the depressed left mouse button. If WebElement is passed, it will release the depressed left mouse button on the given WebElement
driver.Release(element1, xOffset, yOffset)
```

### UI action

To execute a Javascript script

```C#
//Click on element throw javascript
IwebDriver driver = ... //Init
IElement element = ... //Init

string script = "arguments[0].click();";
driver.JsExecute(script,element)
```

Take a screenshot of the browser

```C#
//Take a screenshot and save to filePath
IwebDriver driver = ... //Init
string filePath = ... //Init

driver.PrintScreen(filePath);
```

## Reporting

Reporting is the undeniable step in the automation testing process, it helps everyone in the development team can understand how well the automation tester does with the application. To generate the report for automation test scripts we just inherit the test class to BaseFixture.

```C#
//Nunit example
[TextFixture]
class ApiCallingTests : BaseFixture {
  [Test]
        public void Api_Call_Get_Successfully()
        {
            string url = "http://api.zippopotam.us/nl/3825";
            IRestResponse response = ApiRest.Call(Method.GET, url);
        }
        ...
}
```

The report will be saved in **"\bin\Debug\netcoreapp3.1\Report\"** folder

## work to do

- SoftAssert
- Logging
- Reporting