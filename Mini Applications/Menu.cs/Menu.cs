using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
    static void Main(string[] args)
    {
        bool displayMenu = true;
        while (displayMenu) // Continuously displaying the main menu until the user decides to exit
        {
            displayMenu = MainMenu(); // Calling the MainMenu method
        }
    }

    // Displaying the main menu and processing user choices
    private static bool MainMenu()
    {
        Console.Clear(); // Clearing the console screen for a fresh display of options
        Console.WriteLine("Choose one of the following options:");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1) Trinary Converter");
        Console.WriteLine("2) School Roster");
        Console.WriteLine("3) ISBN Verifier");
        Console.WriteLine("4) Exit");
        Console.Write("\r\nSelect an option: ");   

        string userInput = Console.ReadLine(); // Reading the user's choice

        // Evaluating the user's choice and directing to the appropriate function or exiting
        switch (userInput)
        {
            case "1":
                TrinaryConverter(); // Calling the TrinaryConverter method
                break;
            case "2":
                SchoolRosterMenu(); // Calling the SchoolRosterMenu method
                break;
            case "3":
                ISBNVerifierMethod(); // Calling the ISBNVerifierMethod
                break;
            case "4":
                return false; // Exiting the menu loop and the program
            default:
                Console.WriteLine("Invalid option, please try again and select a number.");
                Console.ReadKey(); // Waiting for a key press before re-showing the menu
                break;
     
        }
        return true;
    }   


/*
Test Plan for The Trinary Converter:

Objective is to:
Validate the Trinary Converter method for correct conversions from trinary to decimal system.

Test Cases:

1. Test Case: A Valid Trinary Number
   Input: "112"
   Expected Output: "14"
   Actual Output: "Decimal equivalent: "14"
   Status: Pass/Fail - Pass

2. Test Case: Invalid Trinary Number (Non-Trinary Characters)
   Input: "102a12"
   Expected Output: "Invalid Trinary Number"
   Actual Output: "Invalid input: 'a'. A trinary number should only contain digits 0, 1, or 2."
   Status: Pass/Fail - Pass

3. Test Case: Empty Input
   Input: ""
   Expected Output: "Invalid Trinary Number"
   Actual Output: "Invalid Trinary Number: Input is empty."
   Status: Pass/Fail - Pass

4. Test Case: Trinary Number with Leading Zeros
   Input: "00102012"
   Expected Output: "302"
   Actual Output: "Decimal equivalent: 302"
   Status: Pass/Fail - Pass

5. Test Case: Large Trinary Number
   Input: "2222222222"
   Expected Output: "59048"
   Actual Output: "Decimal equivalent: 59048"
   Status: Pass/Fail - Pass
*/




    // Handling the conversion of trinary numbers to decimal
    public static void TrinaryConverter()
    {
        while (true) // Looping until a valid trinary number is entered
        {
            Console.WriteLine("Enter a trinary number:");
            string userInput = Console.ReadLine();

            // Check for empty input
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Invalid Trinary Number: Input is empty.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                continue; // Continuing the loop to prompt for input again
            }

            bool isValid = true;

            // Checking each character of the input to ensure it's a valid trinary digit
            foreach (char a in userInput)
            {
                if (a != '0' && a != '1' && a != '2') // Validating each character
                {
                    Console.WriteLine($"Invalid input: '{a}'. A trinary number should only contain digits 0, 1, or 2.");
                    Console.WriteLine("Example of a valid trinary number: 102012");
                    isValid = false;
                    break; // Exiting the loop if an invalid character was found
                }
            }

            // Proceeding with conversion if the input was valid
            if (isValid)
            {
                long decimalValue = 0; // Variable to store the decimal equivalent
                int power = 0; // Power to be used in the conversion calculation

                // Converting the trinary number to decimal
                for (int i = userInput.Length - 1; i >= 0; i--)
                {
                    int trit = userInput[i] - '0'; // Converts char to int (e.g., '2' becomes 2)
                    decimalValue += trit * (long)Math.Pow(3, power); //https://learn.microsoft.com/en-us/dotnet/api/system.math.pow?view=net-8.0
                    power++; // Incrementing the power for the next digit
                }

                Console.WriteLine($"Decimal equivalent: {decimalValue}"); // Displaying the decimal equivalent
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey(); 
                break; // Break out of the while loop
            }
            else
            {
                // Prompting the user to try again if the input was not valid
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
    
    // Declaration of a SchoolRoster instance for managing school roster data
    private static SchoolRoster schoolRoster = new SchoolRoster();

    // Displaying the school roster menu and handling user interactions
    public static void SchoolRosterMenu()
    {
        Console.WriteLine("School Roster Menu:");
        Console.WriteLine("1) Add a student");
        Console.WriteLine("2) Get students in a form");
        Console.WriteLine("3) Get all students");
        Console.WriteLine("4) Return to main menu");
        Console.Write("\r\nSelect an option: ");

        string userInput = Console.ReadLine();

        // Evaluating the user's choice and executing the corresponding function
        switch (userInput)
        {
            case "1":
                AddStudentToRoster();
                break;
            case "2":
                GetStudentsInForm();
                break;
            case "3":
                Console.WriteLine(schoolRoster.GetAllStudents());
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Method for adding a student to the roster
    private static void AddStudentToRoster()
    {
        Console.Write("Enter student's name: "); // Prompting for student's name
        string name = Console.ReadLine(); // Reading student's name

        Console.Write("Enter form number: "); // Prompting for the form number
        if (int.TryParse(Console.ReadLine(), out int form)) // Validating and parsing the form number
        {
            schoolRoster.AddStudent(name, form); // Adding the student to the specified form
            Console.WriteLine($"{name} added to form {form}."); // Confirming the addition
        }
        else
        {
            Console.WriteLine("Invalid form number."); // Handling invalid form number input
        }
    }

    // Method for displaying students in a specific form
    private static void GetStudentsInForm()
    {
        Console.Write("Enter form number to list students: "); // Prompting for the form number
        if (int.TryParse(Console.ReadLine(), out int form)) // Validating and parsing the form number
        {
            Console.WriteLine(schoolRoster.GetStudentsInForm(form)); // Displaying students in the specified form
        }
        else
        {
            Console.WriteLine("Invalid form number."); // Handling invalid form number input
        }
    }

    public static void ISBNVerifierMethod()
    {
        Console.Write("Enter an ISBN-10 to verify (format: XXX-X-XXX-XXXXX-X or XXXXXXXXXX): "); // Asking user to unput an ISBN number, an example of an acceptable format is given.
        string isbnInput = Console.ReadLine();

        if (!IsISBNFormatValid(isbnInput)) //Checking the inverse of the method's return value.
        {
            Console.WriteLine("Invalid format. ISBN-10 should be 10 digits, optionally separated by hyphens. Example: 123-4-567-8901-2 or 123456789012"); //Prints a message informing that the format is invalid and reminds them of the correct format.
        }
        else
        {
            bool isValid = ISBNVerifier.VerifyISBN(isbnInput); //Calling the 'VerifyISBN' method, passing the user's input 'isbnInput' to it.
            if (isValid)
            {
                Console.WriteLine("The ISBN is valid."); // If valid prints Valid message
            }
            else
            {
                Console.WriteLine("The ISBN is invalid."); // If not valid prints invalid message
            }
        }

        Console.WriteLine("Press any key to return to the main menu..."); // Message prompting to return to main menu.
        Console.ReadKey(); // Waiting for key press
    }

    // Checks if the ISBN number the user inputed is in the corret format.
    private static bool IsISBNFormatValid(string isbn) 
    {
        // Removes hyphens and checks length
        string cleanIsbn = isbn.Replace("-", ""); // https://learn.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-8.0
        if (cleanIsbn.Length != 10)
        {
            return false;
        }

        // Checks if the first 9 characters are all digits
        for (int i = 0; i < cleanIsbn.Length - 1; i++)
        {
            if (!char.IsDigit(cleanIsbn[i])) // https://learn.microsoft.com/en-us/dotnet/api/system.char.isdigit?view=net-8.0
            {
                return false;
            }
        }

        // The last character can be a digit or 'X'
        char lastChar = cleanIsbn[cleanIsbn.Length - 1]; // Takes the last character of the ISBN
        if (!char.IsDigit(lastChar) && lastChar != 'X' && lastChar != 'x') // Checks if the last character is neither an 'X' or 'x'
        {
            return false;
        }

        // If all checks pass, the format is valid
        return true;
    }
}

class SchoolRoster
{
    
    /*Used a dictionary, stores key-value pairs and allows us to look it up using a key, which are the 'integer - Form number'  and the 'SortedSet<string> - Name of Students'. 
    Since the SortedSet is a set, it ensures no duplicates within the same form exist, and has a sorting feature which stores students names in alphabetical order.
    https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0*/ 
    private Dictionary<int, SortedSet<string>> roster; // Declaring roster of type (Dictionary<int, SortedSet<string>>).
    public SchoolRoster() //Constructor, Instantiating *(creating an instance/object of a class)* SchoolRoster
    {
        roster = new Dictionary<int, SortedSet<string>>(); // Instance of Dictionary<int, SortedSet<string>>() is instantiated and assigned/initialised to the roster field/variable. So now the roster field has the value of the dictionary instance.
    }

    /*When calling 'AddStudent("Alice", 1)', the method checks if there is an entry for Form 1 in 'roster'. If not, it creates a new sorted set for Form 1
    Then, it adds "Alice" to the sorted set in Form 1. If a another student is added to the Form, the method finds that Form 1 already exists in 'roster' and will add the student's name to the existing set.*/
    public void AddStudent(string name, int form) //Creating a mehod to add a student to a form
    {
        if (!roster.ContainsKey(form)) //Checking to see if there is an already existing record in the roster dictionary. If not then it executes the statement.
        {
            roster[form] = new SortedSet<string>(); // 'roster[form]' creates the entry in the dictionary for the specified form. Then creates an empty list/collection that holds strings (student names) and automatically keeps them sorted.
        }

        roster[form].Add(name); //'roster[form]' fetches the 'SortedSet<string>' for the specified form, and then adds the name of the student's to the set.
    }

    public string GetStudentsInForm(int form) //Creating Method to extract existing Students from a selected Form.
    {
        if (!roster.ContainsKey(form) || roster[form].Count == 0) //Checks to see if the Form exists, and if it is empty *has students or not*
        {
            return $"There are no students in form {form}."; //If either condition is true - no Form or/and an Empty Form - returns the statement.
        }

        return $"Form {form} students: " + string.Join(", ", roster[form]); //If the form exists and has students, then the list of students in the form is joined and displayed seperated by commas.
    }

    public string GetAllStudents()
    {
        if (roster.Count == 0) // Checks if the 'roster' dictionary has any entries.
        {
            return "There are no students enrolled in school right now."; // Returns statement that no student's were found.
        }

        var allStudents = roster
            .OrderBy(f => f.Key) //LINQ method that sorts the elements within the roster. 'f => f.Key' a lambda expression, specifying that sorting be based on Form number (ascending numerical order).
            .Select(f => $"Form {f.Key}: " + string.Join(", ", f.Value)) // 
            .ToList(); //Converts the result of the 'Select' operation into a 'List<string>'.

        return "All students: " + string.Join("; ", allStudents); //Final output displaying the list of all students and forms.
    }
}

public class ISBNVerifier
{

    public static bool VerifyISBN(string isbn)
    {
        
        string cleanIsbn = isbn.Replace("-", ""); //.Replace calls on the isbn string (the user input) and takes the first parameter "-" and replaces it with the second patameter "".

        // Checking if the length is exactly 10
        if (cleanIsbn.Length != 10)
        {
            return false;
        }

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (cleanIsbn[i] - '0') * (10 - i); //Calculating the checksum of the first nine digits of an ISBN number.
        }

        // Checking the last character
        char lastChar = cleanIsbn[9]; // Retrieves the last characher of the 'cleanIsbn' string
        int lastValue = (lastChar == 'X' || lastChar == 'x') ? 10 : (lastChar - '0'); //Checks if the last character is an 'X' or 'x'. '? 10'- if the condition is true, 'lastValue' is set to 10. If not it subtracts the ASCII value of '0' from the ASCII value of 'lastChar'
        sum += lastValue; // Adds the numeric value of the check digit to the 'sums' variable

        // The ISBN is valid if sum is divisible by 11
        return sum % 11 == 0;
    }


}